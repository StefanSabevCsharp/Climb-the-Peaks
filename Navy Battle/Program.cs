int n = int.Parse(Console.ReadLine());

char[,] matrix = new char[n, n];
int playerRow = 0;
int playerCol = 0;
int cruisersDestroyed = 0;
int hittedMines = 0;
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = input[j];
        if (matrix[i, j] == 'S')
        {
            playerRow = i;
            playerCol = j;
        }
    }
}
string direction = Console.ReadLine();

while (cruisersDestroyed != 3 || hittedMines != 3)
{
    if (direction == "left")
    {
        if (CheckMine(playerRow, playerCol - 1, matrix))
        {
            hittedMines++;
            if (hittedMines == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{playerRow}, {playerCol}]!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow, playerCol - 1] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }

        }
        else if (CheckCruiser(playerRow, playerCol - 1, matrix))
        {
            cruisersDestroyed++;
            if (cruisersDestroyed == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow, playerCol - 1] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
        }
        matrix[playerRow, playerCol] = '-';
        matrix[playerRow, playerCol - 1] = 'S';
        playerCol--;

    }
    else if (direction == "right")
    {
        if (CheckMine(playerRow, playerCol + 1, matrix))
        {
            hittedMines++;
            if (hittedMines == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{playerRow}, {playerCol}]!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow, playerCol + 1] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }

        }
        else if (CheckCruiser(playerRow, playerCol + 1, matrix))
        {
            cruisersDestroyed++;
            if (cruisersDestroyed == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow, playerCol + 1] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
        }
        matrix[playerRow, playerCol] = '-';
        matrix[playerRow, playerCol + 1] = 'S';
        playerCol++;
    }
    else if (direction == "up")
    {
        if (CheckMine(playerRow - 1, playerCol, matrix))
        {
            hittedMines++;
            if (hittedMines == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{playerRow}, {playerCol}]!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow - 1, playerCol] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }

        }
        else if (CheckCruiser(playerRow - 1, playerCol, matrix))
        {
            cruisersDestroyed++;
            if (cruisersDestroyed == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow - 1, playerCol] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
        }
        matrix[playerRow, playerCol] = '-';
        matrix[playerRow - 1, playerCol] = 'S';
        playerRow--;
    }
    else if (direction == "down")
    {
        if (CheckMine(playerRow + 1, playerCol, matrix))
        {
            hittedMines++;
            if (hittedMines == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{playerRow}, {playerCol}]!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow + 1, playerCol] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }

        }
        else if (CheckCruiser(playerRow + 1, playerCol, matrix))
        {
            cruisersDestroyed++;
            if (cruisersDestroyed == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                matrix[playerRow, playerCol] = '-';
                matrix[playerRow + 1, playerCol] = 'S';
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
        }
        matrix[playerRow, playerCol] = '-';
        matrix[playerRow + 1, playerCol] = 'S';
        playerRow++;
    }
    direction = Console.ReadLine();
}

bool CheckCruiser(int row, int col, char[,] matrix)
{
    if (matrix[row, col] == 'C')
    {
        return true;
    }
    return false;
}

bool CheckMine(int row, int col, char[,] matrix)
{
    if (matrix[row, col] == '*')
    {
        return true;
    }
    return false;
}
void PrintMatrix(char[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j]);
        }
        Console.WriteLine();
    }
}
