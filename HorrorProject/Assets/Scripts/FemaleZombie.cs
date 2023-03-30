using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleZombie : Enemy
{
    // public GameObject ParentFemaleZombie;
    // Start is called before the first frame update
    public GameObject finalPoint;

    public bool isRunFinalPoint=false;
    
    public void activeScreamAudio(){
           AudioPlay(_clipScreaming);
    }
     public void activeShootedAudio(){
           AudioPlay(_clipShooted);
    }

    public void activeRunAnimtor()
    {
        
        transform.parent.gameObject.GetComponent<Animator>().enabled=true;
    }

    public void attackAudioAnimatorEvent()
    {
           AudioPlay(_attack);
    }

       public void StopAudioAttackAnimatorEvent()
    {
           AudioStop();
    }

      public override void Start()
    {
        base.Start();
         finalPoint = GameObject.Find("FinalPoint");

          
    }
    public void FinalDestinationEvent()
    {   
      
         isRunFinalPoint=true;
    
    }

    public void StopZombieFemaleAnimator()
    {
        followEnemy = false;
        
    }

     public override void EnemyNavMesh(bool followEnemy)
    {
    
    
        if(followEnemy ){
            agent.SetDestination(player.transform.position);
            
            // anim.SetBool("Run",true);
            // AudioPlay(_clownNoise);
        }
        else{
            agent.speed=0f;
        }
    
        if(isRunFinalPoint)
        {
               
            agent.SetDestination(finalPoint.transform.position);
            agent.speed=80f;
            agent.acceleration=30f;
      
        }
    }

 
  private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            anim.SetTrigger("attackFemaleZombie");
                anim.SetBool("attacktoWalk",false);
             

            followEnemy = false;
         
        }
    }
    
       private void OnCollisionExit(Collision collision)
    {
    
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Entro Perseguir");
            anim.SetBool("attacktoWalk",true);
             followEnemy = true;
            agent.speed=2f;
          
        }

    }

}
