# Machine-Learning-With-Unity

For this repo we will be working in Unity 2017.3.1f to train on various scenarios with Machine Learning techniques.


And using ML-Agents : https://github.com/Unity-Technologies/ml-agents

Specifically PPO ( Proximal Policy Optimization ) Reinforcement Learning

We use the following in our simulation:
- Jupyter
- Matplotlib
- numpy
- Python 
- CUDA toolkit 9.0
- TensorFlow (1.4) (Training)



We will create a simple maze to begin with , very basic.

The red walls are tagged "KILL" , the green capsul is tagged "END", when our cube encounters collision, we check the tag.

We attach a CollisionScript.cs to our cube, which will work with our CubeAgent.cs class to set its reset parameters when we encounter a wall or a capsul ( end goal )

[![Unity_2018-03-07_01-10-56.png](https://s18.postimg.org/x1d1ox2d5/Unity_2018-03-07_01-10-56.png)](https://postimg.org/image/wbu9ck1th/)

Set-up: A Cube can move in four different directions, with rewards being given to better positions releative to the goal.

Goal: Move to the green capsule, using the most rewarding path.

Agents: The enviorment contains one single agent linked to one brain.

Reward Function:
 - -.1 for each move move
 - +.2 if progressive made ( Closer to goal than before )
 - -1.0 for hitting a wall 
 - +100 for hitting the end
  

Brain: One Brain 
 - State Space:(Continuous) 6 Variables 
    - Agents Status ( Alive or not ) 
    - Agents X,Y,Z position on map
    - Agents Distance to goal
    - If the Agent has reached the goal
 
 - Action Space:(Discrete) 4 variables
    - Movement in 4 directions N W S E
    
Reset Parameters:
  Two:
   - If the agent collides with a wall
   - If the agent collides with the end goal collider
    
    
    
--------------------------



After training our agent using Proximal Policy Optimization provided by Unity ML Agents:

Step: 20000. Mean Reward: 2.2039705882352942. Std of Reward: 17.152717169394837.

This means we have are making some progressive torwards our goal, but end up hitting a wall most of the time.

Step: 100000. Mean Reward: 46.53655172413793. Std of Reward: 50.58151923488849.

We are making steady progress, it appears we hit the goal sometimes!

Step: 500000. Mean Reward: 95.1213043478261. Std of Reward: 23.166009077084173.
It looks like we hit the goal most of the time, but waste some time getting there.

- After 500000 Steps are agent can now make it to the goal most of the time. 

[![Maze_Gif.gif](https://s18.postimg.org/x56v4vabt/Maze_Gif.gif)](https://postimg.org/image/4fjz886bp/)

Clearly we are making progress! This can continue until we are near perfect..

Next to make some harder maps..

Lets add a object to get in the way sometimes..

[![Traffic_Gif2.gif](https://s18.postimg.org/ytpb5q81l/Traffic_Gif2.gif)](https://postimg.org/image/5ejmwq3hx/)

In the bottom left is tracked : Distance to Car, Ground we are on (safe or dangerouse) and wether the agent is alive or not

--------------------------

Scripts: TrafficController.cs , TrafficColScript.cs

Set-up: A Cube can move in four different directions, with rewards being given to better positions releative to the goal as
well as better rewards for being on a safer path and avoiding getting close to a passing "car".

Goal: Move to the green sphere, using the most safe path avoiding the car.

Agents: The enviorment contains one single agent linked to one brain.

Reward Function:
 - -.01 for each move
 - +.02 if progressive made ( Closer to goal than before )
 - -.02 if decreased progressive
 - +.02 for being on the safe path
 - -.1 for being on dangerous grounds(near edge)
 - -15  for getting to close to a car
 - -50  for falling off platform or getting hit by car
 - +100 for hitting the goal
  

Brain: One Brain 
 - State Space:(Continuous) 12 Variables 
    - Agents Status ( Alive or not ) 
    - Agents current ground its on ( safe or dangerous )
    - Agents X,Y,Z position on map
    - Car X,Y,Z position on map
    - Agents Distance to goal
    - Agents Distance to car
    - The Cars status: Moving or Stationary ( 5 roations of moving, then 5 seconds of resting )
    - If the Agent has reached the goal
 
 - Action Space:(Discrete) 4 variables
    - Movement in 4 directions N W S E
    
Reset Parameters:
  Two:
   - If the agent falls of the platform
   - If the agent gets hit by the car
   - If the agent collides with the end goal collider
    
    
    
--------------------------
Going back to our PPO Notebook..
[![chrome_2018-03-07_21-42-40.png](https://s18.postimg.org/bgr9mqudl/chrome_2018-03-07_21-42-40.png)](https://postimg.org/image/aeh347bk5/)

We run for 500,000 steps, recording and updating every 20,000 intervals..

[![chrome_2018-03-07_21-26-48.png](https://s18.postimg.org/77mjki6ix/chrome_2018-03-07_21-26-48.png)](https://postimg.org/image/i77qw3wxx/)

This starts off a little slower than our straight line to the goal it seems.. 

[![chrome_2018-03-07_21-27-33.png](https://s18.postimg.org/f0d7cif2x/chrome_2018-03-07_21-27-33.png)](https://postimg.org/image/l1aw9l1p1/)

The progress IS made though, a decent mean reward for 500,000 steps.


Lets plug our newly trained brain into the traffic civilian and see how well he avoids the car..

(You may need to click this to load)

[![Traffic_Gif3.gif](https://s18.postimg.org/642f94ec9/Traffic_Gif3.gif)](https://postimg.org/image/ez39jn34l/)


We can see our Agent slightly veers to the right in instances when the car is on the oposite side as well as studder steping back when the car approaches from the right.. maybe after a million or two steps we could get full avoidance!
---------------------------
Lets create a "Peg" maze, where each red cube is considered a wall and in each step, our agent determines its relative distance to its closest "wall", giving better rewards for positiong.

[![2018-03-08_20-01-44.png](https://s18.postimg.org/82rx9f709/2018-03-08_20-01-44.png)](https://postimg.org/image/zdd8hc9x1/)

Set-up: A Cube can move in four different directions, with rewards being given for safer paths away from walls.

Goal: Move to the green capsule, using the most rewarding path away from walls if you can.

Agents: The envi. contains one single agent linked to one brain.

Reward Function:
 - -.01 for each move move
 - +.02 Nearest wall is > 15f away |Positive Progressive Towards End | Negative Progressive Torwards start
 - +.01 Positive Progressive Towards End | Negative Progressive Torwards start
 - +.01 Negative Progressive Torwards start |  Positive Progress Towards End
 - -.02 Negative Progress Torwards End | Negative Progress Torwards start
 - +.03 If Nearest wall is > 15f away | Positive Progress towards End| Positive Progress Away from Start
 - -1.0 for hitting a wall 
 - +1.0 for hitting the end
  

Brain: One Brain 
 - State Space:(Continuous) 11 Variables 
    - Agents Status ( Alive or not ) 
    - Closest wall to agent
    - Agents X,Y,Z position on map
    - Agents X,Y,Z Velocity
    - Agents Distance to begining
    - Agents Distance to goal
    - If the Agent has reached the goal
 
 - Action Space:(Discrete) 4 variables
    - Movement in 4 directions N W S E
    
Reset Parameters:
  Two:
   - If the agent collides with a wall peg
   - If the agent collides with the end goal collider
    
    
    
--------------------------
We train for 500,000 steps 

This represents a good confidence.

[![chrome_2018-03-08_20-04-22.png](https://s18.postimg.org/yp4dxv8h5/chrome_2018-03-08_20-04-22.png)](https://postimg.org/image/wkk0ws6ud/)

Our brain can now navigate safely through the maze.

[![Peg_Maze500k.gif](https://s18.postimg.org/ynug50byh/Peg_Maze500k.gif)](https://postimg.org/image/w6ioxqs1x/)


With the same reward system, we can apply our learner to a minefield as well:

[![Unity_2018-03-08_20-16-20.png](https://s18.postimg.org/5mq3vfrgp/Unity_2018-03-08_20-16-20.png)](https://postimg.org/image/mn90444hx/)


