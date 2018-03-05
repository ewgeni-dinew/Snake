using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Mover
{
    public static void TryMoveSnake(char[,] field, Snake snake, Point headPoint,
        Point tail, Point prize, char directionChar, Point newPoint)
    {
        if (snake.BodyPoints.Any(p => p.pX == newPoint.pX && p.pY == newPoint.pY))
        {
            throw new SuddenDeathException();
        }
        field[headPoint.pY, headPoint.pX] = '8';
        snake.AddPoint(newPoint,(short)field.GetLength(0),(short)field.GetLength(1));
        headPoint = snake.BodyPoints.Last();
        field[headPoint.pY, headPoint.pX] = directionChar;
    }

    public static void RemoveSnakeTail(Snake snake, char[,] field, Point tail)
    {
        field[tail.pY, tail.pX] = '-';
        snake.BodyPoints.Remove(tail);
    }
}

