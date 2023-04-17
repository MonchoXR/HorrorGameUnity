using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ParedCollisionEvent :  MonoBehaviour 
{
  public AudioSource _audioSource;
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
    public void DoorNoiseAudio()
    {
      
      StartCoroutine(DoorNoise());

    }

     	IEnumerator DoorNoise()
	{	  
        
            yield return new WaitForSeconds(4.0f);
            _audioSource.Play();

           
            Destroy(this,4f);
	}
}
