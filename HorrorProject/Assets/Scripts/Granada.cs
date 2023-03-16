using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public GameObject efectoExplision;

    public float delay; //tiempo para que explote
    public float radius = 20f;
    public float explosionForce= 10f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ExplotarGranada",delay);
    }

    void ExplotarGranada()
    {
        //Chequear los collider cercanos
        Collider[] collider = Physics.OverlapSphere(transform.position, radius);

        //Aplicar para cada Collider
        foreach(Collider near in collider)
        {
           Rigidbody  rb = near.GetComponent<Rigidbody>();

         
            if(rb != null) //Si es que tienen rigiBody
            {
              
                //Agregar fuerza de explision
                rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse );
          
            }

            Enemy destEnemy  = near.GetComponent<Enemy>();
            if(destEnemy!= null)
            {
                destEnemy.vida =-20;
            }
        }
        Instantiate(efectoExplision, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
