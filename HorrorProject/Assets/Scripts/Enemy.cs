using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeEnemy{
    Enemigo1,Enemigo2
}
public class Enemy : MonoBehaviour
{
      public GameObject player;
      public TypeEnemy enemy;
      public float speedLerpRotation;
      public float velocityTowardOri;
      float velocityToward;
      float dist;
      public float distanceEnemy;

        Quaternion Orirotation;
    // Start is called before the first frame update
    void Start()
    {
        velocityToward = velocityTowardOri;
    //   Orirotation = Quaternion.Euler(0, transform.rotation.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // LookAtPlayer();
        // MoveTowardPlayer();
        ChooseEnemy();
    }

    void LookAtPlayer(){

        // transform.LookAt(player.transform.position);
        Quaternion rotation = Quaternion.LookRotation( player.transform.position - transform.position);
            Orirotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
         transform.rotation = Quaternion.Slerp(transform.rotation, Orirotation, Time.deltaTime * speedLerpRotation);
    }

    void MoveTowardPlayer(){
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocityToward*Time.deltaTime);
    }

    void DistanceBtwObj(){
        dist = Vector3.Distance(transform.position , player.transform.position);
        if(dist <=distanceEnemy){
            velocityToward=0;
        }
        else{
            velocityToward=velocityTowardOri;
        }
    }


    void ChooseEnemy(){
        switch (enemy){
            case TypeEnemy.Enemigo1:
            LookAtPlayer();
            break;
            
            case TypeEnemy.Enemigo2:
            MoveTowardPlayer();
            LookAtPlayer();
            DistanceBtwObj();
            break;

            default:
            break;
        }
    }
}
