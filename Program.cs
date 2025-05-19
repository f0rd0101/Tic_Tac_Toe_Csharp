using System;
using System.Globalization;

class ConsoleApp1
{
    static void BoardFill(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = '.';
            }
        }
    }
    static void BoardDisplay( ref char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i,j] + " " );
            }

            Console.WriteLine();
        }
    }

    static void MakeMove(ref char[,] board)
    {
        Console.WriteLine("Enter move");
        while (true)
        {
            int row, col;
            string[] sep = Console.ReadLine().Split(' ');
            row =  int.Parse(sep[0]) -1;
            col = int.Parse(sep[1]) -1;
            
            
            if (row < 0 || row >= 3 || col < 0 || col >= 3)
            {
                Console.WriteLine("You went out of bounds! Enter move");
            }
            else if (board[row, col] != '.')
            {
                Console.WriteLine("This cell is already occupied!. Enter move");
            }
            else
            {
                board[row, col] = 'X';
                BoardDisplay(ref board);
                break;
            }      
        }
      
    }

    static void CheckWinner( ref char[,] board, ref Boolean isWinning)
    {
       
        if (board[0, 0] == 'X' && board[0, 1] == 'X' && board[0, 2] == 'X' ||
            board[1, 0] == 'X' && board[1, 1] == 'X' && board[1, 2] == 'X' ||
            board[2, 0] == 'X' && board[2, 1] == 'X' && board[2, 2] == 'X' ||

            // Вертикаль
            board[0, 0] == 'X' && board[1, 0] == 'X' && board[2, 0] == 'X' ||
            board[0, 1] == 'X' && board[1, 1] == 'X' && board[2, 1] == 'X' ||
            board[0, 2] == 'X' && board[1, 2] == 'X' && board[2, 2] == 'X' ||

            // Диагонали
            board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X' ||
            board[0, 2] == 'X' && board[1, 1] == 'X' && board[2, 0] == 'X')
        {
            isWinning = true;
            Console.WriteLine("You won!");
        }
    }  
    
    static void Main(string[] args)
    {
        Boolean isWinning = false;
        char[,] board = new char[3, 3];
        BoardFill(board);
        BoardDisplay(ref board);
        while (isWinning == false)
        {
          
            Console.WriteLine();
            MakeMove(ref board); 
            CheckWinner(ref board,ref isWinning);
            
        }
       
        
    }    
}

