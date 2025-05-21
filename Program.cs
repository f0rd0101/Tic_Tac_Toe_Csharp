using System;
using System.Globalization;

class ConsoleApp1
{
    // Класс Игроков, нужен для того чтобы игроки впринципе существовали как некая сущность
    class Player
    {
        private string name;
        private char symbol;
          
        //Конструктор класса, который включает обязательные параметры при создании объекта класса
        public Player(string name, char symbol)
        {
            this.name = name;
            this.symbol = symbol;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
    }
    //Метод для заполнения массива и создания первоначальной игровой доски
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
    static void BoardDisplay(ref char[,] board)
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
    // Метод для обработки ходовы
    static void MakeMove(char[,] board, Player CurrentPlayer)
    {
        Console.WriteLine($"{CurrentPlayer.Name} your turn to make move");
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
                board[row, col] = CurrentPlayer.Symbol;
                BoardDisplay(ref board);
                break;
            }      
        }
      
    }

    static void CheckWinner(char[,] board, ref Boolean isWinning, Player CurrentPlayer)
    {
        char SymbolOfPlayer = CurrentPlayer.Symbol;
        if (board[0, 0] == SymbolOfPlayer && board[0, 1] == SymbolOfPlayer && board[0, 2] == SymbolOfPlayer ||
            board[1, 0] == SymbolOfPlayer && board[1, 1] == SymbolOfPlayer && board[1, 2] == SymbolOfPlayer ||
            board[2, 0] == SymbolOfPlayer && board[2, 1] == SymbolOfPlayer && board[2, 2] == SymbolOfPlayer ||

            // Вертикаль
            board[0, 0] == SymbolOfPlayer && board[1, 0] == SymbolOfPlayer && board[2, 0] == SymbolOfPlayer ||
            board[0, 1] == SymbolOfPlayer && board[1, 1] == SymbolOfPlayer && board[2, 1] == SymbolOfPlayer ||
            board[0, 2] == SymbolOfPlayer && board[1, 2] == SymbolOfPlayer && board[2, 2] == SymbolOfPlayer ||

            // Диагонали
            board[0, 0] == SymbolOfPlayer && board[1, 1] == SymbolOfPlayer && board[2, 2] == SymbolOfPlayer ||
            board[0, 2] == SymbolOfPlayer && board[1, 1] == SymbolOfPlayer && board[2, 0] == SymbolOfPlayer)
        {
            isWinning = true;
            Console.WriteLine($"Player {CurrentPlayer.Name} won the game!");
        }
    }  
    
    static void Main(string[] args)
    {
        Boolean isWinning = false;
        Player player1 = new Player("Nick", 'X');
        Player player2 = new Player("Sasha", 'O');
        char[,] board = new char[3, 3];
        Player CurrentPlayer = player1;
        BoardFill(board);
        BoardDisplay(ref board);
        while (isWinning == false)
        {
          
            Console.WriteLine();
            MakeMove(board,CurrentPlayer); 
            CheckWinner(board,ref isWinning,CurrentPlayer);
            //Смена сторон
            CurrentPlayer = (CurrentPlayer == player1) ? player2 : player1;
        }
       
        
    }    
}

