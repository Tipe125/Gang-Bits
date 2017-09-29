using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_WheelRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z-5);
		
	}
}
