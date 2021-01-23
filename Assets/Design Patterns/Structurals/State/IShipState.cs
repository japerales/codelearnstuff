using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State{
	
	public interface IShipState 
{
	void Execute(Ship ship);
}

}