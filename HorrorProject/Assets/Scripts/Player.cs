using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject Bullet = null;
      
    public Transform posSpawn;
    public float velocidadJugador;
    private float velocidadPlayerOri;
      public float velocidadRotJugador;
    // Start is called before the first frame update
    public GameObject CamOne;
    public GameObject CameTwo;
     public float horSpeed = 2.0f;

     public Animator anim;
     

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.KeypadEnter)){
            ToggleCamera();
        }

        
         float h = horSpeed * Input.GetAxis("Mouse X");
         transform.Rotate(0, h*velocidadRotJugador, 0);

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Disparo();
        // }

        if(Input.GetKeyDown(KeyCode.F)){
            anim.SetTrigger("GrabTorch");
     
        }
    }

    void Movement(){
          float hor= Input.GetAxis("Horizontal");
        float ver= Input.GetAxis("Vertical");
        Vector3 movJugador = new Vector3(hor,0,ver);

    
        if(hor !=0 || ver !=0){
            anim.SetFloat("HorizontalAnim",ver);
            anim.SetFloat("VerticalAnim",hor);
        }
        else{
        
        }

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


        void Disparo(){
          Instantiate(Bullet, posSpawn.position, transform.rotation);
      
    }

   


}
