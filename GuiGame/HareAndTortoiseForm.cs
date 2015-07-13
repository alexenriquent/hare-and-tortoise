using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;

using SharedGameClasses;

namespace GuiGame {

    /// <summary>
    /// The form that displays the GUI of the game named HareAndTortoise.
    /// 
    /// Author: Thanat Chokwijitkul 9234900
    /// Date: October 2014
    /// </summary>
    public partial class HareAndTortoiseForm : Form {

        // Specify the numbers of rows and columns on the screen.
        const int NUM_OF_ROWS = 7;
        const int NUM_OF_COLUMNS = 6;
        
        // Number of current player
        public static int playerNumber = HareAndTortoiseGame.FIRST_PLAYER_NUMBER - 1;

        // When we update what's on the screen, we show the movement of players 
        // by removing them from their old squares and adding them to their new squares.
        // This enum makes it clearer that we need to do both.
        enum TypeOfGuiUpdate { AddPlayer, RemovePlayer };
    
        /// <summary>
        /// Constructor with initialising parameters.
        /// Pre:  none.
        /// Post: the form is initialised, ready for the game to start.
        /// </summary>
        public HareAndTortoiseForm() {
            InitializeComponent();
            HareAndTortoiseGame.NumberOfPlayers = HareAndTortoiseGame.MAX_PLAYERS; // Max players, by default.
            HareAndTortoiseGame.InitialiseAllThePlayers();
            Board.SetUpBoard();
            SetupTheGui();
            ResetGame();
        } // end form constructor

        /// <summary>
        /// Set up the GUI when the game is first displayed on the screen.
        /// 
        /// This method is almost complete. It should only be changed by adding one line:
        ///     to set the initial ComboBox selection to "6"; 
        /// 
        /// Pre:  the form contains the controls needed for the game.
        /// Post: the game is ready for the user(s) to play.
        /// </summary>
        private void SetupTheGui() {
            CancelButton = exitButton;  // Allow the Esc key to close the form.
            ResizeGameBoard();
            SetupGameBoard();

            //####################### set intitial ComboBox Seletion to 6 here ####################################
            SetMaxNumberOfPlayers();
            SetupPlayersDataGridView();
              
        }// end SetupTheGui


        /// <summary>
        /// Resizes the entire form, so that the individual squares have their correct size, 
        /// as specified by SquareControl.SQUARE_SIZE.  
        /// This method allows us to set the entire form's size to approximately correct value 
        /// when using Visual Studio's Designer, rather than having to get its size correct to the last pixel.
        /// Pre:  none.
        /// Post: the board has the correct size.
        /// </summary>
        private void ResizeGameBoard() {

            // Uncomment all the lines in this method, once you've placed the boardTableLayoutPanel to your form.
            // Do not add any extra code.

            const int SQUARE_SIZE = SquareControl.SQUARE_SIZE;
            int currentHeight = boardTableLayoutPanel.Size.Height;
            int currentWidth = boardTableLayoutPanel.Size.Width;
            int desiredHeight = SQUARE_SIZE * NUM_OF_ROWS;
            int desiredWidth = SQUARE_SIZE * NUM_OF_COLUMNS;
            int increaseInHeight = desiredHeight - currentHeight;
            int increaseInWidth = desiredWidth - currentWidth;
            this.Size += new Size(increaseInWidth, increaseInHeight);
            boardTableLayoutPanel.Size = new Size(desiredWidth, desiredHeight);
        } // end ResizeGameBoard

