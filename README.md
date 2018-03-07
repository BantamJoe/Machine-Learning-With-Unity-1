# Machine-Learning-With-Unity

For this project we will be working in Unity 2017.3.1f.

We use the following in our simulation:
-Jupyter
-Matplotlib
-numpy
-Pillow
-Python (2 or 3; 64bit required)
-docopt (Training)
-TensorFlow (1.0+) (Training)



We will create a simple maze to begin with , very basic.

[![2018-03-06_23-35-07.png](https://s18.postimg.org/9unnckrpl/2018-03-06_23-35-07.png)](https://postimg.org/image/q5nr8w479/)

Set-up: A Cube can move in four different directions, with rewards being given to better positions releative to the goal.

Goal: Move to the green capsule, using the most rewarding path.

Agents: The enviorment contains one single agent linked to one brain.

Reward Function:
 - -.1 for each move move
 - +.2 if progressive made ( Closer to goal than before )
 - -100 for hitting a wall 
 - +100 for hitting the end
  


