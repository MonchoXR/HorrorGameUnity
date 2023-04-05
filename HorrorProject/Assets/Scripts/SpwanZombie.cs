using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanZombie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Zombie;
    public Transform[] poitTransform;
    GameObject ZombienInstantie;
    int contaAudio= 0;
    public static int vidaZombie = 3;

    
    Transform currentPoint;
    int index;

    public void SpawnZombie()
    {

            ZombienInstantie = Instantiate(Zombie, currentPoint.position, currentPoint.rotation);
            ZombienInstantie.GetComponent<FemaleZombie>().activeSpawnAudio(contaAudio);
            contaAudio++;
    }

    public  void Start() {

        index = Random.Range (0, poitTransform.Length);
        currentPoint = poitTransform[index];

        SpawnZombie();
        
    }

    void Update()
    {

        
        if(vidaZombie == 0)
        {
            ZombienInstantie.GetComponent<FemaleZombie>().anim.SetTrigger("died");
            ZombienInstantie.GetComponent<CapsuleCollider>().enabled= false;
        }
        else if (ZombienInstantie == null)
        {
            SpawnZombie();
        }
        else
            if (ZombienInstantie.GetComponent<FemaleZombie>().activeFinalPoint)
        {

            Destroy(ZombienInstantie, 4.0f);
    
        }


    }

  
}