        /// <summary>
        /// Creates each SquareControl and adds it to the boardTableLayoutPanel that displays the board.
        /// Pre:  none.
        /// Post: the boardTableLayoutPanel contains all the SquareControl objects for displaying the board.
        /// </summary>
        private void SetupGameBoard() {

            // ########################### Code needs to be written to perform the following  ###############################################
            /*
             *   taking each Square of Baord separately create a SquareContol object containing that Square (look at the Constructor for SquareControl)
             *   
             *   when it is either the Start Square or the Finish Square set the BackColor of the SquareControl to BurlyWood
             *   
             *   DO NOT set the BackColor of any other Square Control 
             * 
             *   Call MapSquareNumtoScreenRowAnd Column  to determine the row and column position of the SquareControl on the TableLayoutPanel
             *   
             *   Add the Control to the TaleLayoutPanel
             * 
             */
            SquareControl[] squares = new SquareControl[Board.NUMBER_OF_SQUARES];

            int column;
            int row;

            SquareControl startSquare = new SquareControl(Board.Squares[Board.START_SQUARE_NUMBER], HareAndTortoiseGame.Players);
            MapSquareNumToScreenRowAndColumn(0, out column, out row);
            boardTableLayoutPanel.Controls.Add(startSquare, column, row);
            startSquare.BackColor = Color.BurlyWood;

            for (int i = 0; i < squares.Length; i++) {
               squares[i] = new SquareControl(Board.Squares[i+1], HareAndTortoiseGame.Players);
               MapSquareNumToScreenRowAndColumn(i+1, out column, out row);
               boardTableLayoutPanel.Controls.Add(squares[i], column, row);
            } // end for

            SquareControl finishSqure = new SquareControl(Board.Squares[Board.FINISH_SQUARE_NUMBER], HareAndTortoiseGame.Players);
            MapSquareNumToScreenRowAndColumn(41, out column, out row);
            boardTableLayoutPanel.Controls.Add(finishSqure, column, row);
            finishSqure.BackColor = Color.BurlyWood;

        }// SetupGameBaord


        /// <summary>
        /// Tells the players DataGridView to get its data from the hareAndTortoiseGame.Players BindingList.
        /// Pre:  players DataGridView exists on the form.
        ///       HareAndTortoiseGame.Players BindingList is not null.
        /// Post: players DataGridView displays the correct rows and columns.
        /// </summary>
        private void SetupPlayersDataGridView() {

            // ########################### Code needs to be written  ###############################################
            playerBindingSource.DataSource = HareAndTortoiseGame.Players;
        } // end SetupPlayersDataGridView


        /// <summary>
        /// Resets the game, including putting all the players on the Start square.
        /// This requires updating what is displayed in the GUI, 
        /// as well as resetting the attrtibutes of HareAndTortoiseGame .
        /// This method is used by both the Reset button and 
        /// when a new value is chosen in the Number of Players ComboBox.
        /// Pre:  none.
        /// Post: the form displays the game in the same state as when the program first starts 
        ///       (except that any user names that the player has entered are not reset).
        /// </summary>
        private void ResetGame() {

            // ########################### Code needs to be written  ##############################################
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            HareAndTortoiseGame.SetPlayersAtTheStart();
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            SetMaxNumberOfPlayers();
            DisableRollDiceButton();
            ClearRadioButtons();
            EnableSingleStepGroupBox();
            DisableNextPlayerButton();
            MakeNextPlayerButtonInvisible();
            RefreshPlayersInfoInDataGridView();
            playerNumber = HareAndTortoiseGame.FIRST_PLAYER_NUMBER - 1;
        } // end ResetGame


