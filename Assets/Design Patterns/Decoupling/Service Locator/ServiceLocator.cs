using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*Improvements:
https://martinfowler.com/articles/injection.html#UsingAServiceLocator
Encapsulate the registry and cache components into self-contained classes.
Implement the cache with a combination of the Factory and Prototype patterns.
Implement the ability for services to add themselves dynamically to the registry.
Write a standard interface for your service providers so you can effectively manage them.*/
namespace DesignPatterns.ServiceLocator{
	
	public class ServiceLocator : SingletonComponent<ServiceLocator>
	{
	
		public static ServiceLocator Instance { get { return (ServiceLocator)_Instance;}}
    
		
		private IDictionary<Type, object> m_Services; 
		
		public void Awake()
		{
			FillRegistry();
		}
		
		private void FillRegistry()
		{
			m_Services = new Dictionary<Type, object>();

			m_Services.Add(typeof(LobbyCoordinator), new 
				LobbyCoordinator());
			m_Services.Add(typeof(CurrencyConverter), new 
				CurrencyConverter());
			m_Services.Add(typeof(LightingCoordinator), new 
				LightingCoordinator());		
		}
		
		public T GetService<T>()
		{
			try{
				return (T)m_Services[typeof(T)];
				
			}catch{
				throw new ApplicationException("The requested service is not found.");
			}
		}
}

}