using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyGrabbable : OVRGrabbable
{

    [System.Serializable]
    public class OnActiveEvent : UnityEvent { };
    [System.Serializable]
    public class OnGrabEvent : UnityEvent { };
    [System.Serializable]
    public class OffGrabEvent : UnityEvent { };

    public OnActiveEvent onActive;
    public OnGrabEvent beginGrab;
    public OffGrabEvent endGrab;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        beginGrab.Invoke();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        endGrab.Invoke();
    }

    private void Update()
    {
        
        if (isGrabbed)
        {
            if (grabbedBy.GetController()== OVRInput.Controller.LTouch)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    onActive.Invoke();
                }

            }
            else if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                onActive.Invoke();
            }
            
        }
    }
}
