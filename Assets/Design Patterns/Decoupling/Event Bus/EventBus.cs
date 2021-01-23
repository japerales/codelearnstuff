using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DesignPatterns.EventBus{

	/*
	Este event bus está basado en el uso de Strings y UnityEvents
	
	Los UnityEvents son contenedores de delegados, por tanto debemos darles UnityActions
	
	Características:
	- Invocación manual por un cliente (no es un event queue auto ejecutado)
	- Como no hay un sistema de mensajes, los actions aceptan 0 argumentos.
	Para solucionar esto una opción es añadir un argumento de tipo Message que contenga
	todo lo necesario.
	
	*/
public class EventBus : SingletonComponent<EventBus>
{
	public static EventBus Instance 
	{ 
		get { return (EventBus)_Instance;}
		set{ _Instance = value;}
	}
	
	private Dictionary<string, UnityEvent> m_EventDictionary;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		Init();
	}
	
	private void Init()
	{
		if (m_EventDictionary == null)
			m_EventDictionary = new Dictionary<string, UnityEvent>();
	}
	
	public void StartListening(string eventName, UnityAction listener)
	{
		UnityEvent _event = null;
		if (!m_EventDictionary.ContainsKey(eventName))
		{
			_event = new UnityEvent();
			_event.AddListener(listener);
			m_EventDictionary.Add(eventName, _event);
		}else if (m_EventDictionary.TryGetValue(eventName, out _event)){
			_event.AddListener(listener);
		}
	}
	
	public void StopListening(string eventName, UnityAction listener)
	{
		UnityEvent _eventList;
		if (m_EventDictionary.TryGetValue(eventName, out _eventList))
		{
			_eventList.RemoveListener(listener);
		}
	}
	
	public void TriggerEvent(string eventName)
	{
		UnityEvent _event = null;
		if (m_EventDictionary.TryGetValue(eventName, out _event))
		{
			_event.Invoke();
		}
		
	}
}
}

