using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;

using System.ComponentModel;  // for BindingList.

namespace SharedGameClasses {
    /// <summary>
    /// Plays a game called Hare and the Tortoise
    /// 
    /// Author: Thanat Chokwijitkul 9234900
    /// Date: October 2014
    /// </summary>
    public static class HareAndTortoiseGame {
        
        // Minimum and maximum players per game
        private const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;

        // First player's number
        public const int FIRST_PLAYER_NUMBER = 0;

        // Initial amount after resetting
        private const int INITIAL_AMOUNT = 100;
        private const int INACTIVE_AMOUNT = 0;
        private const int BAD_INVESTMENT_AMOUNT = 25;
        private const int LOTTERY_WIN_AMOUNT = 10;

        // The dice
        public const int MIN_DICE_FACE = 1;
        public const int MAX_DICE_FACE = 12;
        private static Die die1 = new Die(), die2 = new Die();

        // A BindingList is like an array that can grow and shrink. 
        // 
        // Using a BindingList will make it easier to implement the GUI with a DataGridView
        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players {
            get {
                return players;
            }
        }

        
        private static int numberOfPlayers = 6;  // The value 6 is purely to avoid compiler errors.

        public static int NumberOfPlayers {
            get {
                return numberOfPlayers;
            }
            set {
                numberOfPlayers = value;
            }
        }

        // Is the current game finished?
        private static bool finished = false;
        public static bool Finished {
            get {
                return finished;
            }
        }

        /// Some default player names.  
        /// 
        /// These are purely for testing purposes and when initialising the players at the start
        /// 
        /// These values are intended to be read-only.  I.e. the program code should never update this array.
        private static string[] defaultNames = { "One", "Two", "Three", "Four", "Five", "Six" };

        // Some colours for the players' tokens (or "pieces"). 
        private static Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Black, Brushes.Red, 
                                                              Brushes.Gold, Brushes.GreenYellow, 
                                                              Brushes.Fuchsia, Brushes.White };

                

        /// <summary>
        /// Initialises each of the players and adds them to the players BindingList.
        /// This method is called only once, when the game first startsfrom HareAndTortoiseForm.
        ///
        /// Pre:  none.
        /// Post: all the game's players are initialised.
        /// </summary>
        public static void InitialiseAllThePlayers() {

            //##################### Code needs to be added here. ############################################################
            Player[] player = new Player[MAX_PLAYERS];

            // Initialises each of the players
            for (int i = 0; i < MAX_PLAYERS; i++) {
                player[i] = new Player(defaultNames[i], Board.StartSquare);
                player[i].PlayerTokenColour = playerTokenColours[i];
            } // end for

            // Adds players to the players BindingList
            for (int i = 0; i < MAX_PLAYERS; i++) {
                players.Add(player[i]);
            } // end for

        } // end InitialiseAllThePlayers

        /// <summary>
        /// Puts all the players on the Start square.
        /// Pre:  none.
        /// Post: the game is reset as though it is being played for the first time.
        /// </summary>
        public static void SetPlayersAtTheStart() {

            //##################### Code needs to be added here. ############################################################
            for (int i = 0; i < MAX_PLAYERS; i++) {
                players[i].Location = Board.StartSquare;
                players[i].Name = defaultNames[i];
                players[i].Money = INITIAL_AMOUNT;
                players[i].Winner = false;
            } // end for
        } // end SetPlayersAtTheStart


        /// <summary>
        /// Sets specified number of players at the start square
        /// Pre: Specified number of players
        /// Post: A correct number of players is set at the start square
        /// </summary>
        /// <param name="numberOfPlayers">Specified number of players</param>
        public static void SetPlayersAtTheStart(int numberOfPlayers) {
            for (int i = 0; i < numberOfPlayers; i++) {
                players[i].Location = Board.StartSquare;
                players[i].Name = defaultNames[i];
                players[i].Money = INITIAL_AMOUNT;
                players[i].Winner = false;
            } // end for
        } // end SetPlayersAtTheStart

        /// <summary>
        /// Sets inactive players at the Finish square
        /// Pre: Specified number of players in order to tell the program
        ///      how many players are inactive
        /// Post: Inactive players are set at the Finish square
        /// </summary>
        /// <param name="numberOfPlayers">Specified number of players</param>
        public static void SetInactivePlayers(int numberOfPlayers) {
            for (int i = MAX_PLAYERS - 1; i >= numberOfPlayers; i--) {
                players[i].Location = Board.FinishSquare;
                players[i].Name = defaultNames[i];
                players[i].Money = INACTIVE_AMOUNT;
                players[i].Winner = false;
            } // end for
        } // end SetInactivePlayers


