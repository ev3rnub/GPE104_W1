# GPE104 Unity Project

**Course:** GPE104  
**Professor:** Matthew Henry  
**Student:** Chad V
**Engine:** Unity 6.6

---

## Project Overview

This is the an ongoing project for GPE104. The goal of this project is to demonstrate understanding of:

- Core Unity workflow (Scenes, GameObjects, Prefabs)
- Scripting in C#
- Basic game systems (input, movement, interaction)
- Iteration and polish (UI/UX, feedback, basic game feel)

## MUSIC Credit
Music created by Chad Verbus using Reason 13. 
SoundFX created via https://sfxr.me

## Project Features

This will describe and list features that are implemented to a sufficient manner.

09/17/2026@10:04AM - Basic Input keyboard monitoring w/Random Sprite movememt.

09/17/2026@10:27AM - Implemented Escape to Quit functionality.

09/17/2026@11:18AM - Added private vars and updated some comments/misc code cleanup.

09/17/2026@11:41AM - Built a test build for macOS of the project so far named CVUnity_P2M1.app.

09/17/2026@10:21PM - Implemented WSAD Tank-Like Controls via a Pawn Controller model; Implemented Random Movement via Key T, Arrow teleportation via the arrow keys.

09/22/2026:02:37PM - Implemented health and death components. Defined an Astroid Prefab with a damamger component. Modified the player controller for null pawn checks to reduce misc unity errors.

09/24/2026:08:57AM - Created a new branch p_2_ms_4. Created underlying folder structure to support a game manager and bullet/projectile component. 

09/25/2026:07:04PM - Modified PlayerControler w/shooting input via space key. Modified Pawn

09/25/2026:03:21PM - Implemented GameManager singleton, which keeps track of obstacles and gamestate, Projectile Shooting/Weapon firing via spacekey, my projectile is deployed and moves slowly initially and then speeds up once its completely deployed. Implemented deathDestroyManger.

09/25/2026:07:33PM - Defined branch p2_ms_5, Implemented a User Interface using screen space, world space canvas objects to display the players score and astroid health and implemented a scoring system.

09/26/2026:08:04AM - Added additional GUI elements; Added Astroid Count and a status message indicator at the bottom.

09/28/2026:02:49PM - Implemented 2d/3d sounds, a settings screen with volume sliders. Implemented PlayerPrefs for volume sliders. 

## WIP

This will describe Work in Progress implementations.
- Implement 2d sounds.
- Implement 3d sounds.
- Implement a settings screen w/sliders to change sound levels. 
- Implement player preferences persistance.

