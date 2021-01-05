package com.nhlstenden.vote;

public class InvalidVote extends Vote
{
    @Override
    public boolean isValid() {
        return false;
    }
}
