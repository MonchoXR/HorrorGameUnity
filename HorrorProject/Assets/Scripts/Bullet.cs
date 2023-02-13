using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dirBullet;
  public float TimeDestroy=4f;
  public float speed;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirBullet*speed*Time.deltaTime);
        Destroy(gameObject,TimeDestroy);

       
    }
}
