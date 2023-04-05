using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatarialZombie : MonoBehaviour
{
    public GameObject arms;
    public GameObject dress;
     public GameObject eyesLash;
    public GameObject eyes;
    public GameObject hair;
    public GameObject head;
    public GameObject legs;
    public GameObject mouthBot;
    public GameObject mouthTop;
    public GameObject tongue;
    public Material matTransparent;

    public Material body;
     public Material bodyAlpha;

    Renderer RenAdress;
    Material[] matDressArray;
    // Start is called before the first frame update
    void Start()
    {
        NormalMaterialZombie();
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransparentZombie()
    {

        arms.GetComponent<Renderer>().material = matTransparent;

        matDressArray = dress.GetComponent<Renderer>().materials;
        matDressArray[0] = matTransparent;
        matDressArray[1] = matTransparent;
        dress.GetComponent<Renderer>().materials = matDressArray;

        eyesLash.GetComponent<Renderer>().material = matTransparent;
        eyes.GetComponent<Renderer>().material = matTransparent;
        hair.GetComponent<Renderer>().material = matTransparent;
        head.GetComponent<Renderer>().material = matTransparent;
        legs.GetComponent<Renderer>().material = matTransparent;
        mouthBot.GetComponent<Renderer>().material = matTransparent;
        mouthTop.GetComponent<Renderer>().material = matTransparent;
        tongue.GetComponent<Renderer>().material = matTransparent;
        
    }

    public void NormalMaterialZombie()
    {
        arms.GetComponent<Renderer>().material = body;

        matDressArray = dress.GetComponent<Renderer>().materials;
        matDressArray[0] = bodyAlpha;
        matDressArray[1] = body;
        dress.GetComponent<Renderer>().materials = matDressArray;

        eyesLash.GetComponent<Renderer>().material = bodyAlpha;
        eyes.GetComponent<Renderer>().material = body;
        hair.GetComponent<Renderer>().material = bodyAlpha;
        head.GetComponent<Renderer>().material = body;
        legs.GetComponent<Renderer>().material = body;
        mouthBot.GetComponent<Renderer>().material = body;
        mouthTop.GetComponent<Renderer>().material = body;
        tongue.GetComponent<Renderer>().material = body;
    }
}
