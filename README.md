# KatamaryDamacy
 
Clone of Katamary Damacy game

**Unity: 2022.3.8f1**

**Controlw**

**W** - role forward
**A, D** - look and rotate the Katamari to the side

For input, I use the `Unity Input System` package

**Game Rules**

Reach size of **N** in **M** time. 

 The size of target Katamari and Round duration can be edited on EndGameConditions scriptable object

![image](https://github.com/VladimirStefaniuk/KatamaryDamacy/assets/10983669/afbcb623-316f-4b8f-965a-c9cbc999656a)

**Gameplay**


_Game start_ - The player gets to the "NEW GAME" state. Players will see dynamic text with game rules 

![image](https://github.com/VladimirStefaniuk/KatamaryDamacy/assets/10983669/46e8d4af-cf31-4dd1-b7fb-6bfe47e43f9e)


_Active State_ - Roll to stick to the objects on the scene. You can use the pause button on the top right corner to pause the game.

![image](https://github.com/VladimirStefaniuk/KatamaryDamacy/assets/10983669/592857b7-0844-4ff4-8122-0db864765a99)


_Won, Lose State_ - Once you reach the target size or time runs out, it will show the Win or Lose view, and show button, so you can restart the game. 

![image](https://github.com/VladimirStefaniuk/KatamaryDamacy/assets/10983669/739d63af-3cbe-40d4-a6fb-1948628d905d)


**Architecture.** 

I used a based approach to communicate between controllers, this decouples dependencies, and gives more freedom if you want to create a new system that reacts to existing events, for example:

![image](https://github.com/VladimirStefaniuk/KatamaryDamacy/assets/10983669/f80eb346-fd15-4a5f-b5f8-9c49224bc568)

![image](https://github.com/VladimirStefaniuk/KatamaryDamacy/assets/10983669/7042acb6-9837-4b93-983a-609faaccfade)

