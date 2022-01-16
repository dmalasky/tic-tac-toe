using System;
using System.Collections.Generic;


namespace tictactoe
{

    ///A game of tic-tac-toe.

    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = NewBoard();
            string currentPlayer = "x";

            while (!IsGameOver(board))
            {
                DisplayBoard(board);
                
                
                int choice = GetMoveChoice(currentPlayer);
                bool allowed = SpotTaken(board, choice);
                if (allowed == true)
                {
                    MakeMove(board, choice, currentPlayer);

                    currentPlayer = GetNextPlayer(currentPlayer);
                }
            }
            
            DisplayBoard(board);
            Console.WriteLine("Good game. Thanks for playing!");

        }
        
        ///Creates a list of strings 1-9 to fill up the board
        static List<string> NewBoard()
        {
                List<string> board = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }
            
            return board;
        }

        ///Displays the board
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");

        }

        /// Determines who the winner is.
        static bool IsWinner(List<string> board, string player)
        {
            bool IsWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                IsWinner = true;
            }
            return IsWinner;
        }

        /// Determines if the board is full and the game is a tie
        static bool IsTie(List<string> board)
        {
            bool noDigits = false;

            foreach (string value in board) 
            {
                if (char.IsDigit(value[0]))
                {
                    noDigits = true;
                    break;
                }
            }
        
        return !noDigits;

        }

        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;

            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
            {
                isGameOver = true;
            }

            return isGameOver;
        }
        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";

            }

            return nextPlayer;

        }
        static int GetMoveChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            string move = Console.ReadLine();

            int choice = int.Parse(move);



            return choice;
        }
        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {
            int index = choice - 1;
        
            board[index] = currentPlayer;
                
               
        
            
        }
        static bool SpotTaken(List<string> board, int choice)
        {
            int index = choice - 1;
            bool spotTaken = false;
            
            if ((board[index] == "x") || (board[index] == "o"))
            {
                Console.WriteLine("That place is taken.");
                spotTaken = true;
            }
           

           return !spotTaken;
            
        }
    }
}
