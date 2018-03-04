using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSnakeBodyCount:ArgumentException
{
    private const string message = "Congratulation! Reached snake body limit.";

    public InvalidSnakeBodyCount():base(message)
    {

    }
}

