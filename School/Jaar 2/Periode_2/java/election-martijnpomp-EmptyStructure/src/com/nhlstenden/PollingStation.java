package com.nhlstenden;

import com.nhlstenden.vote.BlankVote;
import com.nhlstenden.vote.InvalidVote;
import com.nhlstenden.vote.Vote;

import java.util.*;

public class PollingStation
{
    private String name;
    private final HashSet<VotePaper> allVotePapers;

    public PollingStation(String name)
    {

    }

    public void setName(String name)
    {

    }

    public String getName()
    {

    }

    public void addVotePaper(VotePaper votePaper)
    {

    }

    public HashSet<VotePaper> getAllVotePapers()
    {

    }

    /***
     * This function returns the amount of blank votes of the polling station
     * @return the amount of blank votes of the polling station
     */
    public int getAmountOfBlankVotes()
    {

    }

    /***
     * This function returns the amount of invalid votes of this polling station
     * @return the amount of invalid votes of this polling station
     */
    public int getAmountOfInvalidVotes()
    {

    }

    /***
     * This function returns all the votes of this pollingstation
     * @return all of the votes of all this pollingstation belonging to the municipality
     */
    public ArrayList<Vote> getAllVotes()
    {

    }

    /***
     * This function returns a hashmap containing the representatives with the amount of votes
     * @return a hashmap containing the representatives with the amount of votes
     */
    public HashMap<Representative, Integer> getRepresentativeVsVotes()
    {

    }
}
