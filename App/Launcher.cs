using System;
using System.Linq;
using System.Text;

public class Launcher
{
    const short fieldRows = 7;
    const short fieldColumns = 14;

    static void Main()
    {
        //Initialize Field
        var field=InitializeField();
        
        //Initialize Snake
        var snake = InitializeSnake(field);

        //Initialize Prize
        var prize = InitializePrizePoint(snake,field);

        while (true)
        {
            Console.WriteLine(PrintField(field));

            Console.Write("InputCommand: ");
            var command = Console.ReadLine();

            if (command.Equals("end"))
                break;

            var tail = snake.BodyPoints.First();
            var headPoint = snake.BodyPoints.Last();
            char directionChar;
            Point newPoint;

            switch (command)
            {
                case "d":
                    newPoint = new Point(headPoint.pY, (short)(headPoint.pX + 1));
                    TryMoveSnake(field,snake,headPoint,tail,prize,directionChar = '>', newPoint);
                    break;

                case "a":
                    newPoint = new Point(headPoint.pY, (short)(headPoint.pX - 1));
                    TryMoveSnake(field, snake, headPoint, tail, prize, directionChar='<', newPoint);
                    break;

                case "w":
                    newPoint = new Point((short)(headPoint.pY - 1), headPoint.pX);
                    TryMoveSnake(field, snake, headPoint, tail, prize, directionChar='^', newPoint);
                    break;

                case "s":
                    newPoint = new Point((short)(headPoint.pY + 1), headPoint.pX);
                    TryMoveSnake(field, snake, headPoint, tail, prize, directionChar='V', newPoint);
                    break;

                default:
                    ThrowInvalidInputMessage(command);
                    Console.Clear();
                    continue;
            }
            if (IsPrizeEaten(snake, prize))
                prize = InitializePrizePoint(snake, field);
            else
                RemoveSnakeTail(snake, field, tail);

            Console.Clear();
        }
    }

    private static void RemoveSnakeTail(Snake snake, char[,] field, Point tail)
    {
        field[tail.pY, tail.pX] = '-';
        snake.BodyPoints.Remove(tail);
    }

    private static bool IsPrizeEaten(Snake snake,Point prize)
    {
       return snake.BodyPoints.Any(p => p.pX == prize.pX && p.pY == prize.pY);
    }

    private static void TryMoveSnake(char[,] field, Snake snake, Point headPoint,
        Point tail, Point prize,char directionChar,Point newPoint)
    {
        field[headPoint.pY, headPoint.pX] = '8';
        snake.BodyPoints.Add(newPoint);
        headPoint = snake.BodyPoints.Last();
        field[headPoint.pY, headPoint.pX] = directionChar;
    }

    private static void ThrowInvalidInputMessage(string command)
    {
        Console.WriteLine($"The input command \"{command}\" was invalid! " + Environment.NewLine +
                        "Press any key to continue.");
        Console.ReadLine();
    }

    private static Point InitializePrizePoint(Snake snake, char[,] field)
    {
        var random = new Random();
        Point prize;
        short prizeRow, prizeCol;

        do
        {
            prizeRow = (short)random.Next(0, fieldRows);
            prizeCol = (short)random.Next(0, fieldColumns);
            prize = new Point(prizeRow, prizeCol);
        } while (snake.BodyPoints.Any(p => p.pX == prize.pX && p.pY == prize.pY));
        field[prizeRow, prizeCol] = '$';

        return prize;
    }

    private static Snake InitializeSnake(char[,] field)
    {
        var snake = new Snake();
        foreach (var point in snake.BodyPoints)
            field[point.pY, point.pX] = point.Symbol;
        
        var headPoint = snake.BodyPoints.Last();
        field[headPoint.pY, headPoint.pX] = snake.HeadSymbol;

        return snake;
    }

    private static char[,] InitializeField()
    {
        var field= new char[fieldRows, fieldColumns];
        for (int i = 0; i < fieldRows; i++)
        {
            for (int j = 0; j < fieldColumns; j++)
                field[i, j] = '-';
        }
        return field;
    }

    private static string PrintField(char[,] field)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < fieldRows; i++)
        {
            for (int j = 0; j < fieldColumns; j++)
                sb.Append(field[i, j]);
            sb.AppendLine();
        }
        return sb.ToString();
    }
}

