using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeAgent : Agent {

	[SerializeField]
	public float isAlive = 1;

	[SerializeField]
	public float foundEnd = 0;

	[SerializeField]
	private float Speed = 10;

	[SerializeField]
	private Text text;

	[SerializeField]
	private GameObject cube;

	[SerializeField]
	private GameObject bridgeControl;

	[SerializeField]
	private GameObject bridge;

	int solved;


	// Track Cube positon
	// Track Cube velocity
	// Track goal position
	// Track goal velocity ( when moved )
	// Track if button pressed


	public override List<float> CollectState()
	{

		GameObject _Goal = GameObject.FindGameObjectWithTag ("goal");


		List<float> state = new List<float> ();
	


		state.Add ((cube.transform.position.x)/100);
		state.Add ((cube.transform.position.y)/100);
		state.Add ((cube.transform.position.z)/100);
		state.Add ((cube.transform.GetComponent<Rigidbody>().velocity.x)/100);
		state.Add ((cube.transform.GetComponent<Rigidbody>().velocity.y)/100);
		state.Add ((cube.transform.GetComponent<Rigidbody>().velocity.z)/100);

		state.Add ((_Goal.transform.position.x)/100);
		state.Add ((_Goal.transform.position.y)/100);
		state.Add ((_Goal.transform.position.z)/100);

		state.Add (bridgeControl.GetComponent<BridgeController> ().bridgeMoved);

		return state;

	}

	// Reset to start position
	// Reset bridge and the button.

	public override void AgentReset(){
		
		cube.transform.position = new Vector3 (-3.72f,-13.78f,16.91577f);
		isAlive = 1;
		foundEnd = 0;
		bridge.transform.position = new Vector3 (-2.8274f, -14.718f,32.6f);
		bridgeControl.GetComponent<BridgeController> ().bridgeMoved = 0f;


	}


	public override void AgentStep(float[] action)
	{

		reward -= .01f;



		if (text != null)
			text.text = string.Format ("Bridge Status:{0}", bridgeControl.GetComponent<BridgeController> ().bridgeMoved);

		switch ((int)action[0])

		{
		case 0:

			cube.transform.Translate (0, 0, 1 * Speed * Time.deltaTime);

			break;

		case 1:
			cube.transform.Translate (0, 0, -1 * Speed * Time.deltaTime);

			break;

		case 2:
			cube.transform.Translate (-1 * Speed * Time.deltaTime, 0, 0);

			break;
		case 3:
			cube.transform.Translate (1 * Speed * Time.deltaTime, 0, 0);

			break;
		case 4:
			break;
		default:
			return;

		}
			
		if (cube.transform.position.y < -14f) {
			isAlive = 0;
		}



		if (isAlive == 0) 
		{

			reward -=1f;
			done = true;
			return;

		}
			

		if (bridgeControl.GetComponent<BridgeController> ().bridgeMoved == 1f) {
			reward += .005f;
		}


		if (foundEnd == 1) {
			solved++;
			reward += 1f;

			done = true;
			return;

		} 


		return;






	}

}
