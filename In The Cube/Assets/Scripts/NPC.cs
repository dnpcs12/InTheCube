using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool isPlayer;
    // Start is called before the first frame update
    public int speedForward;
    public int speedSide;
    private float dirX = 0;
    private float dirZ = 0;
    private float dirY = 0;
    public OVRCameraRig cameraRig;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlayer == isPlayer)
        {
            Movement();
        }
    }

    void Movement()
    {
        dirX = 0;
        dirZ = 0;
        dirY = 0;

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 primaryCoord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
   
            if (primaryCoord.magnitude > 0.0001f)
            {
                Vector3 dir = Quaternion.Euler(0.0f, cameraRig.centerEyeAnchor.rotation.eulerAngles.y, 0.0f)* new Vector3(primaryCoord.x,0,primaryCoord.y);
                print(primaryCoord+" ,"+ dir);
                dirX = dir.x;
                dirZ = dir.z;

            }
            Vector2 secondaryCoord = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            if (secondaryCoord.magnitude > 0.0001f)
            {
                if(secondaryCoord.y > 0)
                {
                    dirY = 1;
                }
                else
                {
                    dirY = -1;
                }
            }


        }
        Vector3 moveDir = new Vector3(dirX * speedForward, dirY, dirZ * speedSide);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }
}
