﻿using System;
using System.Collections.Generic;
using System.Text;

public class Snake
{
    public List<Point> BodyPoints { get; private set; }
    public Point Head { get; private set; }
    public char HeadSymbol => '>';

    public Snake()
    {
        BodyPoints = new List<Point>
        {
            new Point(3,3),
            new Point(3,4),
            new Point(3,5),
            new Point(3,6),
            new Point(3,7),
        };
    }

    public void AddPoint(Point point,short rows, short columns)
    {
        if (this.BodyPoints.Count>=rows*columns-3)
        {
            throw new InvalidSnakeBodyCount();
        }
        this.BodyPoints.Add(point);
    }
}

