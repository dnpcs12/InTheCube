using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    
    private void Start()
    {
        Destroy(gameObject, lifetime);
        GetComponent<Rigidbody>().AddForce(transform.up * speed);


    }

    virtual protected void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
    }

}
