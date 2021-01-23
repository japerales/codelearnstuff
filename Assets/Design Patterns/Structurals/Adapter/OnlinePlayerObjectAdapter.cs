using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Este es el adaptador*/

namespace DesignPatterns.Adapter{
public class OnlinePlayerObjectAdapter : ScriptableObject
{
    // Start is called before the first frame update
	public string GetFullName(OnlinePlayer onlinePlayer, int userId)
	{
		return onlinePlayer.GetFirstName(userId) + " " + onlinePlayer.GetLastName(userId);
	}
}
}