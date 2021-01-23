using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*El patrón adapter se usa principalmente cuando queremos
hacer un wrapper para una clase que no podemos tocar porque resultaría
en muchos problemas. En este caso es la clase Online Player
*/

namespace DesignPatterns.Adapter{
public sealed class OnlinePlayer : ScriptableObject
{
	public string GetFirstName(int id)
	{
		// Lookup online database.
		return "John"; // Retun a placeholder name.
	}

	public string GetLastName(int id)
	{
		// Lookup online database.
		return "Doe"; // Return a placeholder last name.
	}

	public string GetFullName(int id)
	{
		// Lookup online database and get full name 
		return "Doe Jonn";
	}
}
}