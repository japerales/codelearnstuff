using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DieSimulator : MonoBehaviour
{
	TextMeshProUGUI textString;
    // Start is called before the first frame update
    void Start()
    {
	    textString = GetComponent<TextMeshProUGUI>();
	    
	    Random.InitState((int)System.DateTime.Now.Ticks); //Si usamos la misma semilla
	    //siempre obtendremos el mismo resultado (si, no random).
	    int RandomIndex = Random.Range(1, 6);
	    
	    textString.text = RandomIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
