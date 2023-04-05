using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
  
    //  public GameObject menuHud;
    //  public GameObject Player;
      public GameObject gameOver;
    //   public GameObject EnemyObject;
bool restart;
      bool isOver = true;
    // Start is called before the first frame update
    // void Awake() {
    //     DontDestroyOnLoad(this.gameObject);
    //         restart = false;
    // }


    // Update is called once per frame
    void Update()
    {
        if( PlayerFPS.vidaJugador == 0  &&isOver)
        {
            Debug.Log("SaliDElMenu");
        //   menuHud.SetActive(false);
  
        //  Time.timeScale =0.0f;
        //  Player.GetComponent<PlayerFPS>().enabled=false;
        //  Player.GetComponent<Gun>().enabled=false;
        //  Player.GetComponent<CamFlash>().enabled=false;
        //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       gameOver.SetActive(true);
        //   SceneManager.LoadSceneAsync(2);

        //   Time.timeScale = 1f;
         isOver=false;
     
        }
    }


}
