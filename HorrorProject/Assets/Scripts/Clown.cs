using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : Enemy
{
     
      public AudioClip _clownNoise;
       public AudioClip _chaseClown;
      
    public override void Start()
    {
        base.Start();
          StartCoroutine(WaitForAttack());

          
    }
   

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            anim.SetTrigger("attack");
            anim.SetBool("Run", false);

            followEnemy = false;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("AtaqueClown"))
            {
                // anim.SetBool("attackFinished", true);
                followEnemy = false;
            }
            else
            {
                // anim.SetBool("attackFinished", false);

            }
        }
    }

    
    private void OnCollisionExit(Collision collision)
    {
    
        if (collision.gameObject.tag == "Player")
        {
           anim.SetBool("Run", true);
             followEnemy = true;
       
          
        }

    }
    void AttackToPlayEventAnimator(){
         PlayerFPS.vidaJugador-=20;
         AudioPlay(_clipManHurt);
   
    }

     public override void EnemyNavMesh(bool followEnemy)
    {
        if(followEnemy){
            agent.SetDestination(player.transform.position);
            anim.SetBool("Run",true);
      
        }
    }


  	IEnumerator WaitForAttack()
	{	
            yield return new WaitForSeconds(7.0f);
            
			followEnemy=true;
            yield return new WaitForSeconds(2.0f);
            AudioPlay(_clownNoise);
            SonidoGlobal._audioSourceBlobal.clip= _chaseClown;
             SonidoGlobal._audioSourceBlobal.Play();
	}

}
