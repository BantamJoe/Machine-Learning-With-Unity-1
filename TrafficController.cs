using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficController : Agent {


	[SerializeField]
	public float isAlive = 1;

	[SerializeField]
	public float currentGround = 0;

	[SerializeField]
	public float foundEnd = 0;

	[SerializeField]
	private float Speed = 10;

	[SerializeField]
	private Text text;

	// Our Cube we are training on
	[SerializeField]
	private GameObject cube;

	int solved;


	/*
	Track:
		12 states.
		Agents status(alive,dead) (0 or 1)
		If agent has found goal (0,1)
		Agents current ground(0,1)
		Agents position(X,Y,Z)
		Cars position  (X,Y,Z )
		current ground (0 or 1)
		distance to goal (single float)
		distance to car	 (single float)

	*/


	public override List<float> CollectState()
	{
		// Distance to goal.
		GameObject _Goal = GameObject.FindGameObjectWithTag ("END");
		float GOAL_DISTANCE = Vector3.Distance (_Goal.transform.position, cube.transform.position);
		GameObject _Car = GameObject.Find ("CAR");
		float CAR_DISTANCE = Vector3.Distance (_Car.transform.position, cube.transform.position);

		//Check wether the car is moving or paused.
		float CAR_STATUS = 0;
		if (_Car.tag == "MOVING") 
		{
			CAR_STATUS = 0;
		}
		if (_Car.tag == "STALLED") 
		{
			CAR_STATUS = 1;
		}


		List<float> state = new List<float> ();
		state.Add (isAlive);
		state.Add (foundEnd);
		state.Add (currentGround);

		state.Add (CAR_STATUS);
		state.Add (_Car.transform.position.x);
		state.Add (_Car.transform.position.y);
		state.Add (_Car.transform.position.z);


		state.Add (cube.transform.position.x);
		state.Add (cube.transform.position.y);
		state.Add (cube.transform.position.z);

		state.Add (GOAL_DISTANCE);
		state.Add (CAR_DISTANCE);

		return state;

	}

	public override void AgentReset(){
		// Starting cordinates on the map
		cube.transform.position = new Vector3 (0.027668f,0.5f,8.431398f);

		isAlive = 1;
		foundEnd = 0;
		currentGround = 0;

	}


	public override void AgentStep(float[] action)
	{


		reward -= .01f;


		GameObject _Car = GameObject.Find ("CAR");
		float CAR_DISTANCE = Vector3.Distance (_Car.transform.position, cube.transform.position);

		GameObject _Goal = GameObject.FindGameObjectWithTag ("END");
		float beforeDist = Vector3.Distance (_Goal.transform.position, cube.transform.position);

		if (text != null)
			text.text = string.Format ("D: {0} | Ground:{1} | Alive{2}", CAR_DISTANCE,currentGround,isAlive);

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

		float afterDist = Vector3.Distance (_Goal.transform.position, cube.transform.position);




		if (transform.position.y != .5)
			isAlive = 0;

		// Punish for dying
		if (isAlive == 0) 
		{

			reward -= 50f;
			done = true;
			return;

		}
		// Punish for being close to a car
		if (CAR_DISTANCE < 1.7) {
			reward -= 15f;
		}

		// Reward being on good ground
		if (currentGround == 0) 
		{
			reward += .02f;

		}
		// Punish being on dangerous grounds.
		if (currentGround == 1) 
		{
			reward -= .1f;
		}

		// Reward or punish based on distance after step
		if (afterDist < beforeDist) {
			reward += .02f;
		}
		if (afterDist > beforeDist) {
			reward -= .02f;
		}
		// Reward for reaching goal
		if (foundEnd == 1) {
			solved++;
			reward += 100f;

			done = true;
			return;

		} 


		return;






	}

}
