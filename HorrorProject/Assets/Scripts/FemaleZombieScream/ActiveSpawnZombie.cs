using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpawnZombie : MonoBehaviour
{
    public GameObject SpawnZombie;
    // Start is called before the first frame update
    void ActiveSpawnZombieSpawn()
    {
        SpawnZombie.SetActive(true);
    }

  
}
