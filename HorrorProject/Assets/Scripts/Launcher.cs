using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
 
 public Transform spawnPoint;

 public GameObject grandeObject;

 public float range = 5f;

    void Update()
    {

        if(Input.GetKeyUp(KeyCode.G))
        {
            if(GetComponent<PlayerFPS>().totalGranada>0)
            {
                LanzarGranada();
            }
 
        }

    }

    void LanzarGranada()
    {
        GameObject instanciarGrenade = Instantiate(grandeObject, spawnPoint.position, spawnPoint.rotation);
        instanciarGrenade.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*range, ForceMode.Impulse);
       int totalCount= GetComponent<PlayerFPS>().totalGranada;
       GetComponent<PlayerFPS>().totalGranada--;
       
        GetComponent<PlayerFPS>()._inventarioGranada.RemoveAt(totalCount-1); //Actualizamos Inventario Granada
    }
}
