README  
Group 5  
Title: Not Super Monkey Ball  
Tutor: Nick

Group members: 

- Angus  
- David  
- James

How to run:  
Open the build in the builds folder, for unity editor open the 3d menu scene file in assets/scenes

Build: Builds are in the assets/build folder in the repo  
Scripts and assets are also zipped in the root folder

Controls:

3D Level:

* W to move forward  
* S to move backward  
* A to move towards the left  
* D to move towards the right  
* R to Reset stage  
* Space to jump  
* Q to attack  
* E to uppercut  
* ESC to pause the game

2D Level:

* A,D or Left/Right arrow keys to move the player left and right  
* Space Bar to jump  
* Space Bar while connected to a vertical collision box to jump up the wall  
* Q to push the ball  
* E to ‘kick’ the ball in to the air  
* R to restart the level  
* ESC to pause the game

Options:

* Volume slider \- controls the master volume of the game according to the position of the circle in the slider  
* Difficulty dropdown \- changes the health and speed of the enemies in the game according to the difficulty selected  
* Dyslexia friendly font \- changes the font across the entire game to a different one to make the game more accessible for those with dyslexia  
* Reset game \- resets any data saved for the current playing session

where data lives, 

* Easy (DifficultyData) \- a scriptable object that stores the data used for the enemies for “Easy” mode  
* Medium (DifficultyData) \- a scriptable object that stores the data used for the enemies for “Medium” mode  
* Hard (DifficultyData) \- a scriptable object that stores the data used for the enemies for “Hard” mode  
* Powerups (PowerupData) \- a scriptable object that holds all of the information related to the powerup used in the 3D level  
* Player data (PlayerData2D/PlayerData3D) \- a set of scriptable objects determining how the player is able to move around the 2D/3D map.

“2D Improvements”, 

* Fixed spike collisions by change the trigger function  
* Game design now aligns more with the chosen theme of “SDG Safari” by adding 3 different bins as “goals” and according balls to be the new aim of the game  
* Added a volume slider to aid in usability and accessibility  
* Added a difficulty changer to aid in the variation of challenges and enhance engagement  
* Added hearts to the HUD within levels to aid in usability, allowing the player to know their amount of health at all times  
* Added enemy hittable logic  
* Added enemy collisions dealing damage to player  
* Added progress bar ui element to track progress

3D Menu:

The 3D menu was created by James, using the assets and level design from the 3D level. This 3D menu features 4 options:

* Play \- sends the user to the 3D level  
* Level select \- sends the user to the “Level select” screen  
* Options \- sends the user to the “SettingsScreen” screen  
* Quit \- Ends the application according to the Unity method “Application.Quit();”

This menu is highly unique, featuring the monkey player within the 3D level with the main menu options featured above them as differently textured cubes. When the user clicks on an option, the monkey will move underneath the associated cube and jump into it. This jumping animation is what triggers the next screen to be activated. There is a hover effect also added to the 3D main menu, with the cubes turning more yellow should the user hover over an option. Furthermore, the camera moves from a far away angle centering in on the monkey after a second to further interest the player.

3D Level:

A unique 3D level was created, using various aspects from the 2D game including a common gameplay and visual theme. This level is centered around multiple puzzles and interactable objects, including:

- Keys: unlocks various routes  
- Springs: launches the ball upward  
- A powerup: increases the players jump height  
- Pressure plates: activates upon contact with the ball/player

The 3D level contains various post processing and visual effects, including light anti-aliasing, a rotating skybox and fog. Various sprites are included 

who did what:

David Contribution:

* 3D level  
  * Player3D ingame setup  
  * Player3D character controller setup and movement  
  * Player3D animations controllers and animation clips  
  * Inputhandler3d scripts and setup  
