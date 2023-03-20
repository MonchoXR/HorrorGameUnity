using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFlash : Weapon
{
    public GameObject camFlash;
    public Light flashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
           if (Input.GetMouseButtonDown(0) &&  PlayerCharacter.GetComponent<Animator>().GetBool("bToTorch"))
        {
            Disparar();
            
        }
        else if(!Input.GetMouseButtonDown(0)){
            
        }
    }

    void Disparar()
    {
        Debug.Log("Flash");
        camFlash.GetComponent<AudioSource>().Play();
         flashLight.enabled=true;
       StartCoroutine(WaithZoom());	
    }

    IEnumerator WaithZoom()
    {

        yield return new WaitForSeconds(0.5f);
        flashLight.enabled = false;




    }

}
