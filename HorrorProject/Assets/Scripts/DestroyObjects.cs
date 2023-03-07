using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public float tiempo=2f;
    void Start()
    {
        Destroy(gameObject,tiempo);
    }

  
}
