using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _audioSource;
  
    public AudioClip _clip1;
    public GameObject AudioGO;

    public GameObject Collision2;

    // Update is called once per frame


    void AudioZOmbie() {
        
         _audioSource.PlayOneShot(_clip1,1f);
        //   _audioSource.PlayOneShot(_clip2,1f);
        AudioGO.GetComponent<AudioSource>().enabled=true;
          Collision2.GetComponent<AudioSource>().Stop();
    }
}
