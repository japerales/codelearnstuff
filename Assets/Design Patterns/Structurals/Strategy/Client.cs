using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Strategy
{
public class Client : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    Tomahawk th = ScriptableObject.CreateInstance<Tomahawk>();
	    Torpedo tor = ScriptableObject.CreateInstance<Torpedo>();
	    
	    //podemos combinar diferentes misiles con diferentes estrategias de búsqueda.
	    th.SetBehaviour(new SeekWithGPS());
	    th.Launch();
	    th.ApplySeek();
	    
	    th.SetBehaviour(new SeekWithSonar());
	    th.Launch();
	    th.ApplySeek();
	    
	    tor.SetBehaviour(new SeekWithSonar());
	    tor.Launch();
	    tor.ApplySeek();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}