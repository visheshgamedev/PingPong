# Ping Pong
A very simple single player ping pong game.

You can download the playable build from - https://visheshshahani.itch.io/ping-pong

##Things that I've implemented -
1. A very simple Main Menu.
2. An AI paddle which moves along the Y axis of the ball.
3. Player paddle Movement, Up and Down.
4. Ball movement
	a. Initialize the ball movement towards the player.
	b. Upon paddle collision determine the exact position and divert the ball so that you are not playing a straight ping pong.
	c. Increase the balls velocity when the ball collides with the paddle to make it a bit difficult.
5. A game manager script which is responsible to handle.
	a. Player and AI score.
	b. Game status - If the game is playable based on the current score or if the game has ended.
6. A scene changer script which handles all the scene changes in the game and the game quit functionality.
7. A UI manager which handles the display of current score and Game Over display.

##Thing's that I am planning to implement -
1. A playable version for android.
2. 2 player local co-op.

##Following are the bugs
1. Ball velocity decreases or increase upon paddle and border collision
2. Score is updated every frame in UIManager script.
