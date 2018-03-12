# Machine-Learning-With-Unity

For this repo i will be working in Unity 2017.3.1f to train various scenarios with Machine Learning agent techniques using ML-Agents: https://github.com/Unity-Technologies/ml-agents

Specifically PPO ( Proximal Policy Optimization ) Reinforcement Learning

We use the following:
- Jupyter
- CUDA toolkit 9.0
- TensorFlow (1.4) (Training)


My parameters used:

We use discrete actions(Keyboard) vs continuose like a joystick, so our batch size stays small. 
We do not need many hidden units since our problems are not that complex.


[![chrome_2018-03-08_20-34-40.png](https://s18.postimg.org/w92kkknzt/chrome_2018-03-08_20-34-40.png)](https://postimg.org/image/azey9q7p1/)




Lets try to start with somthing basic



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
    
    
  [![Traffic_Gif2.gif](https://s18.postimg.org/ytpb5q81l/Traffic_Gif2.gif)](https://postimg.org/image/5ejmwq3hx/)  
    
    
--------------------------

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

* I've learned that smaller values are better than large values and rewards > punishment in most cases *

Lets create a "Peg" maze, where each red cube is considered a wall and in each step, our agent determines its relative distance to its closest "wall", giving better rewards for positiong.

[![2018-03-08_20-01-44.png](https://s18.postimg.org/82rx9f709/2018-03-08_20-01-44.png)](https://postimg.org/image/zdd8hc9x1/)

Scripts: PegCubeAgent.cs, CollisionScript.cs

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


After about 720k steps its looking pretty similar .. so lets stop there and test it


[![chrome_2018-03-08_20-30-00.png](https://s18.postimg.org/scp8ogsop/chrome_2018-03-08_20-30-00.png)](https://postimg.org/image/l9hd8un91/)


It seems the agent has found the most rewarding path! Utilizing the open space in the left upper corner.

[![Mine_Field720k2.gif](https://s18.postimg.org/t2810v3ix/Mine_Field720k2.gif)](https://postimg.org/image/85bsw75hx/)

More to come..



----------------------------

Next i made this scenario.. trying to keep the details of the goal away from the agent now

[![Unity_2018-03-09_22-52-24.png](https://s18.postimg.org/lbxkkbwq1/Unity_2018-03-09_22-52-24.png)](https://postimg.org/image/uwh777m1x/)

Scripts: BridgeAgent.cs, BridgeController.cs, CollisionScript.cs

Set-up: An agent can move in 4 directions, a button is located on the platform that moves the second platform, enabling the goal to be reached.

Goal: Move to the green capsule, by pressing the button first to connect the platforms.

Agents: The envi. contains one single agent linked to one brain.


Reward Function:
 -= .01f for each step
 
 += .005f for each step that the button is pressed
 
 += 1.0f for reaching the goal
 
 -= 1.0f for falling off platform

Brain: One Brain 
 - State Space:(Continuous) 10 Variables 

    - Agents X,Y,Z position on map
    - Agents X,Y,Z Velocity
    - Status of the bridge ( connected or not ) 
    - bridge X,Y,Z position on map
    
 
 - Action Space:(Discrete) 4 variables
    - Movement in 4 directions N W S E
    
    Reset Parameters:
  Two:
   - If the agent collides with a wall peg
   - If the agent collides with the end goal collider
   
   
   I ran this for 1,500,000 steps to try and smooth out it out a bit, still has a buffer to it though.
   
   [![chrome_2018-03-10_00-20-42.png](https://s18.postimg.org/ap3rf943t/chrome_2018-03-10_00-20-42.png)](https://postimg.org/image/hsbmuv9j9/)


[![Bridge1500k.gif](https://s18.postimg.org/mqz590fsp/Bridge1500k.gif)](https://postimg.org/image/j7d7j7d2t/)

----------------------------

Next up i decided to implement somthing with shooting.. 

I made up a simple little enviorment with 4 targets and one agent:

[url=https://postimg.org/image/55tgfuwd1/][img]https://s18.postimg.org/55tgfuwd1/Unity_2018-03-11_20-03-49.png[/img][/url]

Scripts: ShooterAgent.cs , TargetCollider.cs

Set-Up: 4 targets are located on a platform, each one can be hit once to give a score of +1, the agent can shoot up to 100 times before the scene is reset, or up to 250 max steps to reset the scene as well.

Goal: Shoot the 4 targets with using as least bullets as possible.

Agents: 1 agent, 1 brain

Reward Function:
  - -=.01 for each step
  - += 1.0 for hitting a target ( can only get 1 from each target max in each scene )
  - -=.01 for each shot ( to discourage spamming all the bullets )
  - += 01 for each step that a target is hit, so if 3 targets are hit then +.03 for that step.
  
 
Keep track of 3 things.
State Space: 
 - Agents Rotaion
 - Agents remaining bullets
 - number of targets hit 

4 possible actions
Discrete Actions:
 - Rotate the agent left
 - Rotate the agent right
 - Shoot a projectile
 - Do nothing
 
Reset parameters:
   - 250 steps 
   - No bullets remaining.
