using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    public void SoundOn(GameObject obj)
    {
        obj.GetComponent<AudioSource>().enabled = true;
    }
    public void SoundOff(GameObject obj)
    {
        obj.GetComponent<AudioSource>().enabled = false;
    }
}
