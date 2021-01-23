using System;

//Los handlers que devuelve true consumen el mensaje, y ya no se itera más.
public delegate bool MessageHandlerDelegate(Message message);

//Esta clase será usada para que se derive de ella.
public class Message 
{
	public Type type;
	public Message()
	{
		//por tanto usamos 
		type = GetType();
	}
}
