using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
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
      public float vida = 20f;
      public GameObject explosion;
      public AudioSource _audioSource;
      public AudioClip _clipDead;
     public Animator anim;

     public NavMeshAgent agent;

     Quaternion Orirotation;

     public bool followEnemy= true;
    public virtual void Start()
    {
        velocityToward = velocityTowardOri;
    //   Orirotation = Quaternion.Euler(0, transform.rotation.y, 0);4
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // LookAtPlayer();
        // MoveTowardPlayer();
        
       ChooseEnemy();
      
        VidaEnemy();
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
            // MoveTowardPlayer();
            // LookAtPlayer();
          
            // DistanceBtwObj();
              EnemyNavMesh();
            break;

            default:
            break;
        }
    }

    void VidaEnemy()
    {
        if(vida <=0)
        {
            
            anim.SetTrigger("Died");

            AudioPlay(_clipDead);
         
            // velocityTowardOri=0;
            agent.speed=0.0f;
    
            Destroy(gameObject,4f);
            vida=20f;
        }
    }

      public virtual void AudioPlay(AudioClip _clipTest)
    {
    
    }

    private void EnemyNavMesh()
    {
        if(followEnemy){
        agent.SetDestination(player.transform.position);
        }
    }






  

}
