package com.nhlstenden;

import com.nhlstenden.vote.Vote;

import java.util.ArrayList;
import java.util.HashMap;

public class Municipality
{
    private String name;
    private final ArrayList<PollingStation> pollingStations = new ArrayList<>();

    public Municipality(String name)
    {

    }

    public String getName()
    {

    }

    public void setName(String name)
    {
    }

    public ArrayList<PollingStation> getPollingStations()
    {
    }

    public void addPollingStation(PollingStation pollingStation)
    {
    }

    /***
     * This function returns all the votes of the pollingstations
     * @return all of the votes of all the pollingstations belonging to the municipality
     */
    public ArrayList<Vote> getAllVotes()
    {

    }

    /***
     * This function returns the amount of invalid votes of the pollingstations
     * @return the amount of invalid votes of all the polling stations
     */
    public int getAmountOfInvalidVotes()
    {

    }

    /***
     * This function returns the amount of blank votes of the pollingstations
     * @return the amount of blank votes of all the polling stations
     */
    public int getAmountOfBlankVotes()
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
