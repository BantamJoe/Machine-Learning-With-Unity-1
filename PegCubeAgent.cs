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
	public float closestWall = 100.0f;

	[SerializeField]
	private float Speed = 10;

	[SerializeField]
	private Text text;

	[SerializeField]
	private GameObject cube;

	//private _StartPosition = new Vector3(0f,-2.962389f,-1.2f);

	int solved;


	public override List<float> CollectState()
	{
		// Distance to goal.
		GameObject _Goal = GameObject.FindGameObjectWithTag ("END");
		float _dist = Vector3.Distance (_Goal.transform.position, cube.transform.position);

		GameObject _Start = GameObject.Find ("START");

		float _distToBegining = Vector3.Distance (_Start.transform.position,cube.transform.position);

		List<float> state = new List<float> ();
		state.Add (isAlive);
		state.Add (_distToBegining);
		state.Add (foundEnd);
		state.Add (cube.transform.position.x);
		state.Add (cube.transform.position.y);
		state.Add (cube.transform.position.z);
		state.Add (closestWall);
		state.Add (_dist);
		return state;

	}

	public override void AgentReset(){

		cube.transform.position = new Vector3 (0f,-2.962389f,-1.2f);
		isAlive = 1;
		foundEnd = 0;
		closestWall = 100.0f;
	
	}


	public override void AgentStep(float[] action)
	{

		reward -= .01f;

		GameObject[] _WALLS;
		_WALLS = GameObject.FindGameObjectsWithTag ("KILL");
	
		float dist = Mathf.Infinity;
		Vector3 position = transform.position;



		foreach (GameObject Wall in _WALLS) {
			
			Vector3 diff = Wall.transform.position - position;
			float curD = diff.sqrMagnitude;
			if (curD < dist)
			{
				
				dist = curD;
			}

			closestWall = dist;
		}


		GameObject _Goal = GameObject.FindGameObjectWithTag ("END");
		GameObject _Start = GameObject.Find ("START");


		float beforeDist = Vector3.Distance (_Goal.transform.position, cube.transform.position);
		float beforeDist2 = Vector3.Distance (_Start.transform.position, cube.transform.position);

		if (text != null)
			text.text = string.Format ("Closest Wall:{0}", closestWall);

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
		float afterDist2 = Vector3.Distance (_Start.transform.position, cube.transform.position);






		  if (isAlive == 0) 
		{
		
			reward -= 100f;
			done = true;
			return;
		
		}


			


		 if  (closestWall < 7.5f)
			reward -= .5f;
		

		//Negative progress closer to begninig or farther away from goal
		if (afterDist2 < beforeDist2 && afterDist > beforeDist) 
		{
			reward -= 1f;
		}




		// Making progress: closer to goal & Farther away from begining
		if (afterDist2 > beforeDist2) {
			// Away from walls
			if (afterDist < beforeDist) {
				if (closestWall > 7.5f) {
					// And making progressive away from where we started
					reward += 4f;
				} else
					reward += 2f;
			} else
				reward += .01f;
		} 

		if (afterDist < beforeDist && afterDist2 < beforeDist2) {
			if (closestWall > 7.5f) {
				// And making progressive with no close wall.
				reward += 2f;
			} else 
			{
				reward += 1f;
			}
			

		}

			
		if (foundEnd == 1) {
			solved++;
			reward += 300f;

			done = true;
			return;

		} 
			

		return;
					



			
	
	}

}
