using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ScaredClownEvent : MonoBehaviour
{
    public GameObject clown;

    bool playAuido = true;
     [SerializeField] private UnityEvent ParedEvent; //Importante hacer esta definción
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag ==  "Player")
        {
          ParedEvent.Invoke();
          if(playAuido)
          {
             GetComponent<AudioSource>().Play();
          }
         
         
          // playAuido=false;
          Destroy(clown,5.0f);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
      
       if (collision.gameObject.tag ==  "Player")
        {
          playAuido = false;
        }

    }
}
