using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public enum key {Do, Re, Mi, Fa, Sol, La, Si };

    public key note;
    AudioSource audio;
    float originPitch;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        originPitch = audio.pitch;
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if(other.name == "stick")
        {
            
            audio.pitch = originPitch + 0.11f * (int)note;
            audio.Play();
            print(note);
        }
    }
}
