using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Trucks : MonoBehaviour {

	bool isMoving;
	bool isForward;
	float moveDelay;
	float moveCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(moveCounter >= moveDelay){
			isMoving = true;
			
		}
	}
}
