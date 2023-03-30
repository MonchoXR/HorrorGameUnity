using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ParedCollisionEvent :  MonoBehaviour 
{
   [SerializeField] private UnityEvent ParedEvent; //Importante hacer esta definción
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag ==  "Player")
        {
          if(PlayerFPS.isEnableClamFlash)
          {
             ParedEvent.Invoke();
          }
       
        }
    }
    private void OnTriggerExit(Collider collision)
    {
      


    }
}
