using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Mover
{
    public static void TryMoveSnake(char[,] field, Snake snake, Point headPoint,
        Point tail, Point prize, char directionChar, Point newPoint)
    {
        if (snake.BodyPoints.Any(p => p.PX == newPoint.PX && p.PY == newPoint.PY))
        {
            throw new SuddenDeathException();
        }
        field[headPoint.PY, headPoint.PX] = '8';
        snake.AddPoint(newPoint,(short)field.GetLength(0),(short)field.GetLength(1));
        headPoint = snake.BodyPoints.Last();
        field[headPoint.PY, headPoint.PX] = directionChar;
    }

    public static void RemoveSnakeTail(Snake snake, char[,] field, Point tail)
    {
        field[tail.PY, tail.PX] = '-';
        snake.BodyPoints.Remove(tail);
    }
}

