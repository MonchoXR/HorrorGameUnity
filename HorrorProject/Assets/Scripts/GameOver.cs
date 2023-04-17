using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
        public AudioClip _audioGameOver;
      public GameObject gameOver;

bool restart;
      bool isOver = true;

    // Update is called once per frame
    void Update()
    {
        if( PlayerFPS.vidaJugador <= 0  &&isOver)
        {
    
  
     

         Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SonidoGlobal._audioSourceBlobal.clip=_audioGameOver;
        SonidoGlobal._audioSourceBlobal.Play();
        gameOver.SetActive(true);
          Time.timeScale =0.0f;
         isOver=false;
     
        }
      
    }


}
