using System;
using System.Collections.Generic;
using System.Text;

public class SuddenDeathException:ArgumentException
{
    private const string message = "Snake is death!!!";

    public SuddenDeathException():base(message)
    {

    }
}

