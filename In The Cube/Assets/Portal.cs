using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool _isOpen = false;
    public bool isOpen
    {
        get => _isOpen;
        set
        {
            _isOpen = value;
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
