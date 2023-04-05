using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateAudio : MonoBehaviour
{
    public GameObject audioPanting;
    void DesactiveAudioPanting()
    {
        audioPanting.SetActive(false);
    }
}
