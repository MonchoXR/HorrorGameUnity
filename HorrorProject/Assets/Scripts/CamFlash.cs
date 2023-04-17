using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFlash : Weapon
{
    public GameObject camFlash;
    public Camera fpscam;
     public float range = 100f;

     bool isFirstScream = true;
    public Light flashLight;
    bool isReadyToFlash=true;

    public GameObject hudKillClownTutorial;
    public GameObject NoBatteries;
    public GameObject batteryHub1;
    public GameObject batteryHub2;
    public GameObject batteryHub3;
    public GameObject batteryHub4;
    public GameObject batteryHub5;
    public GameObject batteryHub6;

    int vidaZombieCurrent;

  

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
           if (Input.GetMouseButtonDown(0) &&  PlayerCharacter.GetComponent<Animator>().GetBool("bToTorch")&& isReadyToFlash==true &&  GetComponent<PlayerFPS>().totalBattery>0)
         
        {

            Disparar();
            isReadyToFlash=false;

            int totalCount= GetComponent<PlayerFPS>().totalBattery;
            GetComponent<PlayerFPS>().totalBattery--;
            GetComponent<PlayerFPS>()._inventarioBattery.RemoveAt(totalCount-1); //Actualizamos Inventario Battery
            
            StartCoroutine(ReadyShootFlash());


        }
        else {
           
        }
           HudBatteries();

    }

    void Disparar()
    {

        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log("Disparo en " + hit.collider.gameObject.name);
            if (hit.collider.name == "FemaleZombieFirst" && GetComponent<HudPlayer>().existClown==false)
            {

                hit.collider.GetComponent<Animator>().SetTrigger("FirstScream");
                if (isFirstScream)
                {
                    hit.collider.GetComponent<FemaleZombie>().activeScreamAudio();
                }

                isFirstScream = false;
            }
            else if(hit.collider.name == "FemaleZombieFirst" && GetComponent<HudPlayer>().existClown==true){
                hudKillClownTutorial.SetActive(true);
                 StartCoroutine(killClownFisrt());
            }

            if (hit.collider.tag == "ZombieFemale" &&  hit.collider.GetComponent<Animator>().GetBool("isShooted")==false)
            {
                
                hit.collider.GetComponent<Animator>().SetBool("isShooted",true);
                 hit.collider.GetComponent<FemaleZombie>().activeShootedAudio();
                hit.collider.GetComponent<ChangeMatarialZombie>().NormalMaterialZombie();
                hit.collider.GetComponent<FemaleZombie>().agent.speed = 0.0f;
                SpwanZombie.vidaZombie--;

            }
        }
        camFlash.GetComponent<AudioSource>().Play();
        flashLight.enabled = true;
        StartCoroutine(FlashEnable());
    }

    IEnumerator FlashEnable()
    {

        yield return new WaitForSeconds(0.5f);
        flashLight.enabled = false;

    }

    
    IEnumerator ReadyShootFlash()
    {

        yield return new WaitForSeconds(3.0f);
        isReadyToFlash= true;

    }

    IEnumerator killClownFisrt()
    {

        yield return new WaitForSeconds(2.0f);
        hudKillClownTutorial.SetActive(false);

    }



    void HudBatteries()
    {
         if(GetComponent<PlayerFPS>().totalBattery ==0)
            {
                NoBatteries.SetActive(true);
                batteryHub1.SetActive(false);
                batteryHub2.SetActive(false);
                batteryHub3.SetActive(false);
                batteryHub4.SetActive(false);
                batteryHub5.SetActive(false);
                batteryHub6.SetActive(false);
                GetComponent<PlayerFPS>().HudFullBatteriesTutorial.SetActive(false);
                
            }

        
            if(GetComponent<PlayerFPS>().totalBattery ==1)
            {
                NoBatteries.SetActive(false);
                batteryHub1.SetActive(true);
                batteryHub2.SetActive(false);
                batteryHub3.SetActive(false);
                batteryHub4.SetActive(false);
                batteryHub5.SetActive(false);
                batteryHub6.SetActive(false);
                GetComponent<PlayerFPS>().HudFullBatteriesTutorial.SetActive(false);
            }
             if(GetComponent<PlayerFPS>().totalBattery ==2)
            {
                NoBatteries.SetActive(false);
                batteryHub1.SetActive(true);
                batteryHub2.SetActive(true);
                batteryHub3.SetActive(false);
                batteryHub4.SetActive(false);
                batteryHub5.SetActive(false);
                batteryHub6.SetActive(false);
                GetComponent<PlayerFPS>().HudFullBatteriesTutorial.SetActive(false);
            }
             if(GetComponent<PlayerFPS>().totalBattery ==3)
            {
                NoBatteries.SetActive(false);
                batteryHub1.SetActive(true);
                batteryHub2.SetActive(true);
                batteryHub3.SetActive(true);
                batteryHub4.SetActive(false);
                batteryHub5.SetActive(false);
                batteryHub6.SetActive(false);
                GetComponent<PlayerFPS>().HudFullBatteriesTutorial.SetActive(false);
            }
             if(GetComponent<PlayerFPS>().totalBattery ==4)
            {
                NoBatteries.SetActive(false);
                batteryHub1.SetActive(true);
                batteryHub2.SetActive(true);
                batteryHub3.SetActive(true);
                batteryHub4.SetActive(true);
                batteryHub5.SetActive(false);
                batteryHub6.SetActive(false);
                GetComponent<PlayerFPS>().HudFullBatteriesTutorial.SetActive(false);
            }

              if(GetComponent<PlayerFPS>().totalBattery ==5)
            {
                NoBatteries.SetActive(false);
                batteryHub1.SetActive(true);
                batteryHub2.SetActive(true);
                batteryHub3.SetActive(true);
                batteryHub4.SetActive(true);
                batteryHub5.SetActive(true);
                batteryHub6.SetActive(false);
                GetComponent<PlayerFPS>().HudFullBatteriesTutorial.SetActive(false);
            }

                if(GetComponent<PlayerFPS>().totalBattery ==6)
            {
                NoBatteries.SetActive(false);
                batteryHub1.SetActive(true);
                batteryHub2.SetActive(true);
                batteryHub3.SetActive(true);
                batteryHub4.SetActive(true);
                batteryHub5.SetActive(true);;
                batteryHub6.SetActive(true);
                GetComponent<PlayerFPS>().HudFullBatteriesTutorial.SetActive(true);

            }

    }



}
