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

    void Start()
    {
        
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

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 primaryCoord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(primaryCoord.x);
            var absY = Mathf.Abs(primaryCoord.y);

            if (absX > absY)
            {
                //Right
                if (primaryCoord.x > 0)
                {
                    dirX = 1;
                }//Left
                else
                {
                    dirX = -1;
                }
            }
            else
            {
                if(primaryCoord.y > 0)
                {
                    dirZ = 1;
                }
                else
                {
                    dirZ = -1;
                }
            }
        }
        Vector3 moveDir = new Vector3(dirX * speedForward, 0, dirZ * speedSide);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }
}
