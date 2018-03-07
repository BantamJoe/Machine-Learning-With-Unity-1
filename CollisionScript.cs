using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {




	void OnCollisionEnter (Collision col)
	{
		// Detect if we hit the goal.


		if(col.gameObject.tag == "END")
		{
			GetComponent<CubeAgent> ().foundEnd = 1;
			//foundEnd = 1;
		}
		if (col.gameObject.tag == "KILL") {
			GetComponent<CubeAgent> ().isAlive = 0;
		}
	}

}
