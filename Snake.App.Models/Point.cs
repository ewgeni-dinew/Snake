using System;

public class Point
{
    public short PY { get; private set; }
    public short PX { get; private set; }
    public char Symbol => '8';

    public Point(short pY,short pX)
    {
        this.PY = pY;
        this.PX = pX;
    }
}

