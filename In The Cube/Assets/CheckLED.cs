using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLED : MonoBehaviour
{
    public enum state {Off,Right,Wrong};

    public Material offMat;
    public Material rightMat;
    public Material wrongMat;

    private MeshRenderer renderer;

    private state _state = state.Off;
    public state State
    {
        get => _state;
        set
        {
            _state = value;
            if (_state == state.Off)
            {
                renderer.material = offMat;
            }
            else if (_state == state.Right) renderer.material = rightMat;
            else renderer.material = wrongMat;
        }
    }
    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }


}
