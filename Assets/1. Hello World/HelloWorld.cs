using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelloWorld : MonoBehaviour
{
	TextMeshProUGUI textString;
	
	public string[] hellos = {"Hello World", "Hola Mundo", "Bonjour Le Monde",
		"Hallo Welt"};
	
    // Start is called before the first frame update
    void Start()
	{
		textString = GetComponent<TextMeshProUGUI>();
	    
		Random.InitState((int)System.DateTime.Now.Ticks);
		int RandomIndex = Random.Range(0, hellos.Length);
	    
		textString.text = hellos[RandomIndex];
    }
}