* 2D level  
  * Changed button presses to be handled by Inputhander  
  * Progress bar scripting and UI  
  * Level progress script  
  * [Bin](http://Bin.cs) related files such as prefab, animations and scripts(bin cs)  
  * 3 new ball types( trash types) with different material settings  
  * Enemy collision damage setup fixes  
  * Enemy follow fixes  
  * Attackable enemies  
* Refactoring:  
  * Changed movement scripts to use the inputhandler  
  * Changed player movement scripts to use scriptable objects  
  * Changed bin scripts to use events  
* Debugging   
  * Git master  
  * Many many bug fixes related to build 

James’ Contribution: 

* 3D main menu  
  * Textures for each of the cubes featured as the main menu options  
  * Monkey following an option click functionality, with the monkey jumping into the option to trigger a different screen showing up  
  * Hover effect for each of the cubes, with them becoming more yellow on mouse hover  
  * Camera smoothly moving into the 3D main menu options on screen load  
* 2D level hearts HUD addition  
  * The hearts reflect the health of the player from the “PlayerHealth” component  
  * Aids in usability of the game  
* 3D level particle effects  
  * Created a particle effect for landing on the grass from the air  
  * Created a particle effect for attacking  
  * Created a particle effect for uppercutting  
  * Created a particle effect for the ball moving along the grass  
* Volume slider  
  * Created a volume slider that controls the master volume for the game  
* Difficulty dropdown  
  * Created a dropdown in the settings that controls the speed and the health of the enemies according to the difficulty chosen from it  
* Presentation  
  * Created the slideshow used in the presentation  
  * Created notes for the other team members to use for the presentation  
* Various bug fixes  
  * Recoded initial difficultyData scriptable object to be more inline with prominent coding conventions  
  * Deleted the Daydream font, changed all the objects using it and deleted or changed all the code associated with it  
  * Changed the [SceneManager.cs](http://SceneManager.cs) script to use only 1 method that takes in a parameter instead of having a different method for each scene, and changed any scripts that use the SceneManager to accommodate this change

Angus’ Contribution:

- 3D level  
  - Unique shaders and visual styling consistent with the 2D level \[3\]  
  - Spritemapping and custom objects \[2\]  
  - Optimisations from occlusion culling  
  - Post processing FX such as anti-aliasing and fog \[3\]  
  - Particle FX creating immersive atmosphere  
  - Stylized lighting  
- 2D camera FX including camera shake  
- Various 2D bug fixes  
  - Ball/player collision with spikes  
  - Enemy AI  
  - Background scaling  
- Powerup data and scriptable object  
- Integrating menus into 3D level including death/win conditions

known issues. 

- Some collision bugs in 3D level  
  - Player does not collide with spring objects  
  - Pressure plate collision sometimes stutters  
- Some game design issues in 3D level  
  - Camera cannot rotate, some objects are hidden from view or difficult to find  
  - Some gameplay features are not explained leading to some potential confusion for new players  
- Killzone for 3d level collision doesn't function properly

Feedback applied:

* Physics fixes errors such as collision on spikes   
* Refactor inputhanding  
* Refactor scripts to use scriptable objects  
* Added a script that uses event driven functions  
* Core themes redesign  
* Enemy interaction for more variety  
  * enemies can attack, and be attacked  
* Polish and feedback  
* Changed gameplay from single goal to 3 different goals with different “balls” to put in  
* Difficulty modes added

Unaddressed: 

* UI scaling doesnt function  
* Difficulty still high

New Resources:

- ***\[1\] Heart Life Pack 1***

**Author:** Dean Lofi Plays  
**Link:** [https://deanlofiplays.itch.io/heart-life-pack-1](https://deanlofiplays.itch.io/heart-life-pack-1)

- ***\[2\] Voxel Animals & Item Pack***

**Author:** SonaSar  
**Link:** [https://sona-sar.itch.io/voxel-animals-items-pack-free-assets](https://sona-sar.itch.io/voxel-animals-items-pack-free-assets)

- ***\[3\] Free Skybox Extended Shader***

**Author:** BOXOPHOBIC  
**Link:**[https://assetstore.unity.com/packages/vfx/shaders/free-skybox-extended-shader-107400](https://assetstore.unity.com/packages/vfx/shaders/free-skybox-extended-shader-107400)

- ***\[4\]  Unity Occlusion Culling Tutorial***

**Author:** Freedom Coding  
**Link:** [https://www.youtube.com/watch?v=7bZ4OIA0wRQ](https://www.youtube.com/watch?v=7bZ4OIA0wRQ)

- ***\[5\]  Simple Garbage Props***

**Author:** loafbrr  
**Link:** [https://loafbrr.itch.io/simple-garbage-props](https://loafbrr.itch.io/simple-garbage-props)

- ***\[6\]  Ultimate Platformer Pack***

**Author:** quaternius  
**Link:** [https://quaternius.itch.io/ultimate-platformer-pack](https://quaternius.itch.io/ultimate-platformer-pack)

