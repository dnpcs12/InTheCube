using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyGrabbable : OVRGrabbable
{

    [System.Serializable]
    public class OnActiveEvent : UnityEvent { };

    public OnActiveEvent onActive;

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
