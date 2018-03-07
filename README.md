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
    
    


After running our agent through 320,000 training steps:

Step: 20000. Mean Reward: 2.2039705882352942. Std of Reward: 17.152717169394837.
Saved Model
Step: 40000. Mean Reward: 19.964368932038834. Std of Reward: 40.8634720609201.
Saved Model
Step: 60000. Mean Reward: 25.83644295302014. Std of Reward: 44.59384959358863.
Saved Model
Step: 80000. Mean Reward: 37.18500000000001. Std of Reward: 49.01731136944262.
Saved Model
Step: 100000. Mean Reward: 46.53655172413793. Std of Reward: 50.58151923488849.
Saved Model
Step: 120000. Mean Reward: 43.078160000000004. Std of Reward: 50.28561216704436.
Saved Model
Step: 140000. Mean Reward: 75.07512345679014. Std of Reward: 44.07695141423024.
Saved Model
Step: 160000. Mean Reward: 65.3501775147929. Std of Reward: 48.31388898856371.
Saved Model
Step: 180000. Mean Reward: 72.88642487046631. Std of Reward: 45.257371576761955.
Saved Model
Step: 200000. Mean Reward: 79.3675. Std of Reward: 41.33889723532007.
Saved Model
Step: 220000. Mean Reward: 79.86985294117648. Std of Reward: 40.97436107097281.
Saved Model
Step: 240000. Mean Reward: 86.18614349775785. Std of Reward: 35.53867393092554.
Saved Model
Step: 260000. Mean Reward: 85.43862068965518. Std of Reward: 36.27991023818287.
Saved Model
Step: 280000. Mean Reward: 85.17837719298245. Std of Reward: 36.52072068063778.
Saved Model
Step: 300000. Mean Reward: 88.27169491525423. Std of Reward: 33.273913849891095.
Saved Model
Step: 320000. Mean Reward: 86.31530172413794. Std of Reward: 35.39451492785186.
Saved Model


Clearly we are making progress!

Next to make some harder maps..

