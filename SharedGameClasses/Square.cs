using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SharedGameClasses {
    /// <summary>
    /// A Ordinary square as well as being the superclass
    ///  for a Bad Investment Square and a Lottery Win Square
    /// </summary>
    public class Square {

        // This square's number.
        private int number;
        public int Number {
            get {
                return number;
            }
        }

        // The name of this square. 
        // This is the ‘type’ of square it is: Ordinary, Start, Finish, Lottery Win or Bad Investment.
        private string name;
        public string Name {
            get {
                return name;
            }
        }

       public Square NextSquare {
            get {
                Square resultSquare = Board.Squares[Number];
                Debug.Assert(Number <= Board.FINISH_SQUARE_NUMBER, "Number < Board.FINISH_SQUARE_NUMBER",
                    "The Finish square is the last square.");
                if (Number == Board.FINISH_SQUARE_NUMBER || Number > Board.FINISH_SQUARE_NUMBER) {
                    resultSquare = Board.FinishSquare;
                } else if (Number >= Board.START_SQUARE_NUMBER && Number < Board.FINISH_SQUARE_NUMBER) {
                    resultSquare = Board.Squares[Number + 1];
                }
                return resultSquare;
            }
        } 

        /// <summary>
        /// Parameterless constructor.
        /// Do not want the generic default constructor to be used
        /// as there is no way to set the square's data.
        /// This replaces the compiler's generic default constructor.
        /// Pre:  none
        /// Post: ALWAYS throws an ArgumentException.
        /// </summary>
        /// <remarks>NOT TO BE USED!</remarks>
        public Square() {
            throw new ArgumentException("Parameterless constructor invalid.");
        } // end Square constructor


        /// <summary>
        /// Constructor with initialisation parameters.
        /// </summary>
        /// <param name="name">name for this square</param>
        /// <param name="number">number for this square</param>
        public Square(int number, string name) {
            this.number = number;
            this.name = name;
        } // end Square constructor


        /// <summary>
        /// Performs the necessary action when a player lands on this type of square.
        /// 
        /// Landing on an ordinary square has
        ///    no consequential action to be performed at this time.
        ///    
        /// Pre:  the player who lands on this square
        /// Post: none.
        /// </summary>
        /// <param name="player">who landed on this square</param>
        /// <remarks>Virtual method</remarks>
        public virtual void LandOn(Player player) {
            // This method is implemented within subclasses of Square
            // perhaps something will be done in a future version of this game
            // for an Ordinary square
        } //end LandOn


        /// <summary>
        /// Check if a square is the Start square.
        /// Pre:  an initialised square location to check
        /// Post: whether the supplied location is the Start square.
        /// </summary>
        /// <returns>
        /// true if the square is the Start square,
        /// false otherwise
        /// </returns>
        public bool IsStart() {
            // check whether the location is the Start square.
            return (number == Board.START_SQUARE_NUMBER);
        } //end IsStart


        /// <summary>
        /// Checks if a square is the Finish square.
        /// Pre:  an initialised square location to check
        /// Post: whether the supplied location is the Finish square.
        /// </summary>
        /// <returns>
        /// true if the square is the Finish square,
        /// false otherwise
        /// </returns>
        public bool IsFinish() {
            // check if the square is a Finish square.
            // ############################ Code needs to be added here ################################################
            return (number == Board.FINISH_SQUARE_NUMBER); //this return is to satisy the compiler - delete this line when have written code for this method
        } // end IsFinish

    } // end class Square
}
