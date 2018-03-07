# Machine-Learning-With-Unity

For this project we will be working in Unity 2017.3.1f.

And using ML-Agents : https://github.com/Unity-Technologies/ml-agents

We use the following in our simulation:
- Jupyter
- Matplotlib
- numpy
- Pillow
- Python (2 or 3; 64bit required)
- CUDA toolkit 9.0
- TensorFlow (1.4) (Training)



We will create a simple maze to begin with , very basic.

[![Unity_2018-03-07_01-10-56.png](https://s18.postimg.org/x1d1ox2d5/Unity_2018-03-07_01-10-56.png)](https://postimg.org/image/wbu9ck1th/)

Set-up: A Cube can move in four different directions, with rewards being given to better positions releative to the goal.

Goal: Move to the green capsule, using the most rewarding path.

Agents: The enviorment contains one single agent linked to one brain.

Reward Function:
 - -.1 for each move move
 - +.2 if progressive made ( Closer to goal than before )
 - -100 for hitting a wall 
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
    
    


After running our agent through some training..

Step: 20000. Mean Reward: 2.2039705882352942. Std of Reward: 17.152717169394837.

This means we have are making some progressive torwards our goal, but end up hitting a wall most of the time.

Step: 100000. Mean Reward: 46.53655172413793. Std of Reward: 50.58151923488849.

We are making steady progress, it appears we hit the goal sometimes!

Step: 500000. Mean Reward: 95.1213043478261. Std of Reward: 23.166009077084173.
It looks like we hit the goal most of the time, but waste some time getting there.

Clearly we are making progress! This can continue until we are near perfect..

Next to make some harder maps..

