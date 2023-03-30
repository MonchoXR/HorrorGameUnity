using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanZombie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Zombie;
    public Transform[] poitTransform;
      GameObject ZombienInstantie;
    Transform currentPoint;
    int index;

    public void SpawnZombie()
    {

            ZombienInstantie = Instantiate(Zombie, currentPoint.position, currentPoint.rotation);
       
    }

    public  void Start() {

        index = Random.Range (0, poitTransform.Length);
        Debug.Log(index);
        currentPoint = poitTransform[index];
        SpawnZombie();
    }

     void Update() {

        if (ZombienInstantie != null)
        {
            if (ZombienInstantie.GetComponent<FemaleZombie>().isRunFinalPoint)
            {
                Destroy(ZombienInstantie, 4.0f);
            }
        }
    }
}
