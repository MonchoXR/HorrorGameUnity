using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ScaredFloorCollision2 : MonoBehaviour
{
     [SerializeField] private UnityEvent FloorEvent; 

     public GameObject ObjectScared;
  

     public void OnCollisionEnter(Collision collision)
    {

         if (collision.gameObject.tag ==  "Player")
        {
            FloorEvent.Invoke();
            Destroy(ObjectScared,7f);
        }
    }


 





}
