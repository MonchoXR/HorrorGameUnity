using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{
    public Light lamp1;
    public Light lamp2;
    public Light lamp3;
    public Light lamp4;
    public Light lamp5;
    public Light lamp6;

    public AudioSource _audioSource;
    public AudioClip _turnOffLight;
    public bool timerActive = false;
    bool locklight=false;
    public float timeLamp;

    // Start is called before the first frame update
    void Start()
    {
   
        _audioSource.clip = _turnOffLight;
   
    }

    // Update is called once per frame
    void Update()
    {
          
        if(timerActive == true ){
            timeLamp+= Time.deltaTime;
            LampOff(); 
           
        }
      
    }

    void LampOff(){
  
          
       if(timeLamp >= 0.0f &&  lamp1.enabled ==true){
            lamp1.enabled = false;
             _audioSource.Play();
        }    

        if(timeLamp>=0.5f && lamp2.enabled ==true){
         
            lamp2.enabled = false;
            _audioSource.Play();
   
        }
        if(timeLamp>=1.0f && lamp3.enabled ==true){
          
            lamp3.enabled = false;
            _audioSource.Play();
        }

        if(timeLamp>=1.5f && lamp4.enabled ==true){
    
            lamp4.enabled = false;
            _audioSource.Play();
        }

        if(timeLamp>=2.0f && lamp5.enabled ==true){
      
            lamp5.enabled = false;
            _audioSource.Play();
        }

         if(timeLamp>=2.5f ){
            lamp6 .enabled = enabled;
            timerActive= false;
        }
           
    }
}
