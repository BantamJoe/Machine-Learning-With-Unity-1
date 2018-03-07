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
    


