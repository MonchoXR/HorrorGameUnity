using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLookAt();
    }

    void PlayerLookAt(){
        Enemy.transform.LookAt(Player.transform.position);
    }
}
