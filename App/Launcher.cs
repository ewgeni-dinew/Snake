using System;
using System.Linq;
using System.Text;

public class Launcher
{
    const short fieldRows = 7;
    const short fieldColumns = 14;
    const char northArrow = '^';
    const char southArrow = 'V';
    const char eastArrow = '>';
    const char westArrow = '<';

    static void Main()
    {
        //Initialize Field
        var field=Initializer.InitializeField(fieldRows, fieldColumns);
        
        //Initialize Snake
        var snake = Initializer.InitializeSnake(field);

        //Initialize Prize
        var prize = Initializer.InitializePrizePoint(snake,field,fieldRows,fieldColumns);

        var highScore = 0;
        
        try
        {
            while (true)
            {
                Console.WriteLine(PrintField(field));

                Console.Write("InputCommand: ");
                var command = Console.ReadLine();

                if (command.Equals("end"))
                    break;

                var tail = snake.BodyPoints.First();
                var headPoint = snake.BodyPoints.Last();
                Point newPoint;

                try
                {
                    switch (command)
                    {
                        case "d":
                            newPoint = new Point(headPoint.pY, (short)(headPoint.pX + 1));
                            Mover.TryMoveSnake(field, snake, headPoint, tail, prize, eastArrow, newPoint);
                            break;

                        case "a":
                            newPoint = new Point(headPoint.pY, (short)(headPoint.pX - 1));
                            Mover.TryMoveSnake(field, snake, headPoint, tail, prize, westArrow, newPoint);
                            break;

                        case "w":
                            newPoint = new Point((short)(headPoint.pY - 1), headPoint.pX);
                            Mover.TryMoveSnake(field, snake, headPoint, tail, prize, northArrow, newPoint);
                            break;

                        case "s":
                            newPoint = new Point((short)(headPoint.pY + 1), headPoint.pX);
                            Mover.TryMoveSnake(field, snake, headPoint, tail, prize, southArrow, newPoint);
                            break;

                        default:
                            throw new InvalidInputMove();
                    }
                }
                catch (InvalidInputMove ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                
                if (IsPrizeEaten(snake, prize))
                {
                    prize = Initializer.InitializePrizePoint(snake, field, fieldRows, fieldColumns);
                    highScore++;
                }
                else
                    Mover.RemoveSnakeTail(snake, field, tail);

                Console.Clear();
            }

        }
        catch (SuddenDeathException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"HighScore: {highScore}");
        }
        catch (InvalidSnakeBodyCount ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"HighScore: {highScore}");
        }
    }
    
    private static bool IsPrizeEaten(Snake snake,Point prize)
    {
       return snake.BodyPoints.Any(p => p.pX == prize.pX && p.pY == prize.pY);
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

