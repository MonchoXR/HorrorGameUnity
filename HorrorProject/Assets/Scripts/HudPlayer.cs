using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudPlayer : MonoBehaviour
{
    public Image barraVida; //verde
     public Image FrameVida;
     public GameObject FrameVidaObject;
    float vidaActual;
   
    // float MaxVidaFrame=255f;
    float MaxVidaBarra=100f;

    // Start is called before the first frame update
    void Start()
    {
        MaxVidaBarra = PlayerFPS.vidaJugador;
        FrameVidaObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        vidaActual = PlayerFPS.vidaJugador;

        //Bara vida
        barraVida.fillAmount = vidaActual/MaxVidaBarra;
       

       //Frame Vida
        float valor=1-vidaActual/MaxVidaBarra;
  
        FrameVida.color = new Color(255f,255f,255f,valor);
    }
}
