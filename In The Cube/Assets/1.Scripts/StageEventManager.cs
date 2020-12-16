using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageEventManager : MonoBehaviour
{
    private static StageEventManager _instance;
    public static StageEventManager instance
    {
        get => _instance;
        set
        {
            if (!_instance)
            {
                _instance = value;
            }
        }
    }
    private void Awake()
    {
        instance = this;
    }

    [System.Serializable]
    public class Event : UnityEvent { };

    public Event[] events;
  
    public void InvokeEvent(int num)
    {
        events[num].Invoke();
    }
}
