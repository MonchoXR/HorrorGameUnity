using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public float range = 100f;
    public Camera fpscam;
    public GameObject impactEffects;    
     public ParticleSystem FlashEffect;      
     public ParticleSystem CasquillosEffects;
     public AudioSource _audioSource;
     public AudioClip _clipDisparo;
     public AudioClip _clip_Hit;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {

            if (hit.transform.tag == "Enemy")
            {
                Debug.DrawRay(fpscam.transform.position, fpscam.transform.forward * 100f, Color.green, 1f, false);
            }
            else
            {
                Debug.DrawRay(fpscam.transform.position, fpscam.transform.forward * 100f, Color.red, 1f, false);
            }
        }
        if (Input.GetMouseButtonDown(0) &&  PlayerCharacter.GetComponent<Animator>().GetBool("bToRifle"))
        {
            Disparar();
       
        }
    }

    void Disparar()
    {
      
        RaycastHit hit;
        AudioPlay(_clipDisparo);
          FlashEffect.Play();
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log("Disparo en " + hit.collider.gameObject.name);
            if(hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<Enemy>().vida -=10f;
                hit.transform.gameObject.GetComponent<Enemy>().followEnemy =true;
                AudioPlay(_clip_Hit);
                 Debug.DrawRay(fpscam.transform.position, fpscam.transform.forward*100f, Color.green,1f,false);
                GameObject impactEnemy = Instantiate(impactEffects, hit.point,Quaternion.LookRotation(hit.normal));
                 
                Destroy(impactEnemy,2f);
            }
        }
    }

    void AudioPlay(AudioClip _clipTest)
    {
        _audioSource.clip = _clipTest;
        _audioSource.Play();
    }
}
