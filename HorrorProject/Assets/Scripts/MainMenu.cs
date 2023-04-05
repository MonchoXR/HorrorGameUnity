using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
  public void Jugar()
  {
    SceneManager.LoadScene(1);
    Debug.Log("Entro Scene");
  
  }

  public void Salir()
  {
    Application.Quit();
  }
}
