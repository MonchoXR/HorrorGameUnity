using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoGlobal : MonoBehaviour
{
 public static AudioSource _audioSourceBlobal;
 public AudioClip _clip_HorrorHouse;

 public void Start() {

    _audioSourceBlobal=GetComponent<AudioSource>();
    _audioSourceBlobal.clip = _clip_HorrorHouse;
    _audioSourceBlobal.Play();
 }
}