        /// <summary>
        /// At several places in the program's code, it is necessary to update the GUI board,
        /// so that player's tokens (or "pieces") are removed from their old squares
        /// or added to their new squares. E.g. when all players are moved back to the Start.
        /// 
        /// For each of the players, this method is to use the GetSquareNumberOfPlayer method to find out 
        /// which square number the player is on currently, then use the SquareControlAt method
        /// to find the corresponding SquareControl, and then update that SquareControl so that it
        /// knows whether the player is on that square or not.
        /// 
        /// Moving all players from their old to their new squares requires this method to be called twice: 
        /// once with the parameter typeOfGuiUpdate set to RemovePlayer, and once with it set to AddPlayer.
        /// In between those two calls, the players locations must be changed by using one or more methods 
        /// in the HareAndTortoiseGame class. Otherwise, you won't see any change on the screen.
        /// 
        /// Because this method moves ALL players, it should NOT be used when animating a SINGLE player's
        /// movements from square to square.
        /// 
        /// 
        /// Post: the GUI board is updated to match the locations of all Players objects.
        /// </summary>
        /// <param name="typeOfGuiUpdate">Specifies whether all the players are being removed 
        /// from their old squares or added to their new squares</param>
        private void UpdatePlayersGuiLocations(TypeOfGuiUpdate typeOfGuiUpdate) {

            //##################### Code needs to be added here. ############################################################
            int numberOfPlayers = GetNumberOfPlayers();

            if (typeOfGuiUpdate == TypeOfGuiUpdate.RemovePlayer) {
                for (int i = 0; i < HareAndTortoiseGame.MAX_PLAYERS; i++) {
                    int squareNumber = GetSquareNumberOfPlayer(i);
                    SquareControl control = new SquareControl(Board.Squares[squareNumber], HareAndTortoiseGame.Players);
                    control = SquareControlAt(squareNumber);

                    if (control == null) {
                        throw new ArgumentException("Control invalid.");
                    } else {
                        control.Visible = true;
                        control.ContainsPlayers[i] = false;
                    } //end if
                } // end for
            } else if (typeOfGuiUpdate == TypeOfGuiUpdate.AddPlayer) {
                for (int i = 0; i < numberOfPlayers; i++) {
                    int squareNumber = GetSquareNumberOfPlayer(i);
                    SquareControl control = new SquareControl(Board.Squares[squareNumber], HareAndTortoiseGame.Players);
                    control = SquareControlAt(squareNumber);

                    if (control == null) {
                        throw new ArgumentException("Control invalid.");
                    } else {
                        control.Visible = true;
                        control.ContainsPlayers[i] = true;
                    } // end if
                } // end for
            } // end if

            RefreshBoardTablePanelLayout(); // Must be the last line in this method. DO NOT put it inside a loop.
        }// end UpdatePlayersGuiLocations

        /// <summary>
        /// Updates location of a player identified by player number
        /// Pre: Specified type of GUI update (AddPlayer or RemovePlayer)
        /// Post: The GUI borad is updated to match the location of the player
        /// </summary>
        /// <param name="typeOfGuiUpdate"></param>
        /// <param name="playerNumber"></param>
        private void UpdateSinglePlayerGuiLocation(TypeOfGuiUpdate typeOfGuiUpdate, int playerNumber) {
            if (typeOfGuiUpdate == TypeOfGuiUpdate.RemovePlayer) {
                int squareNumber = GetSquareNumberOfPlayer(playerNumber);
                SquareControl control = new SquareControl(Board.Squares[squareNumber], HareAndTortoiseGame.Players);
                control = SquareControlAt(squareNumber);

                if (control == null) {
                    throw new ArgumentException("Control invalid");
                } else {
                    control.Visible = true;
                    control.ContainsPlayers[playerNumber] = false;
                } // end if
            } else if (typeOfGuiUpdate == TypeOfGuiUpdate.AddPlayer) {
                int squareNumber = GetSquareNumberOfPlayer(playerNumber);
                SquareControl control = new SquareControl(Board.Squares[squareNumber], HareAndTortoiseGame.Players);
                control = SquareControlAt(squareNumber);

                if (control == null) {
                    throw new ArgumentException("Control invalid");
                } else {
                    control.Visible = true;
                    control.ContainsPlayers[playerNumber] = true;
                } // end if
            } // end if

            RefreshBoardTablePanelLayout();
        } // end UpdateSinglePlayerGuiLocation

        /*** START OF METHODS WHICH CHANGE PROPERTIES OF CONTROLS *****************************************************************************
        * 
        *   The methods in this section are statements which change properties of one or more controls.
        *   
        *   ********************************************************************************************************/
        
        /// <summary>
        /// Starts Timer
        /// Pre: None
        /// Post: Timer started
        /// </summary>
        private void StartTimer() {
            timer.Start();
        } // end StartTimer

