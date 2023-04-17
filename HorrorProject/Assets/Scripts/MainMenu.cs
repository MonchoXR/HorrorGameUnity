using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  


  public void Jugar()
  {
    SceneManager.LoadScene(1);
  }

  public void Salir()
  {
    Application.Quit();
  }

  public void Restart()
  {

      PlayerFPS.vidaJugador=100;
      SpwanZombie.vidaZombie=3;
      Enemy.numeroClowns=6;
    //  SceneManager.LoadScene(1);
    
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       Time.timeScale =1.0f;
  }

  public void MenuPrincipal()
  {
      PlayerFPS.vidaJugador=100;
      SpwanZombie.vidaZombie=3;
      Enemy.numeroClowns=6;
     
    SceneManager.LoadScene(0);
      Time.timeScale =1.0f;
  }
}
