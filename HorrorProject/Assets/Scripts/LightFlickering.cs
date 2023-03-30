using System.Collections;
using UnityEngine;
using LightFlickeringSpace;


public class LightFlickering : MonoBehaviour
{
    public bool onStart = true;                     //start flickering on start automatically
    public Light lightSource;                       //the actual light
    
    public bool randomizeFlickerings = true;        //randomize the times of flickerings between two floats
    public float minRandomizeTime = 0.08f;          //the minimum of two floats to randomize between
    public float maxRandomizeTime = 0.3f;           //the maximum of two floats to randomize between

    public float[] flickerings;                     //the amount of flickerings and how long to black out
    public bool loop = true;                        //should the flickerings loop when finished

    public Lights[] lightings;                      //lighting properties (color and material) for each flicker index in manual and random mode
    
    public AudioSource buzzSound;                   //the buzz sound
    public bool playBuzzSound = false;              //should the buzz sound be played on light open

    public bool changeMaterial;                     //should the material be changed on flickering
    public MeshRenderer bulbObject;                 //the object that acts as the bulb, this will have the default material
    public Material newMaterial;                    //the material to change to when flickering

    public bool fadeEffect = false;                 //use the fade effect
    [Range(0f, 1f)] 
    public float fadeSpeed = 0.2f;                  //the speed of the fading effect

    int index;                                      //save the current index
    int arrayLength;                                //cache the length of the flickerings array for better speed
    int randomLightingsIndex;                       //index the lightings class index in random mode
    bool triggered;                                 //flag whether the script has been triggered or not
    float setTime;                                  //the randomized time
    Material defaultMaterial;                       //save the default material of the object
    bool fadeOutColor = false;                      //flag that fading out should occur
    bool fadeInColor = false;                       //flag that fading in should occur
    Color defaultColor;                             //save the default color
    float t = 0;                                    //delta time on lerping
    bool addedCustomMat = false;                    


    void Start()
    {
        if (lightSource == null) {
            Debug.LogWarning("You need to set the Light Source in the inspector");
            return;
        }

        if (onStart) flicker();
    }

    void Update() 
    {
        if (fadeInColor) {
            t += Time.deltaTime / fadeSpeed;
            lightSource.color = Color.Lerp(lightSource.color, defaultColor, t);
            
            if (lightSource.color.Equals(defaultColor)) {
                fadeInColor = false;
                t = 0f;
                defaultColor = lightSource.color;
                OpenLightProperties();
            }
        }

        if (fadeOutColor) {
            Color temp = new Color(0,0,0,255);
            
            t += Time.deltaTime / fadeSpeed;
            lightSource.color = Color.Lerp(defaultColor, temp, t);
            
            if (lightSource.color.Equals(temp)) {
                fadeOutColor = false;
                t = 0f;
                CloseLightProperties();
            }
        }
    }

    //trigger the flickering
    public void flicker()
    {
        if (triggered) return;
        triggered = true;
        index = 0;
        arrayLength = flickerings.Length;
        if (changeMaterial && bulbObject != null) defaultMaterial = bulbObject.material;
        defaultColor = lightSource.color;
        StartCoroutine(OpenLight());
    }

    //stops the flickerings
    public void stopFlickering()
    {
        StopAllCoroutines();
        index = 0;
        triggered = false;
    }

    //enable the light and open the audio
    IEnumerator OpenLight()
    {
        float time;
        addedCustomMat = false;

        //check if randomizer is checked and randomize flickerings if so
        if (randomizeFlickerings) {
            float rnd = Random.Range(minRandomizeTime, maxRandomizeTime);
            time = rnd;
            setTime = rnd;
            loop = true;

            if (lightings.Length != 0){
                if (lightings.Length < index + 1) index = 0;
                lightSource.color = lightings[index].lightColor;
                defaultColor = lightings[index].lightColor;
                if (bulbObject != null && lightings[index].bulbMaterial != null) {
                    addedCustomMat = true;
                }
            }
            
        }else{
            time = flickerings[index];

            if (lightings.Length >= index + 1) { 
                lightSource.color = lightings[index].lightColor;
                defaultColor = lightings[index].lightColor;
                if (bulbObject != null && lightings[index].bulbMaterial != null) {
                    addedCustomMat = true;
                }
            }

            setTime = time;
        }

        yield return new WaitForSeconds(time);
        
        if (fadeEffect) {
            fadeInColor = true;
            OpenLightProperties(true);
        } else { 
            lightSource.enabled = true; 
            OpenLightProperties();
        }
    }

    //close the light and stop audio
    IEnumerator FlickerTimer()
    {
        yield return new WaitForSeconds(setTime);
        
        if (!fadeEffect) {
            lightSource.enabled = false;
            CloseLightProperties();
        } else {
            fadeOutColor = true;
        }
    }

    void OpenLightProperties(bool dontCall = false)
    {
        if (changeMaterial && bulbObject != null && !addedCustomMat) bulbObject.material = defaultMaterial;
        if (addedCustomMat) bulbObject.material = lightings[index].bulbMaterial;

        //play light audio
        if (playBuzzSound) {
            if (buzzSound != null) buzzSound.Play();
            else Debug.LogWarning("Buzz Sound Audio is not set");
        }

        if (!dontCall) StartCoroutine(FlickerTimer());
    }

    void CloseLightProperties()
    {
        if (playBuzzSound) {
            if (buzzSound != null) buzzSound.Stop();
            else Debug.LogWarning("Buzz Sound Audio is not set");
        }

        if (changeMaterial && bulbObject != null && newMaterial != null) {
            bulbObject.material = newMaterial;
        }
        
        if ((index + 1) < arrayLength) {
            index++;
            StartCoroutine(OpenLight());
        }else{
            if (randomizeFlickerings) {
                index++;
                StartCoroutine(OpenLight());
            }
            else
            {
                if (loop) {
                    index = 0;
                    StartCoroutine(OpenLight());
                } 
            }
        }
    }
}