        /// <summary>
        /// Stops Timer
        /// Pre: None
        /// Post: Timer stopped
        /// </summary>
        private void StopTimer() {
            timer.Stop();
        } // end StopTimer

        /// <summary>
        /// Enables Reset button
        /// Pre: None
        /// Post: Reset button enabled
        /// </summary>
        private void EnableResetButton() {
            resetButton.Enabled = true;
        } // end EnableResetButton

        /// <summary>
        /// Disables Reset button
        /// Pre: None
        /// Post: Reset button disabled
        /// </summary>
        private void DisableResetButton() {
            resetButton.Enabled = false;
        } // end DisableResetButton


        /// <summary>
        /// Make Next Player Button visible
        /// Pre: None
        /// Post: Next Player button is visible
        /// </summary>
        private void MakeNextPlayerButtonVisible() {
            nextPlayerButton.Visible = true;
        } // end MakeNextPlayerButtonVisible

        /// <summary>
        /// Makes Next Player button invisible
        /// Pre: None
        /// Post: Next Player button is invisible
        /// </summary>
        private void MakeNextPlayerButtonInvisible() {
            nextPlayerButton.Visible = false;
        } // end MakeNextPlayerButtonInvisible

        /// <summary>
        /// Enables Next Player button
        /// Pre: None
        /// Post: Next Player button enabled
        /// </summary>
        private void EnableNextPlayerButton() {
            nextPlayerButton.Enabled = true;
        } // end EnableNextPlayerButton

        /// <summary>
        /// Disables Next Player button
        /// Pre: None
        /// Post: Next Player button disabled
        /// </summary>
        private void DisableNextPlayerButton() {
            nextPlayerButton.Enabled = false;
        } // end DisableNextPlayerButton

        /// <summary>
        /// Clears radio buttons in Single Step group box
        /// Pre: None
        /// Post: Radio buttons cleared
        /// </summary>
        private void ClearRadioButtons() {
            yesRadioButton.Checked = false;
            noRadiobutton.Checked = false;
        } // end ClearRadioButtons

        /// <summary>
        /// Enables Number of Players combobox
        /// Pre: None
        /// Post: Number of Players combobox enabled
        /// </summary>
        private void EnableNumberOfPlayersComboBox() {
            numberOfPlayersComboBox.Enabled = true;
        } // end EnableNumberOfPlayersComboBox

        /// <summary>
        /// Disables Number of Players combobox
        /// Pre: None
        /// Post: Number of Players combobox disabled
        /// </summary>
        private void DisableNumberOfPlayersComboBox() {
            numberOfPlayersComboBox.Enabled = false;
        } // DisableNumberOfPlayersComboBox

        /// <summary>
        /// Enables Single Step group box
        /// Pre: None
        /// Post: Single Step group box enabled
        /// </summary>
        private void EnableSingleStepGroupBox() {
            singleStepGroupBox.Enabled = true;
        } // end EnableSingleStepGroupBox

        /// <summary>
        /// Disables Single Step group box
        /// Pre: None
        /// Post: Single Step group box disabled
        /// </summary>
        private void DisableSingleStepGroupBox() {
            singleStepGroupBox.Enabled = false;
        } // end DisableSingleStepGroupBox

        /// <summary>
        /// Enables Roll Dice button
        /// Pre: None
        /// Post: Roll Dice button enabled
        /// </summary>
        private void EnableRollDiceButton() {
            rollDiceButton.Enabled = true;
        } // end EnableRollDiceButton

        /// <summary>
        /// Disables Roll Dice button
        /// Pre: None
        /// Post: Roll Dice button disabled
        /// </summary>
        private void DisableRollDiceButton() {
            rollDiceButton.Enabled = false;
        } // end DisableRollDiceButton

        /// <summary>
        /// Sets maximum number of player
        /// Pre: None
        /// Post: Maximum number of player set
        /// </summary>
        private void SetMaxNumberOfPlayers() {
            numberOfPlayersComboBox.Text = "6";
        } // end SetMaxNumberOfPlayers

