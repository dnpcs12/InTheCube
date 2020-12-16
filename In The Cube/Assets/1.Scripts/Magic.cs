using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{

    public float speed;
    public float lifetime;
    public GameObject effect;

    static bool isEffectOn = false;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        GetComponent<Rigidbody>().AddForce(transform.up * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SnowBall")
        {
            if (!isEffectOn)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                isEffectOn = true;
            }
           
            Destroy(gameObject);
        }
 
    }
}
