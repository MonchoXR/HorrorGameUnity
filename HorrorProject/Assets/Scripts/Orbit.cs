
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public float xSpread;
	public float zSpread;
	public float yOffset;
	public Transform centerPoint;

	public float rotSpeed;
	public bool rotateClockwise;
	bool zoom=false;
	float timer = 0;
	float z;
	public float speedZoom;

	public GameObject background2;
	public Transform PointZoom;
	public AudioSource _audioSource;
	public GameObject SoundSpark;
	public AudioClip _clipSpark;
	public AudioClip _Painting;
	 bool spark=false;
	// Update is called once per frame
	void Start() {
		StartCoroutine(WaithZoom());	
		SoundSpark.GetComponent<AudioSource>().Play();
		// StartCoroutine(WaithZoomIn());	
	}
	void Update () {
		timer += Time.deltaTime * rotSpeed;
		if(zoom == false)
		{
			Rotate();	
		}
		else{
			Rotate2();
			Debug.Log("entreo rotato2");
		}
		
	}

	void Rotate() {
		if(rotateClockwise) {
			
	
			float x = -Mathf.Cos(timer) * xSpread;
			 z = Mathf.Sin(timer) * zSpread;
			 float newz = Mathf.Clamp(z, 0, zSpread-5);
			
			 Debug.Log(newz);
			if((newz >= 25f || newz <=1f) && spark==false ){
				SoundSpark.GetComponent<AudioSource>().Stop();
				spark=true;
			}
            else if ((newz <= 24f || newz >=2f) && spark == true)
            {
                SoundSpark.GetComponent<AudioSource>().Play();
                spark = false;
            }
			
			Vector3 pos = new Vector3(x, yOffset, newz);
			transform.position = pos + centerPoint.position;
		} else {
			float x = Mathf.Cos(timer) * xSpread;
			z = Mathf.Sin(timer) * zSpread;
			Vector3 pos = new Vector3(x, yOffset, z);
			transform.position = pos + centerPoint.position;
		}
	}


	void Rotate2() {
		if(rotateClockwise) {
			
			 transform.position = Vector3.MoveTowards(transform.position, PointZoom.transform.position, speedZoom*Time.deltaTime);
	
		}
	}
	IEnumerator WaithZoom()
	{	
	// 	while(true)
	// 	{
			yield return new WaitForSeconds(18f);
			Debug.Log("entre zoom");
			
			background2.SetActive(true);

			AudioPlay(_Painting);
			zoom=true;
			SoundSpark.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(2.0f);
			Debug.Log("entre zoomin");
			
			background2.SetActive(false);
			
			zoom=false;

		// }
				StartCoroutine(WaithZoom());	
		
	}

	

      void AudioPlay(AudioClip _clipTest)
    {
        _audioSource.clip = _clipTest;
        _audioSource.Play();
    }


}


