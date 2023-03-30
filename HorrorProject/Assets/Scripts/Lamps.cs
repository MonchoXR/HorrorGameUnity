using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{
    public GameObject lamp1;
    public GameObject lamp2;
    public GameObject lamp3;
    public GameObject lamp4;
    public GameObject lamp5;
    public Light lamp6;

    public AudioSource _audioSource;
    public AudioClip _turnOffLight;
    bool timerActive = false;
    public float timeLamp;

    public bool startClown = false;



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

    public void TimerEventFromWall(bool active){
        timerActive=active;
    }


    void LampOff(){
  
          
       if(timeLamp >= 0.0f &&  lamp1.activeInHierarchy){
            lamp1.SetActive(false);
             _audioSource.Play();
        }    

        if(timeLamp>=0.5f && lamp2.activeInHierarchy){
         
            lamp2.SetActive(false);
            _audioSource.Play();
   
        }
        if(timeLamp>=1.0f && lamp3.activeInHierarchy){
          
            lamp3.SetActive(false);
            _audioSource.Play();
        }

        if(timeLamp>=1.5f && lamp4.activeInHierarchy){
    
            lamp4.SetActive(false);
            _audioSource.Play();
        }

        if(timeLamp>=2.0f && lamp5.activeInHierarchy){
      
            lamp5.SetActive(false);
            _audioSource.Play();
        }

         if(timeLamp>=2.5f ){
            lamp6 .enabled = enabled;
            timerActive= false;
          
        }
           
    }
}
