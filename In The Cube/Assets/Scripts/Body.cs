using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPlayer;
    public GameObject controller;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlayer == isPlayer)
        {
            //transform.position = controller.transform.position;
        }
        
    }
}
