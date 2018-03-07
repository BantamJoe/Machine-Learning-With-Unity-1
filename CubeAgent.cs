using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeAgent : Agent {

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

	int solved;


	public override List<float> CollectState()
	{
		// Distance to goal.
		GameObject _Goal = GameObject.FindGameObjectWithTag ("END");
		float _dist = Vector3.Distance (_Goal.transform.position, cube.transform.position);

		List<float> state = new List<float> ();
		state.Add (isAlive);
		state.Add (foundEnd);
		state.Add (cube.transform.position.x);
		state.Add (cube.transform.position.y);
		state.Add (cube.transform.position.z);
		state.Add (_dist);
		return state;

	}

	public override void AgentReset(){
	
		cube.transform.position = new Vector3 (0f,0f,0f);
		isAlive = 1;
		foundEnd = 0;
	
	}


	public override void AgentStep(float[] action)
	{

		reward -= .01f;

		GameObject _Goal = GameObject.FindGameObjectWithTag ("END");
		float beforeDist = Vector3.Distance (_Goal.transform.position, cube.transform.position);

		if (text != null)
			text.text = string.Format ("Score:{0} | Status:{1} | S: {2}", reward, isAlive, solved);

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
		default:
			return;

			}

		float afterDist = Vector3.Distance (_Goal.transform.position, cube.transform.position);




		  if (isAlive == 0) 
		{
		
			reward -= 1f;
			done = true;
			return;
		
		}
			


		if (afterDist < beforeDist) {
			reward += .02f;
		}

			
		if (foundEnd == 1) {
			solved++;
			reward += 100f;

			done = true;
			return;

		} 
			

		return;
					



			
	
	}

}
