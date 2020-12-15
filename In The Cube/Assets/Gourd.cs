using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gourd : MonoBehaviour
{
    public int needCount;
    

    private void OnCollisionEnter(Collision collision)
    {
        needCount--;
        if (needCount < 0)
        {
            StageEventManager.instance.InvokeEvent(1);
        }
    }
}
