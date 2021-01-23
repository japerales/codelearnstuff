using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MessagingSystem : SingletonComponent<MessagingSystem>
{

    //Singleton Management: created the moment we call it
    public static MessagingSystem Instance
    {
        get { return ((MessagingSystem)_Instance); }
        set { _Instance = value; }
    }

    private Dictionary<Type, List<MessageHandlerDelegate>> _listenerDict = new Dictionary<Type, List<MessageHandlerDelegate>>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="msgType">El tipo de dato, que será convertido a cadena para ser comprobado</param>
    /// <param name="handler"></param>
    /// <returns></returns>
	public bool AttachListener(Type msgType, MessageHandlerDelegate handler)
    {
        if (msgType == null)
        {
            Debug.Log("MessagingSystem: AttachListener failed due to having no " +
                "message type specified");
            return false;
        }

        
        /*Si no existía la clave, se crea esta y su nueva lista de listeners
        es esencial ponernos de listeners antes de que incluso exista el mensaje
        ya que de lo contrario dependeríamos del momento de creación de estos*/
        if (!_listenerDict.ContainsKey(msgType))
        {
        	//creamos el diccionario si no existe
            _listenerDict.Add(msgType, new List<MessageHandlerDelegate>());
        }
        //si existe la clave, recuperamos la lista
        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];
        if (listenerList.Contains(handler))
        {
            return false; // listener already in list
        }
        //añadimos el listener
        listenerList.Add(handler);
        return true;
    }

    public bool DetachListener(Type msgType, MessageHandlerDelegate handler)
    {
        if (msgType == null)
        {
            Debug.Log("MessagingSystem: DetachListener failed due to having no " +
                      "message type specified");
            return false;
        }

        if (!_listenerDict.ContainsKey(msgType))
        {
            return false;
        }

        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];
        if (!listenerList.Contains(handler))
        {
            return false;
        }
        listenerList.Remove(handler);
        return true;
    }

    private Queue<Message> _messageQueue = new Queue<Message>();
    //cola para procesar los mensajes
    public bool QueueMessage(Message msg)
    {
        //no encolamos mensajes que no tienen listeners...
        if (!_listenerDict.ContainsKey(msg.type))
        {
            return false;
        }
        _messageQueue.Enqueue(msg);
        return true;
    }

    private const int _maxQueueProcessingTime = 16667;
    private System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

    void Update()
    {
        //determinamos un timer que va vaciando la cola. Si el procesamiento sobrepasa el límite entonces sale del update para el siguiente fotograma
        timer.Start();
        while (_messageQueue.Count > 0)
        {
            if (_maxQueueProcessingTime > 0.0f)
            {
                if (timer.Elapsed.Milliseconds > _maxQueueProcessingTime)
                {
                    timer.Stop();
                    return;
                }
            }
            //si estamos dentro del tiempo, desencolamos el siguiente mensaje
            Message msg = _messageQueue.Dequeue();
            if (!TriggerMessage(msg)) //y procesamos...
            {
                Debug.Log("Error when processing message: " + msg.type);
            }
        }
    }

    public bool TriggerMessage(Message msg)
    {
        Type msgType = msg.type;
        //Si está vacio... no procesamos nada!! nos salimos.
        if (!_listenerDict.ContainsKey(msgType))
        {
            Debug.Log("MessagingSystem: Message \"" + msgType + "\" has no listeners!");
            return false; // no listeners for message so ignore it
        }

        //recuperamos la lista de listeners.
        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];

        for (int i = 0; i < listenerList.Count; ++i)
        {
            //una lista de delegates permite recorrer todos estos
            if (listenerList[i](msg))
            {
                return true; // message consumed by the delegate
            }
        }
        //si terminamos toda la lista... igualmente el mensaje ha sido manejado y por tanto devolvemos true.
        return true;
    }
}
