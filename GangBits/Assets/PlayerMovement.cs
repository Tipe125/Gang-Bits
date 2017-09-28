using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rig;

    public float speed = 5f;
    public float max_force = 20f;
    public Vector2 moveDirection = Vector2.zero;
    public float jump_height = 1.0f;
    public float gravity = 50.0f;

    private Vector2 impulse_force = Vector2.zero;
    private float dist_to_ground = 1.0f;


    /*.................................................
      IMPULSE BASED X,Y MOVEMENT
      (works much better using gamepad)
      .................................................
    */


    void Start()
    {
        //Initialisations
        rig = GetComponent<Rigidbody>();
        rig.mass = 5.0f;
        rig.drag = 5.0f;
        rig.freezeRotation = true;
        rig.useGravity = false;
    }


    //Update is called once per frame
    void FixedUpdate()
    {
        //gain move direction from x axis
        moveDirection.x = (Input.GetAxis("Horizontal"));
        //create impulse force and clamp magnitude to somethign reasonable
        impulse_force = Vector2.ClampMagnitude((speed * moveDirection * rig.mass), max_force);

        if (isGrounded())
        {
            if(Input.GetButton("Jump"))
            {              
                moveDirection.y = JumpValue();
            }
            //add force as impulse to the rigidbody
        }
        else
        {
            //reset y movement so we don't continuously jump
            moveDirection.y = 0;
        }

        rig.AddForce(impulse_force, ForceMode.Impulse);
        rig.AddForce(new Vector2(0, -gravity * rig.mass));
    }


    float JumpValue()
    {
        if(isGrounded())
        {
            return Mathf.Sqrt(2 * jump_height * gravity);
        }
        else
        {
            return 0;
        }
    }


    public bool isGrounded()
    {
        return Physics.Raycast(rig.transform.position, -Vector2.up, dist_to_ground);
    }

}