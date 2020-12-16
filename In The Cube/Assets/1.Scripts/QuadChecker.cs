using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuadChecker : MonoBehaviour
{
    [System.Serializable]
    public class CompletedEvent:UnityEvent{};
    public Quad[] quad;
    bool isCompleted = false;

    public bool isEventDone = false;

    public CompletedEvent OnEvent;

    

    public void Check()
    {
        if (isEventDone) return; 
        print("check");
        isCompleted = true;
        foreach (var q in quad)
        { 
            if (!q.isOn)
            {
                print(q);
                isCompleted = false;
                break;
            }
        }

        if (isCompleted)
        {
        
            OnEvent.Invoke();
            isEventDone = true;
        }

    }

 
}
