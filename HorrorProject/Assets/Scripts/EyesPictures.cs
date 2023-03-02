
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesPictures : MonoBehaviour
{
    public GameObject player;
    public float velocityToward;
    float  x,z, y;
    float valueZ;
      float valueX,valueY;
    void Start()
    {      x = transform.position.x;
           z = transform.position.z;
           y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

        void LookAtPlayer(){
         
        Vector3 newPosition = Vector3.MoveTowards(transform.position, player.transform.position, velocityToward*Time.deltaTime);

          valueZ=Mathf.Clamp(newPosition.z,z-0.01f,z+0.03f);
     
           transform.position = new Vector3(x,y, valueZ);

    }
}
