using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Similar to our other collider, except this one also keeps track of our current ground, dangerous ground is punished, good ground 
is rewarded.

*/


public class TrafficColScript : MonoBehaviour {




	void OnCollisionEnter (Collision col)
	{
		// Detect if we hit the goal.

		if (col.gameObject.tag == "PATH")
			GetComponent<TrafficController> ().currentGround = 0;

		if (col.gameObject.tag == "DANGER")
			GetComponent<TrafficController> ().currentGround = 1;


		if(col.gameObject.tag == "END")
		{
			GetComponent<TrafficController> ().foundEnd = 1;
			//foundEnd = 1;
		}
		if (col.gameObject.tag == "MOVING") {
			GetComponent<TrafficController> ().isAlive = 0;
		}
	}

}
