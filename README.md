# 3DConsoleGame
#### A 3D game on a 2D console window.

Thank you for downloading 3DConsoleGame (the name will probably change in the future) v1.0.0 by Illusion. Feel free to modify and adjust this program to your needs.


## The following content can be found in this file:

- an explaination and instruction on how to play the game
- a list of game controls
- a list of features that I will add or change in the future
---
### 1. Explaination and instructions
#### 1.1 Game world, movement and interaction
This game, despite being in a 3D world, is played on a 2D console window. On the left half of the window, you can see a game world while on the right half a UI is visible.
The game world consists of 20 * 20 and infinite in depth fields. Each field has its own unique coordinates. The player, who's character is a capital P on the game world, is able to use the WASD keys to change their X and Y coordiantes and the Q and E keys to change their Z coordinate.
Every game object has a unique symbol on the game world. Currently there are:

- P = player
- E = enemy
- T = tree
- C = campfire
- O = portal

If a game object is on the game world but doesn't share the Z coordinate with the player, it will be displayed as "?". To find out the Z value of an object the player has to move their character on the same X and Y coordinate as the object. The symbol of the previous unknown object will now be displayed in the UI on either "Front" or the "Back".
"Front" means the objects Z value is lower than that of the player. "Back" means it's higher. To interact with the object, the player now has to move to the exact coordinates as the object by descending or asceniding on the Z axis.
Once the player has reached the object, it will be displayed in the UI at the "Colliding" row. Now the player gets a better look at the object and can see a short description at "Note".
If the player now decides to interact with the object they simply have to hit the F key on their keyboard and a short note on what happened will pop up at the UI.

#### 1.2 Game objects
Game objects can be divided into two categories: Immobile objects and entities. The immobile objects are:

- the tree
  - This object is displayed with a capital T. Upon interaction, the player is able to chop it down to gain some wood.
- the portal
  - This object is displayed with a capital O. Upon interaction, the player will be transported to an other dimension.
- the campfire
  - This object is displayed with a capital C. Upon interaction, the player can heal some health points until it goes out.
  
The entities are:
  
- the player
  - This object is displayed with a capital P. This object cannot be interacted with, although it can be controlled.
- the enemy
  - This object is displayed with a capital E. There are currently 3 types of enemies: Normal enemies, angels and demons. Normal enemies can be killed by interacting with them, while angels and demons cannot be killed currently, and will instead steal health from the player upon interaction. Note that the player currently cannot die.

#### 1.3 Inventory
The inventory can be opened by pressing the B key. The player can now see a list of all items they currently have. The player can cycle through that list and read a short description to each item and is able to use it by pressing F. Note that only the campfire can be used.
Currently only wood can be obtained by chopping down trees. The player starts with three items of each type. Note that this is only a temporary feature and will be removed when crafting will be introduced.

#### 1.4 Dimensions
There currently are three dimensions: The Overworld, Hell and Heaven. They are basically the same besides the console windows color but in the future they will include different game rules, objects that can generate etc.
The dimensions can be accessed by entering a portal. Two portals are placed at the beginning in the game world for demonstration purpose.

### 2. Game controls
- W,A,S,D : Used to move on the X and Y axis
- Q,E : Used to move on the Z axis
- F : Used to interact with the colliding object
- B : Used to open the inventory
- Esc : Used to open the pause menu
- P : Used to generate random game objects (this feature is only for demonstration purpose and will be removed in the future)

### 3. What will be added or changed?
- A crafting system to craft items such as the portal or campfire.
- A game object generation service which automatically generates objects.
- A way to kill angels and demons.
- A game over system.
- More entities.
- More uses for dimensions.
- More uses for the currently available items.
- A quest system.
- The spawn portals and start items will be removed when the crafting system is introduced.
- A level system.
- A plug-in system which allows users to easily make their own add-ons for the game.


Thank you for reading and have fun playing!
