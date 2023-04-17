using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ScaredFloorCollision : MonoBehaviour
{
     [SerializeField] private UnityEvent FloorEvent; 

     public void OnCollisionEnter(Collision collision)
 {

         if (collision.gameObject.tag ==  "Player")
        {
            FloorEvent.Invoke();

        }
    }
}
