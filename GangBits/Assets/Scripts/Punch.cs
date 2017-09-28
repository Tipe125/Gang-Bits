using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {
    // Use this for initialization
    public Transform secondpoint;
    //private bool punch = false;
    private Vector3 position1;
	void Start () {
    }
    
    // Update is called once per frame
    void Update () {
            position1 = transform.position;

            var x = Time.deltaTime * 150.0f;
           // var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            
            //transform.Translate(0, 0, z);


        if (Input.GetButton("e")) //Rotation Clockwise
        {
            transform.RotateAround(transform.parent.position, Vector3.back, 180 * Time.deltaTime);
        }

        if (Input.GetButton("q")) //Rotation Counterclockwise
        {
            transform.RotateAround(transform.parent.position, Vector3.back, -180 * Time.deltaTime);
        }
        var punchX = Time.deltaTime * 3.0f;
        if (Input.GetButton("w")) //Punch
        {
           // if (punch == false)
           // {
                //print("false");
               
                position1.x = Mathf.Lerp(transform.position.x, secondpoint.position.x, Time.deltaTime * 3.0f);

                transform.position = position1;
               // punch = true;
          //  }
            //else if (punch == true)
           // {
               // print("true");
                
                position1.x = Mathf.Lerp(secondpoint.position.x, transform.parent.position.x, Time.deltaTime * 3.0f);

                transform.position = position1;
              //  punch = false;
 
                
           // }


        }
    }
}
