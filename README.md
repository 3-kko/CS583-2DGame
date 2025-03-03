#Mikko Benaso, 822702459

#November 4, 2024

#CS583-3D Game Programming

# Title: Raging Squares
### Genre: top-down shooter
 
Description:
Initially, I wanted to make a multi-leveled top-down shooter with different power ups, 2 different difficulties, and mini-custcenes.
However in response to TA feedback, I have come to realize that the scope of this game was a bit too ambitious and so I scaled it back 
dramatically.

New changes include:

 * Now a single-level game with the goal being to defeat the boss
 * Boss has a "second phase" in which other enemies start to spawn (begins at 75% health)
 * Game ends when either player dies or boss is killed.

Challenges:
Unfortunately due to time constraints, there are a number of implementations that I was unable to implement such as...

 * Being able to "parry" enemy bullets
 * Expand the play area
 * More enemy variety (as of now, there are only 2 enemy types)
 * stage hazards (the "water areas" of the map were intended to slow the player, and bushes were meant to have collision)
 * As of right now, the player is immediately thrown into the game once they press play. I was hoping to learn how to make a mini cutscene to fill in this gap.

Bugs:
 * After peer feedback, I implemented a mute button for the audio. However, this results in the music not pausing or resetting if the player wins/dies and restarts the game
 * When player dies, their weapon still shoots bullets
