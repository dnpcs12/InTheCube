using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyName { Do, Re, Mi, Fa, Sol, La, Si };
public class PianoKey : MonoBehaviour
{
    [SerializeField]
    private MusicChecker checker;
    public KeyName note;
    float[] pitchs = { 1, 1.12f, 1.26f, 1.337f, 1.50f, 1.68f, 1.88f };
    AudioSource audio;
    float originPitch;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        originPitch = audio.pitch;
    }

    private void OnCollisionEnter(Collision collision)
    {
     
        if(collision.gameObject.name == "stick")
        {
            audio.pitch = originPitch * pitchs[(int)note];
            audio.Play();
            checker.AddCurKey(note);
        }
        

    }

}
