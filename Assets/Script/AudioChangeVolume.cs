using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer gruop;
    public string floatParam = "MyExposedParam";

    public void ChangeValue(float f)
    {
        gruop.SetFloat(floatParam, f);
    }
}
