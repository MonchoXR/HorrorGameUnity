using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
      public GameObject PlayerCharacter;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    public virtual void Update()
    {
            if(Input.GetKeyDown(KeyCode.Alpha1) )
        {
             PlayerCharacter.GetComponent<Animator>().SetBool("bToTorch",false);
             PlayerCharacter.GetComponent<Animator>().SetBool("bToRifle",true);
        }

           if(Input.GetKeyDown(KeyCode.Alpha2)  )
        {
             PlayerCharacter.GetComponent<Animator>().SetBool("bToTorch",true);
             PlayerCharacter.GetComponent<Animator>().SetBool("bToRifle",false);
        
        }

       
    }
}