        /*** END OF METHODS WHICH CHANGE PROPERTIES OF CONTROLS **********************************************/



        /*** START OF LOW-LEVEL METHODS *****************************************************************************
         * 
         *   The methods in this section are "helper" methods that can be called to do basic things. 
         *   That makes coding easier in other methods of this class.
         *   You should NOT CHANGE these methods, except where otherwise specified in the assignment. 
         *   
         *   ********************************************************************************************************/

        /// <summary>
        /// Gets number of players from the combobox
        /// Pre: None
        /// Post: Number of players returned
        /// </summary>
        /// <returns>Converted (int) number of players</returns>
        private int GetNumberOfPlayers() {
            string numberOfPlayerString = (string)numberOfPlayersComboBox.SelectedItem;
            int numberOfPlayers = int.Parse(numberOfPlayerString);
            return numberOfPlayers;
        } // end GetNumberOfPlayers

        /// <summary>
        /// Changes players roll
        /// Pre: Specified number of players and player number
        /// Post: roll changed
        /// </summary>
        /// <param name="numberOfPlayers">Specified number of players</param>
        /// <param name="playerNumber">Specified player number</param>
        private void ChangePlayersRoll(int numberOfPlayers) {
            int winPlayer = playerNumber;

            if (playerNumber < numberOfPlayers - 1) {
                playerNumber++;
            } else if (playerNumber >= numberOfPlayers - 1) {
                playerNumber = HareAndTortoiseGame.FIRST_PLAYER_NUMBER;
            } // end if

            while (HareAndTortoiseGame.Players[playerNumber].Location == Board.FinishSquare) {
                if (playerNumber == numberOfPlayers - 1) {
                    playerNumber = HareAndTortoiseGame.FIRST_PLAYER_NUMBER - 1;
                } // end if
                playerNumber++;
            } // end while
        } // end ChangePlayersRoll

        /// <summary>
        /// When the SquareControl objects are updated (when players move to a new square),
        /// the board's TableLayoutPanel is not updated immediately.  
        /// Each time that players move, this method must be called so that the board's TableLayoutPanel 
        /// is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the board's TableLayoutPanel shows the latest information 
        ///       from the collection of SquareControl objects in the TableLayoutPanel.
        /// </summary>
        private void RefreshBoardTablePanelLayout() {
            // ################# Uncomment the following line once you've placed the boardTableLayoutPanel on your form. ########################################
            boardTableLayoutPanel.Invalidate(true);
        }//end RefreshBoardTablePanelLayout


        /// <summary>
        /// When the Player objects are updated (location, money, etc.),
        /// the players DataGridView is not updated immediately.  
        /// Each time that those player objects are updated, this method must be called 
        /// so that the players DataGridView is told to refresh what it is displaying.
        /// Pre:  none.
        /// Post: the players DataGridView shows the latest information 
        ///       from the collection of Player objects in the HareAndTortoiseGame.
        /// </summary>
        private void RefreshPlayersInfoInDataGridView() {
            HareAndTortoiseGame.Players.ResetBindings();
        } //end RefreshPlayersInfoInDataGridView


        /// <summary>
        /// Tells you the current square number that a given player is on.
        /// Pre:  a valid playerNumber is specified.
        /// Post: returns the square number of the square the player is on.
        /// </summary>
        /// <param name="playerNumber">The player number.</param>
        /// <returns>Returns the square number of the playerNumber.</returns>
        private int GetSquareNumberOfPlayer(int playerNumber) {
            Square playerSquare = HareAndTortoiseGame.Players[playerNumber].Location;
            return playerSquare.Number;
        } //end GetSquareNumberOfPlayer


