using System;
using System.Collections.Generic;
using System.Text;

public class InvalidInputMove:ArgumentException
{
    private const string message = "Invalid move command! Press any key to continue.";

    public InvalidInputMove():base(message)
    {

    }
}

