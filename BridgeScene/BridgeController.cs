using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour {

	public GameObject Bridge;
	public float bridgeMoved = 0f;

	private float speed = 100f;




	void OnCollisionEnter (Collision col){


		if (col.gameObject.tag == "agent") {
			moveBridge ();
		}


	}


	void moveBridge(){
		if (bridgeMoved == 0) {

			float step = speed * Time.deltaTime;
			Bridge.transform.position = new Vector3 (-2.8274f, -14.718f, 28.82f);
			//Bridge.transform.position = Vector3.MoveTowards (Bridge.transform.position, new Vector3(-2.8274f, -14.718f, 28.82f), step);
			bridgeMoved = 1f;
		}


	}

}
