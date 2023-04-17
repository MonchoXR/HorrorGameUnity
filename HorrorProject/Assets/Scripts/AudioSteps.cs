using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSteps : MonoBehaviour
{

        public AudioSource _audioSource;

        bool isMoving = true;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) 
        {
          
           if (isMoving == true)
           {
              _audioSource.Play();
              Debug.Log("Sonido");
              isMoving=false;
           }
        }
        else
        {
           _audioSource.Stop();
           isMoving=true;
        }
    }
}
