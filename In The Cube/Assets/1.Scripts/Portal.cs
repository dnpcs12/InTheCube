using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Material openMaterial;
    private bool _isOpen = true;
    public bool isOpen
    {
        get => _isOpen;
        set
        {
            _isOpen = value;
            if (_isOpen)
            {
                GetComponent<MeshRenderer>().material = openMaterial;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (_isOpen)
            {
                print("on portal");
                GameManager.Instance.MoveNextStage();
            }
        }
    }

}
