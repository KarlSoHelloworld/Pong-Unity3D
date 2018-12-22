# Pong-Unity3D
This program is trying to replicate a classical video game, which is named “Pong”, in windows platform. Below is the introduction of “Pong”.
## 1.Demonstration
Youtube Link:https://youtu.be/k5mzbi-lHaw

![1](https://github.com/KarlSoHelloworld/Pong-Unity3D/blob/master/Readme%20Pictures/1.png)

Figure-1
![1](https://github.com/KarlSoHelloworld/Pong-Unity3D/blob/master/Readme%20Pictures/2.png)

Figure-2

![1](https://github.com/KarlSoHelloworld/Pong-Unity3D/blob/master/Readme%20Pictures/3.png)

Figure-3
## 2.Game Flow
The work flow diagram is shown as below. Please check.

## 3.STRUCTURE OF PROJECT
This project consisted of two scenes, Welcome Scene and Game Scene. Each scene contains several objects and functions. 

### 3.1	Welcome Scene
Welcome Scene is a menu page, the main function of this scene is to call Game Scene. When the Game Scene is shown, Welcome Scene will be hidden. The structure of Welcome Scene is shown in Figure-3.
![1](https://github.com/KarlSoHelloworld/Pong-Unity3D/blob/master/Readme%20Pictures/4.png)
Figure-4 Welcome Scene Structure

### 3.2	Game Scene
Game Scene is the most important component of this game. Users can play the game through this scene.
Game Scene consist of game components. And each component has several functions which will interact with each other. The details of Game Scene structure are shown in Figure-4.
![1](https://github.com/KarlSoHelloworld/Pong-Unity3D/blob/master/Readme%20Pictures/5.png)
Figure-5 Game Scene Structure

### 3.3	AI DESIGN
AI of this game is designed to catch the ball. AI will trace the position of ball all the time. It is implemented by using a simple if conditional function. The function Works like below.

Algorithm of Enemy(Top) Paddle AI:
IF Enemy Paddle in the left of Ball
	AI moves Enemy Paddle to right  
Else IF Enemy Paddle in the right of Ball
	AI moves Enemy Paddle to left  
Else
	AI does nothing
