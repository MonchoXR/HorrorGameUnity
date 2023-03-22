using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : Enemy
{
     public AudioClip _clipManHurt;
      public AudioClip _clownNoise;
    public override void Start()
    {
        base.Start();
        // 

          
    }
    // public override void Update() {


    // }
    public override void AudioPlay(AudioClip _clipTest)
    {
         _audioSource.clip = _clipTest;
         _audioSource.Play();
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
    void test(){
         PlayerFPS.vidaJugador-=25f;
         AudioPlay(_clipManHurt);
   
    }

     public override void EnemyNavMesh(bool follow)
    {
        if(follow){
            agent.SetDestination(player.transform.position);
            anim.SetBool("Run",true);
            AudioPlay(_clownNoise);
        }
    }



}