        /// <summary>
        /// Plays the game for one round
        /// It is called "one round" once all the players have moved
        /// Pre: Specified player number
        /// Post: The game is played for one round
        /// </summary>
        /// <param name="players">All the players in the BindingList</param>
        /// <param name="playerNumber">Specified player number</param>
        public static void PlayOneRound(BindingList<Player> players, int playerNumber) {
            players[playerNumber].Play(die1, die2);
        } // end PlayOneRound


        /// <summary>
        /// Gets a number of squares to move forward for a player
        /// Pre: Specified Player number
        /// Post: A number of squares returned
        /// NOTE: This method is used with animation
        /// </summary>
        /// <param name="playerNumber">Specified player number</param>
        /// <returns>A number of squares for the player to move forward</returns>
        public static int GetDiceResult(int playerNumber) {
            int diceResult = players[playerNumber].DiceRollingResult(die1, die2);
            return diceResult;
        } // end GetDiceResult


        /// <summary>
        /// Moves a player one square forward
        /// Pre: Specified player number
        /// Post: The player is moved one square forward
        /// NOTE: This method is used with animation
        /// </summary>
        /// <param name="playerNumber">Specified player number</param>
        public static void MoveSingleSquare(int playerNumber) {
            players[playerNumber].SingleMove();
        } // end MoveSingleSquare

        /// <summary>
        /// Calculates the amount of money when the player is at
        /// the Lottery Win or Bad Investment squares
        /// Pre: Specified player number
        /// Post: The amount of money is calculated
        /// NOTE: This method involves with animation
        /// </summary>
        /// <param name="playerNumber">Specified player number</param>
        public static void CheckMoney(int playerNumber) {
            if (players[playerNumber].Location.Name == "LotteryWin") {
                players[playerNumber].Credit(LOTTERY_WIN_AMOUNT);
            } else if (players[playerNumber].Location.Name == "BadInvestment") {
                players[playerNumber].Debit(BAD_INVESTMENT_AMOUNT);
            } // end if
        } // end CheckMoney


        /// <summary>
        /// Checks if all players are at the Finish square
        /// Pre: Specified number of players
        /// Post: Return true if all players are at the Finish square
        /// </summary>
        /// <param name="numberOfPlayers">Specified number of players</param>
        /// <returns>Return true if all players are finished</returns>
        public static bool AllPlayerFinished(int numberOfPlayers) {
            bool[] finished = new bool[numberOfPlayers];
            bool allFinished = false;

            for (int i = 0; i < numberOfPlayers; i++) {
                if (players[i].Location == Board.FinishSquare) {
                    finished[i] = true;
                } // end if
            } // end for

            if (finished.Contains(false)) {
                allFinished = false;
            } else {
                allFinished = true;
            } // end if

            return allFinished;
        } // end AllPlayerFinished

        /// <summary>
        /// Collects amounts of money once the game is finished
        /// Pre: Specified number of players
        /// Post: Amounts of money returned
        /// </summary>
        /// <param name="numberOfPlayers">Specified number of players</param>
        /// <returns>Amounts of money</returns>
        public static int[] CollectTotalMoney(int numberOfPlayers) {
            int[] collectedMoney = new int[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++) {
                collectedMoney[i] = players[i].Money;
            } // end for

            return collectedMoney;
        } // end CollectTotalMoney

        /// <summary>
        /// Compares the amounts of money collected once the game is finished
        /// to find the largest amount
        /// Pre: Specified number of players
        /// Post: Largest amount of money returned
        /// </summary>
        /// <param name="numberOfPlayers">Specfied number of players</param>
        /// <returns>Largest amount of money</returns>
        public static int FindLargestTotalAmountOfMoney(int numberOfPlayers) {
            int maxValue = 0;
            int[] totalMoney = new int[numberOfPlayers];
            totalMoney = CollectTotalMoney(numberOfPlayers);

            for (int i = 0; i < totalMoney.Length; i++) {
                if (totalMoney[i] > maxValue) {
                    maxValue = totalMoney[i];
                } // end if
            } // end for

            return maxValue;
        } // end FindLargestTotalAmountOfMoney


        /// <summary>
        /// Identifies the winner(s)
        /// The winner(s) is the player(s) who has the most money
        /// Pre: Specified number of players
        /// Post: The winner(s) is identified
        ///       The winner chackbox(s) is checked
        /// </summary>
        /// <param name="numberOfPlayers">Specified number of players</param>
        public static void IdentifyWinner(int numberOfPlayers) {
            int winningMoney = FindLargestTotalAmountOfMoney(numberOfPlayers);

            for (int i = 0; i < numberOfPlayers; i++) {
                if (players[i].Money == winningMoney) {
                    players[i].Winner = true;
                } // end if
            } // end for
        } // end IdentifyWinner

    } //end class HareAndTortoiseGame
}
