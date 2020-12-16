using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    Rigidbody rigidbody;
    public Vector3 maxScale = new Vector3(0.8f, 0.8f, 0.8f);
    static bool isAttach = false;

    bool isSnowBallContact = false;
    Collision opponentCol;
    public GameObject snowMan;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    public void AttachSnowManHead()
    {

        //if (!isSnowBallContact) return;


        print("붙임");
        
        transform.position = opponentCol.transform.position + new Vector3(0,transform.localScale.y,0);
        //transform.SetParent(opponentCol.transform);
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.freezeRotation = true;
        isAttach = true;
 
    }

    public void SetStop() {

        rigidbody.velocity = Vector3.zero;
    }

    private void Update()
    {
       // if (rigidbody.isKinematic) return;

        if(rigidbody.velocity.x > 0f || rigidbody.velocity.z > 0 && !isSnowBallContact)
        {
            if(transform.localScale.x < maxScale.x)
            transform.localScale += Vector3.one * 0.01f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag + " " + isAttach);
        
        if(other.tag == "Box")
        {
            Instantiate(snowMan,new Vector3(transform.position.x,0,transform.position.z), Quaternion.Euler(new Vector3(0,180,0)));
            transform.parent.gameObject.SetActive(false);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isSnowBallContact && collision.gameObject.tag == "SnowBall")
        {
            isSnowBallContact = true;
            rigidbody.velocity = Vector3.zero;
            rigidbody.isKinematic = true;
            opponentCol = collision;
        }
        else if(!isAttach && collision.gameObject.layer == LayerMask.NameToLayer("Hand"))
        {
            rigidbody.isKinematic = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (isSnowBallContact && collision.gameObject.tag == "SnowBall")
        {
            isSnowBallContact = false;
            //rigidbody.isKinematic = false;
        
        }
    }

}
