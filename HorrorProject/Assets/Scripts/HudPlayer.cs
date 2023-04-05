using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudPlayer : MonoBehaviour
{
    public Image barraVida; //verde
     public Image FrameVida;
     public GameObject FrameVidaObject;
     public TextMeshProUGUI NroJugador;
     public GameObject ZombieObjetivo;
     public GameObject TargetClown;

     public GameObject hudZombie;
     public TextMeshProUGUI vidaZombie;

     public bool existClown = false;
    float vidaActual;

    public GameObject hudObjectiveClownCompleted;
  
   
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

        if(Clown.numeroClowns > 0 )
        {
            NroJugador.text= Enemy.numeroClowns.ToString();
        }
        else if(existClown == true)
        {
            
            TargetClown.SetActive(false);
            hudObjectiveClownCompleted.SetActive(true);
            StartCoroutine(Objective2());
           
        }
        //VidaZombie
        vidaZombie.text = SpwanZombie.vidaZombie.ToString();

        
    }


        	IEnumerator Objective2()
	{	
	
			yield return new WaitForSeconds(2.0f);
            hudObjectiveClownCompleted.SetActive(false);
             ZombieObjetivo.SetActive(true);
             hudZombie.SetActive(true);
              existClown =false;
				
	}

    public void ExistClown(){
        existClown = true;
    }


}
