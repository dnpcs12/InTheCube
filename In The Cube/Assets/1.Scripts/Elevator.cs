using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public enum state {Off,Up,Down};
    public float maxH;
    public float minH;
    public float speed;

    int dir = 1;

    private bool _isOn;
    public bool isOn
    {
        get => _isOn;
        set
        {
            _isOn = value;
            if (!_isOn) State = state.Off;
        }
    }

    private state _state = state.Off;
    public state State
    {
        get => _state;
        set
        {
            print(value);
            if (isOn) _state = value;
            else _state = state.Off;
        }
    }

    public void SetToDown()
    {
        State = state.Down;
    }
    public void SetToUp()
    {
        State = state.Up;
    }
    

    // Update is called once per frame
    void Update()
    {

        if (!isOn) return;
        else if (State == state.Up && transform.position.y < maxH)
        {
            dir = 1;
        }
        else if (State == state.Down && transform.position.y > minH) dir = -1;
        else dir = 0;

            transform.Translate(new Vector3(0, speed * dir, 0) * Time.deltaTime);
        
        
    }
}
