using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedCollision :  MonoBehaviour 
{
    public GameObject LampObject;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            LampObject.GetComponent<Lamps>().timerActive=true;
            Debug.Log("Entre " + collision.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Sali " + collision.gameObject.name);
        }


    }
}
