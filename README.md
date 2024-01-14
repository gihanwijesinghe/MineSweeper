# MineSweeper

## Set up enviroment
- This code is based on Dot net 7.0 Console application
- Can run in either Linux or Windows platform
- Clone the repository or locate the project solution
- Build and run the application to start the Mine Sweeper game

## Running MineSweeper Game
- Game will prompt console inputs based on following conditions
  1. Prompt user to "Enter the size of the grid"
  2. Prompt user to "Enter the number of mines to place on the grid"
  3. Game will generate the mine field and place mines randomly (User is not able to see where mines are placed)
  4. Prompt user to "Select a square to reveal"
  5. If the selected square is mine, Game will be over in loosing conditions (Then prompt user to run the game from beginning)
  6. Otherwise, it will reveal how many adjacent mines are with the selected square
  7. If the number of adjacent mines are zero, it will look for all the neighbor square until revealing atleast one adjacent mine
  8. Once all the field is revealed, Game will be over in winning conditions.
  9. Prompt user to run the game from beginning

## Implementation
This project has two main interactions
1. User interactions
   - This project contains console user inputs, but this can extended to GUI or some other.
   - So there is ConsoleUserCommand implementation which extends IUserCommand interface (Added GuiUserCommand as a mock to extend if necessary)
   - Also contains IInputOutput interface which can be extendable to use with input output operations globally.
   - Also contains IInputValidator interface to validate inputs and fetch required output
3. Game logic
   - Contains "MineSquare" and "MineField" models
   - Contains "GameGenerator" which controls the request pipeline of the game (making decisions and arrangement)
   - Contains "MineFieldGenerator" which do the changes in the minefield according to user inputs
  
   Apart from main interactions there are few implementations (such as helpers, constants, errors) used to integrate project functionality 
