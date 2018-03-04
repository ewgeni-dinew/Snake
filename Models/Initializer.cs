using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Initializer
{
    public static char[,] InitializeField(short fieldRows,short fieldColumns)
    {
        var field = new char[fieldRows, fieldColumns];
        for (int i = 0; i < fieldRows; i++)
        {
            for (int j = 0; j < fieldColumns; j++)
                field[i, j] = '-';
        }
        return field;
    }

    public static Snake InitializeSnake(char[,] field)
    {
        var snake = new Snake();
        foreach (var point in snake.BodyPoints)
            field[point.pY, point.pX] = point.Symbol;

        var headPoint = snake.BodyPoints.Last();
        field[headPoint.pY, headPoint.pX] = snake.HeadSymbol;

        return snake;
    }

    public static Point InitializePrizePoint(Snake snake, char[,] field,
        short fieldRows,short fieldColumns)
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
}

