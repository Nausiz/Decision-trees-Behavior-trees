# Decision Trees
The projekt was created for the purpose of BA thesis concerning decision trees' algorithms

## Introduction
The presented project uses decision trees to present the possibilities of implementing AI for computer games. Decision trees have been used in AI programming in situations often encountered in various types of games. The project consists of three scenes / levels, in each of them the player has to deal with a different type of AI.

## Overview of the concept of the project
The project focuses on the presentation of the three most frequently used applications of decision trees in games - hostile AI, allied AI and consequences of story choices (NPC behavior). The project demonstrates fragments of the game where we are dealing with artificial intelligence. Each of the scenes has a control panel implemented, thanks to which we can change certain parameters and observe changes taking place in the game. It is a kind of tool for research and analysis of created trees. Should the user want to return to the initial state, it is also possible to reset the level.

The first level shows the behavior of hostile NPCs towards our player. When we get into the right range, enemy units will start to follow us - this state is highlighted in yellow in the project (see Figure 1). 

*Figure 1. Enemy AI following the player mode in the first scene.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot1.png)

When the enemy gets close enough, the state will change to attack - this is shown in red in the project (see Figure 2).

*Figure 2. Enemy AI attack mode in the first scene.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot2.png)

When the player's character runs away from the enemies - he leaves the aforementioned range, the enemy AI will go to sleep - white.
The player also has the ability to attack opponents when, after a few shots at them, the health points of enemy units go below the set level, the enemies start to run away to the cover that is farthest away from the player. Even when the player approaches an enemy who is already hiding behind an obstacle, the enemy AI will look for another shelter - the best place to escape for himself. The AI ​​mode for escape is marked blue at this level (see Figure 3)

*Figure 3. Enemy AI escape mode in the first scene.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot3.png)

In the second scene, we can observe the behavior of the allied artificial intelligence. It is quite similar to the one presented in the first scene, but in this case the allied AI targets enemy characters. The friendly AI comes out of sleep when an enemy unit is within the appropriate range, to distinguish this effect in the design it is shown in light blue (see Figure 4).

*Figure 4. Ally Follow AI mode in the second scene.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot4.png)

Once it gets close enough to the enemy to attack, it changes its attack mode - pink (see Figure 5).

*Figure 5. AI allied attack mode in the second scene.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot5.png)

In this scene, the player also has the option to manage allied units, he can turn off the attack mode in the control panel and then the friendly AI will go into defense and start looking for shelter - highlighted as purple (see Figure 6).

*Figure 6. Allied AI escape mode in the second scene.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot6.png)

In the third scene, the consequences of the player's fictional choices and the AI's behavior towards it were shown in a simple way. When the player approaches the NPC close enough, the dialogue will be activated, the NPC will ask the player for a small favor - fetch the box (see Figure 7).

*Figure 7. Conversation with the NPC in the third scene.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot7.png)

If the player refuses to complete the task, nothing will happen, but if he accepts the request, he will be able to interact with the aforementioned object standing nearby. Then the player will be able to make a decisive choice - destroy the box or pick it up and then return it to the NPC as promised (see Figure 8).

*Figure 8. Selection example shown in scene three.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot8.png)

When an NPC has received his item, he becomes our ally and follows us - this is marked in green in the project (see Figure 9).

*Figure 9. Consequences of the choice in the third scene - returning the item.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot9.png)

However, when the player decided to destroy the box, the NPC will "get angry" with us and switch to the attack mode described in the previous scenes (see Figure 10).

*Figure 10. The consequences of the choice in the third scene - destroying the object.*
![alt text](https://github.com/Nausiz/Decision-Trees/blob/main/Decision%20Trees/Img/screenshot10.png)