        /// <summary>
        /// Tells you which SquareControl object is associated with a given square number.
        /// Pre:  a valid squareNumber is specified; and
        ///       the boardTableLayoutPanel is properly constructed.
        /// Post: the SquareControl object associated with the square number is returned.
        /// </summary>
        /// <param name="squareNumber">The square number.</param>
        /// <returns>Returns the SquareControl object associated with the square number.</returns>
        private SquareControl SquareControlAt(int squareNumber) {
            int columnNumber;
            int rowNumber;

            SquareControl control = new SquareControl(Board.Squares[squareNumber], HareAndTortoiseGame.Players);
            MapSquareNumToScreenRowAndColumn(squareNumber, out columnNumber, out rowNumber);
            control = (SquareControl)boardTableLayoutPanel.GetControlFromPosition(columnNumber, rowNumber);

            // Uncomment the following line once you've added the boardTableLayoutPanel to your form.
            return control;

            // Delete the following line once you've added the boardTableLayoutPanel to your form.

        } //end SquareControlAt


        /// <summary>
        /// For a given square number, tells you the corresponding row and column numbers.
        /// Pre:  none.
        /// Post: returns the row and column numbers, via "out" parameters.
        /// </summary>
        /// <param name="squareNumber">The input square number.</param>
        /// <param name="rowNumber">The output row number.</param>
        /// <param name="columnNumber">The output column number.</param>
        private static void MapSquareNumToScreenRowAndColumn(int squareNumber, out int columnNumber, out int rowNumber) {

            double column = squareNumber % 6.0;
            double row = squareNumber / 6.0;

            int realColumn = 0;
            int realRow = 0;

            if (row == 0 || Math.Floor(row) % 2 == 0) {
                realColumn = Convert.ToInt32(column % 6);
                realRow = Convert.ToInt32(Math.Ceiling(7 - row - 1));
            } else if (Math.Floor(row) % 2 != 0) {
                realColumn = Convert.ToInt32(5 - (column % 6));
                realRow = Convert.ToInt32(Math.Ceiling(7 - row - 1));
            } // end if

            rowNumber = realRow;
            columnNumber = realColumn;
        } // end MapSquareNumToScreenRowAndColumn

        /*** END OF LOW-LEVEL METHODS **********************************************/

        
        
        /*** START OF EVENT-HANDLING METHODS ***/
        // ####################### Place EVENT HANDLER Methods to this area of code  ##################################################
        /// <summary>
        /// Handle the Exit button being clicked.
        /// Pre:  the Exit button is clicked.
        /// Post: the game is closed.
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e) {
            // Terminate immediately, rather than calling Close(), 
            // so that we don't have problems with any animations that are running at the same time.
            Environment.Exit(0);  
        } // end exitButton_Click

