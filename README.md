# Trenches

> **Devlog #1**

As of the first commit of Trenches, various features have been added, mostly ascertaining to the world generation. The very first feature that was added on the first day of development was a perlin-noise based heightmap for Unity's terrain system. As such, this was a rather complex algorithm and was completed by following a tutorial by Brackeys, which will be referenced below. At the current point in development (31st of October,) this is the only video tutorial that has been followed and i would like to keep it that way (in order to properly gauge my own coding skills.)

After this point, although i had a heightmap planned, i didn't really know where to continue. I had tried to prototype numerous different features with limited sucess, and as such, hit a bit of a wall. This was, however, until I commited to developing the trench system, arguably one of the most important features of the game. Because of this, i wanted to ensure that it was made to a high standard. This, in turn, created more issues; i had no idea how to tackle this algorithm.
Initially, I made a system that would instantiate a straight line of 'trench nodes,' as a rudimentary version of an algorithm that i had used in a previous project. This worked, but was incredibly basic. I had the idea of matching the heights of the nodes with the terrain height and as such, i wasted many sessions trying to do this. In hindsight, it was a complete waste of time. Not only did it further confuse my knowledge of the Unity **TerrainData** system, but also was redundant when it came to instantiating the trench models, as they would need to be below ground for it to look at all like a trench system.

After this point, i decided on mainly copying the system from my last project. I had a *'Generator Node'* go across the map 4 units at a time, instantiating different node types depending on the direction it moved. This meant i could have a trench system which changed direction and was also fast to generate. I decided, based on negative experiences with the last project, to complete this algorithm using a While loop which runs exclusively when the generator node's X-Coordinate is less then the width of the terrain. This worked wonders (partially due to the fact that my CS major cousin was in the city,) and the algorithm worked. 
After this, i made the algorithm repeat three times at different Z-Coordinates (with the third trench being completely straight,) in order to segment the trenches for more accurate gameplay. I plan on having differnent buildings being made at these points such as Front-line defences, logistics buildings and artillery areas.
Finally, i made the algorithm generate 'empty' nodes in every 'chunk' (as i casually steal world generation terminology from minecraft.) This is so when i make building mechanics, the mouse will have something to detect via Raycast.

Currently, my next step to start build two is to import a variety of 3d models made in blender and after that point, i can start on the building mechanics and a rudimentary enemy AI. After this point, the submission for the assessment should be ready after some brief player testing.

> **End of Devlog #1**

> **Devlog #2 - 9th November**

This commit had less content in comparison to the last one. As opposed to the very algorithm-based features introduced in the last commit, this one was focused on the core components needed for this game. I introduced the 3d Models to the game for the trenches, and i also made it so they would change colours when you hover your mouse over them. Furthermore, upon clicking a chunk, The corresponding node co-ordinates are stated in the console.

In addition to this, i also added some basic camera controls, which can be controlled with the arrow keys, as well as by holding middle mouse button down and dragging. Furthermore, the player can zoom into the game view by scrolling.
This commit was much easier than the last one as it goes back to the very basics of Unity games. Admittedly, i did have to reference community posts for the camera movement controls as I had no idea how to approach the controls from a near-isometric viewpoint. These posts are referenced in the code comments.

The next commit will be focused on introducing basic game mechanics such as levels and weapons.

>**End of Devlog #2**

>**Start of Devlog #3**

I'm not going to lie, i have very little memory of what has changed in this commit. Most of the features i have added are small little things here and there that make the game a little bit more playable. It's hard to keep track of and, i know, i probably should have. Nonetheless, i will start listing things that i **THINK** i have added in this push

  >Player Health
  >Player Economy
  >A Pause Feature
  >A quit to Desktop Feature
  >Time control
  >Cheats (For demonstration's purpose trust me bro) (Just try, hit C, D, then = *(not the one on the numberPad)*)
  >Fixed a typo where yellow balloons couldn't be spawned at the level they're meant to (all thanks to the cheats)
  >Fixed a bug where the game would stop working after level 40. (another typo fixed by my sneaky use of cheats)

Not going to lie, there's probably more but that's really all i can remember. This segment was (at least majorly) done without use of ChatGPT. It was relatively easy coding. I think the only part was an issue with instancing through the *activeBalloons* array in order to delete them (for the cheats, of course.) So, not central to the gameplay at least. This section was incredibly easy and i had literally no issues with it (apart from the damn cheats, as mentioned like 2 seconds ago).

>**End of Devlog #3**
