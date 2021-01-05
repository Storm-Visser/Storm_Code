package com.nhlstenden;

import com.nhlstenden.vote.Vote;

import java.util.ArrayList;
import java.util.HashMap;

public class Election
{
    public static final int NUMBER_OF_SEATS = 150;
    private final ArrayList<Municipality> municipalities;
    private final ArrayList<Party> parties;

    public Election()
    {
        this.municipalities = new ArrayList<Municipality>();
        this.parties = new ArrayList<Party>();
    }

    public ArrayList<Party> getParties()
    {
        return this.parties;
    }

    public void addParty(Party party)
    {

    }

    public ArrayList<Municipality> getMunicipalities()
    {
        return municipalities;
    }

    public void addMunicipality(Municipality municipality)
    {

    }

    /***
     * This function returns the amount of blank votes of the election
     * @return the amount of blank votes
     */
    public int getAmountOfBlankVotes()
    {
        return 1;
    }

    /***
     * This function returns the amount of invalid votes of the election
     * @return the amount of invalid
     */
    public int getAmountOfInvalidVotes()
    {
        return 1;
    }

    /***
     * This function returns all the votes of the election
     * @return all the votes of the election
     */
    public ArrayList<Vote> getAllVotes()
    {
        return null;
    }

    /***
     * This function returns a hashmap containing the representatives with the amount of votes
     * @return a hashmap containing the representatives with the amount of votes
     */
    public HashMap<Representative, Integer> getRepresentativeVsVotes()
    {
        return null;
    }

    /***
     * This function calculates the kiesdeler (All valid votes / number of seats)
     * @return the kiesdeler
     */
    public double getKiesDeler()
    {
        return 0.0;
    }

    /***
     * This function returns all the valid votes.
     * @return an arraylist with all the valid votes (blanks and on representatives)
     */
    private ArrayList<Vote> getValidVotes()
    {
        return null;
    }

    /***
     * This function returns a Hashmap containing the Party and the amount of votes for that party
     * @return a Hashmap containing the Party and the amount of votes for that party
     */
    private HashMap<Party, Integer> getVotesPerParty()
    {
        return null;
    }

    /***
     * Thif function determines the amount of seats per party
     * @return a hashmap containing the party and the amount of seats for that party.
     */
    public HashMap<Party, Integer> getSeatsPerParty()
    {
        return null;
    }
}
