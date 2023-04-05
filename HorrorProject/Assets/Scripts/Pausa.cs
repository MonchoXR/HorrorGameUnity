using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    private bool pauseActiva;
    public GameObject menuPausa;
     public GameObject menuHud;

     public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
        TogglePause();
    }

    void TogglePause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(pauseActiva==true)
            {
                ResumirJuego();
                      
            }    
            else
            {
                PausarJuego();  
            }
           
        }
    }

    void PausarJuego()
    {
        menuPausa.SetActive(true);
        menuHud.SetActive(false);
        pauseActiva =true;
         Time.timeScale =0.0f;
         Player.GetComponent<PlayerFPS>().enabled=false;
         Player.GetComponent<Gun>().enabled=false;
         Player.GetComponent<CamFlash>().enabled=false;
    }
    void ResumirJuego()
    {
        menuPausa.SetActive(false);
        menuHud.SetActive(true);
        pauseActiva = false;
        Time.timeScale =1f;
        Player.GetComponent<PlayerFPS>().enabled=true;
         Player.GetComponent<Gun>().enabled=true;
         Player.GetComponent<CamFlash>().enabled=true;
    }

 
    
}
