using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    private bool pauseActiva;
    public GameObject menuPausa;
     public GameObject menuHud;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pauseActiva);
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
    }
    void ResumirJuego()
    {
        menuPausa.SetActive(false);
        menuHud.SetActive(true);
        pauseActiva = false;
        Time.timeScale =1f;
    }

 
    
}
