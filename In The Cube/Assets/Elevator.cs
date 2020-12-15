using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxH) isOn = false;
        if (isOn)
        {
            transform.Translate(new Vector3(0, speed * dir, 0) * Time.deltaTime);
        }
        
    }
}
