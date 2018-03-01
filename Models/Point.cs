using System;

public class Point
{
    public short pY { get; private set; }
    public short pX { get; private set; }
    public char Symbol => '8';

    public Point(short pY,short pX)
    {
        this.pY = pY;
        this.pX = pX;
    }
}

