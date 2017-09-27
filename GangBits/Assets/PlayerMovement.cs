using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rig;

    public float speed = 0.5f;
    public float max_force = 20f;
    public Vector2 moveDirection = Vector2.zero;
    public float jump_height = 2.0f;

    private Vector2 impulse_force = Vector2.zero;
    private float dist_to_ground = 1.0f;
    private float gravity = 9.8f;


    /*.................................................
      IMPULSE BASED X,Y MOVEMENT
      FOR RIGIDBODY
      NO JUMP AS OF YET (well there is, but it's pretty broken)
      .................................................
    */


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.freezeRotation = true;
        rig.drag = 5.0f;
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
                //un-comment this to try to fix the jump
                //moveDirection.y = JumpValue();
            }

            //add force as impulse to the rigidbody
            rig.AddForce(impulse_force, ForceMode.Impulse);
        }

        rig.AddForce(new Vector2(0, -gravity * rig.mass));

    }

    float JumpValue()
    {
        return Mathf.Sqrt(2 * jump_height * gravity);
    }


    public bool isGrounded()
    {
        return Physics.Raycast(rig.transform.position, -Vector2.up, dist_to_ground);
    }

}