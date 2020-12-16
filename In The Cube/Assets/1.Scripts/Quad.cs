using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{
    QuadChecker quadChecker;
    public string tagName;
    public Material offMaterial;
    public Material onMaterial;
    private bool _isOn;
    public bool isOn
    {
        get
        {
            return _isOn;
        }
        set
        {
            _isOn = value;
            if (_isOn)
            {
              
                renderer.material = onMaterial;
            }
            else
            {
                renderer.material = offMaterial;
            }
            quadChecker.Check();
        }
    }
    MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material = offMaterial;
        quadChecker = transform.parent.GetComponent<QuadChecker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tagName)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == tagName)
        {
            isOn = false;
        }
    }
}
