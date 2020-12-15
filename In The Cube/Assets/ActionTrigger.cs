using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTrigger : MonoBehaviour
{
    [System.Serializable]
    public class OnTriggerEvent : UnityEvent { };
    public string obTag;
    public string obName;

    public OnTriggerEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == obTag || other.name == obName)
        {
            onTrigger.Invoke();
        }
    }
}
