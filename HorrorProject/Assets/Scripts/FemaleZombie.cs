using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleZombie : Enemy
{
    // public GameObject ParentFemaleZombie;
    // Start is called before the first frame update
    public GameObject finalPoint;

    public int contaAudioClips=0;

    public AudioClip[] _clips;
    public bool activeFinalPoint=false;

    public void activeSpawnAudio(int contaAudioClips)
    {
        AudioPlay(_clips[contaAudioClips]);
       
    }

    public void activeShootedAudio()
    {

        StopAudioAttackAnimatorEvent();
     
        AudioPlay(_clipShooted);

    }
        public void activeScreamAudio()
    {
        AudioPlay(_clipScreaming);
        anim.SetBool("isScreamed",true);

    }

    public void activeRunAnimtor()
    {
        
        transform.parent.gameObject.GetComponent<Animator>().enabled=true;
    }

    public void attackAudioAnimatorEvent()
    {
             PlayerFPS.vidaJugador-=10;
           AudioPlay(_attack);
           if(PlayerFPS.vidaJugador >= 0)
           {
               AudioPlay(_clipManHurt);
           }
         
          
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
    public void ActiveFinalDestinationEvent()
    {   
      
         activeFinalPoint=true;
         
    
    }

   

     public override void EnemyNavMesh(bool followEnemy)
    {
    
    
        if(followEnemy ){
            
            agent.SetDestination(player.transform.position);
            
     
        }
        else{
            // agent.speed=0f;
        }
    
        if(activeFinalPoint)
        {
               
            agent.SetDestination(finalPoint.transform.position);
            agent.speed=90f;
            agent.acceleration=30f;
      
        }
    }

 
  private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player" && anim.GetBool("isShooted")==false)
        {

            anim.SetTrigger("attackFemaleZombie");
               anim.SetBool("attacktoWalk",false);
         
        }   
        else{
        
            anim.SetBool("attacktoWalk",true);
            // followEnemy = false;
            //  agent.speed=0f;   
        }
    }

    
       private void OnCollisionExit(Collision collision)
    {
    
        if (collision.gameObject.tag == "Player" && anim.GetBool("isShooted")==false)
        {
          
            anim.SetBool("attacktoWalk",true);
             followEnemy = true;
            // agent.speed=2f;
            StopAudioAttackAnimatorEvent();
        }

    }



}