        /// <summary>
        /// Handles the Roll Dice button being clicked
        /// Pre: Roll Dice button is clicked
        /// Post: The game runs according to the specified versions ('Single Step' or 'All Together')
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rollDiceButton_Click(object sender, EventArgs e) {
            int numberOfPlayers = GetNumberOfPlayers();
            bool finished = false;

            if (noRadiobutton.Checked == true) {
                UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);

                for (int i = 0; i < numberOfPlayers; i++) {
                    HareAndTortoiseGame.PlayOneRound(HareAndTortoiseGame.Players, i);
                    HareAndTortoiseGame.SetInactivePlayers(numberOfPlayers);
                } // end for

                UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
                finished = HareAndTortoiseGame.AllPlayerFinished(numberOfPlayers);

                if (finished == true) {
                    DisableRollDiceButton();
                    DisableNextPlayerButton();
                    HareAndTortoiseGame.IdentifyWinner(numberOfPlayers);
                } // end if

                RefreshPlayersInfoInDataGridView();
            } // end if
        } // end rollDiceButton_Click

        /// <summary>
        /// Handles the Reset button being clicked
        /// Pre: Reset button is clicked
        /// Post: The game is reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetButton_Click(object sender, EventArgs e) {
            ResetGame();
        } // end resetButton_Click

        /// <summary>
        /// Handles the Number of Players combobox being selected
        /// Pre: Number of players is selected
        /// Post: The game runs with specified number of players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberOfPlayersComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int numberOfPlayers = GetNumberOfPlayers();

            UpdatePlayersGuiLocations(TypeOfGuiUpdate.RemovePlayer);
            HareAndTortoiseGame.SetPlayersAtTheStart(numberOfPlayers);
            HareAndTortoiseGame.SetInactivePlayers(numberOfPlayers);
            UpdatePlayersGuiLocations(TypeOfGuiUpdate.AddPlayer);
            playerNumber = HareAndTortoiseGame.FIRST_PLAYER_NUMBER -1;
            EnableSingleStepGroupBox();
            ClearRadioButtons();
            DisableNextPlayerButton();
            MakeNextPlayerButtonInvisible();
            DisableRollDiceButton();
            RefreshPlayersInfoInDataGridView();
        } // end numberOfPlayersComboBox_SelectedIndexChanged

        /// <summary>
        /// Handles the Yes and No radio buttons in the Single Step groupbox being checked
        /// Pre: Yes or No button is checked
        /// Post: The game runs in whether 'single step' or 'all together' version
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void singleStepRadioButton_CheckedChanged(object sender, EventArgs e) {
            if (yesRadioButton.Checked == true) {
                DisableRollDiceButton();
                MakeNextPlayerButtonVisible();
                EnableNextPlayerButton();
                DisableSingleStepGroupBox();   
            } else if (noRadiobutton.Checked == true) {
                EnableRollDiceButton();
                DisableSingleStepGroupBox();
                DisableNextPlayerButton();
                MakeNextPlayerButtonInvisible();
            } // end if
        } // end singleStepRadioButton_CheckedChanged

        /// <summary>
        /// Handles the Next Player's Roll button being clicked
        /// Pre: Next Player's Roll button is clicked
        /// Post: Player number is increased
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextPlayerButton_Click(object sender, EventArgs e) {
            int numberOfPlayers = GetNumberOfPlayers();

            StartTimer();
            ChangePlayersRoll(numberOfPlayers);
            DisableNextPlayerButton();
            DisableResetButton();
        } // end nextPlayerButton_Click

        // Tick counter for Timer
        int tick = 0;
        int[] tickCounter = new int[HareAndTortoiseGame.MAX_DICE_FACE];

        /// <summary>
        /// The event handler for Timer
        /// Pre: The Roll Dice button is clicked
        /// Post: Timer starts ticking
        ///       When the player reaches the specified square, it stops ticking
        /// NOTE: This method involves with animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e) {
            int numberOfPlayers = GetNumberOfPlayers();
            int diceResultNumber = HareAndTortoiseGame.GetDiceResult(playerNumber);
            bool finished = false;
            tickCounter[tick] = diceResultNumber;
            tick++;

            UpdateSinglePlayerGuiLocation(TypeOfGuiUpdate.RemovePlayer, playerNumber);
            HareAndTortoiseGame.MoveSingleSquare(playerNumber);
            UpdateSinglePlayerGuiLocation(TypeOfGuiUpdate.AddPlayer, playerNumber);            

            if (HareAndTortoiseGame.Players[playerNumber].Location == Board.FinishSquare) {
                StopTimer();
                EnableResetButton();
                RefreshPlayersInfoInDataGridView();
                EnableNextPlayerButton();
                tick = 0;
            } else if (tick == tickCounter[0]) {
                HareAndTortoiseGame.CheckMoney(playerNumber);

                if (HareAndTortoiseGame.Players[playerNumber].Location.Name == "LotteryWin") {
                    tick = tick - 1;
                } else {
                    StopTimer();
                    EnableResetButton();
                    RefreshPlayersInfoInDataGridView();
                    EnableNextPlayerButton();
                    tick = 0;
                } 
            } // end if


            finished = HareAndTortoiseGame.AllPlayerFinished(numberOfPlayers);
            if (finished == true) {
                DisableRollDiceButton();
                DisableNextPlayerButton();
                HareAndTortoiseGame.IdentifyWinner(numberOfPlayers);
            } // end if

            RefreshPlayersInfoInDataGridView();
        } // end timer_Tick

        /*** END OF EVENT-HANDLING METHODS ***/
    } // end class HareAndTortoiseForm
}

