using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeveralFunctions : MonoBehaviour
{
    public void OnorOff()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
