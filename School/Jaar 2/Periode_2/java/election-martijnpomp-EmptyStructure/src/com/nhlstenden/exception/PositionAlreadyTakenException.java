package com.nhlstenden.exception;

public class PositionAlreadyTakenException extends Exception
{
    public PositionAlreadyTakenException()
    {
        super("Position is already occupied!");
    }
}
