using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidadJugador;
    // Start is called before the first frame update
    public GameObject CamOne;
    public GameObject CameTwo;
   

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space)){
            ToggleCamera();
        }
    }

    void Movement(){
          float hor= Input.GetAxis("Horizontal");
        float ver= Input.GetAxis("Vertical");
        Vector3 movJugador = new Vector3(hor,0,ver);
        transform.Translate(movJugador*velocidadJugador*Time.deltaTime);
    }

     void ToggleCamera(){
        if(CamOne.activeInHierarchy)
        {
            CamOne.SetActive(false);
            CameTwo.SetActive(true);
        }else
        {
            CamOne.SetActive(true);
            CameTwo.SetActive(false);
        }

    }
}
