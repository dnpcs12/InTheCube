using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    Rigidbody rigidbody;
    public Vector3 maxScale = new Vector3(0.8f, 0.8f, 0.8f);
    bool isAttach = false;

    bool isSnowBallContact = false;
    Collision opponentCol;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    public void AttachSnowManHead()
    {

        if (!isSnowBallContact) return;


        print("붙임");
        
        transform.position = opponentCol.transform.position + new Vector3(0,transform.localScale.y,0);
        transform.SetParent(opponentCol.transform);
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.freezeRotation = true;
        isAttach = true;

        //hit.collider.GetComponent<Rigidbody>().isKinematic = true;

        /*
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = Vector3.down;

       
        if (Physics.Raycast(ray,out RaycastHit hit,5f ,LayerMask.NameToLayer("Grab")))
        {
          
            if (hit.collider != null)
            {
                print("머리 붙여보쟈" + name + " " + hit.collider.name );
                if (hit.collider.tag != "SnowBall") return;

                print("붙임");
                transform.position = hit.transform.position + new Vector3(0, hit.transform.localScale.y,0);
                rigidbody.isKinematic = true;
                rigidbody.velocity = Vector3.zero;
                hit.collider.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        */
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
            opponentCol = null;
        }
    }

}
