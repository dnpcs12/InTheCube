using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Socket : MonoBehaviour
{
    [System.Serializable]
    public class OnPutEvent : UnityEvent { };

    private bool _isPut;

    public OnPutEvent putEvent;

    public bool isPut
    {
        get => _isPut;
        set
        {
            _isPut = value;
            if (_isPut)
            {
                putEvent.Invoke();
            }
        }
    }

    public string objectTag;
    public string objectName;


    private void OnTriggerStay(Collider other)
    {
        if (!isPut)
        {
            OVRGrabbable grabbable = other.GetComponent<OVRGrabbable>();
            if (grabbable == null) return;

            if (other.tag == objectTag || other.name == objectName)
            {
                if (!grabbable.isGrabbed)
                {
                    isPut = true;
                }

            }
        }
    }
}
