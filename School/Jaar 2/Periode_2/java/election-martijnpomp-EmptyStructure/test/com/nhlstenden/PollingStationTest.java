package com.nhlstenden;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

class PollingStationTest
{
    private PollingStation pollingStation;
    private VotePaper vpJD;
    private VotePaper vpMP;
    private VotePaper vpND;
    private Representative repMP;
    private Representative repJD;
    private Representative repND;

    @BeforeEach
    void setUp()
    {
        pollingStation = new PollingStation("NHLStenden");
        vpMP = new VotePaper();
        vpJD = new VotePaper();
        vpND = new VotePaper();
        repMP = new Representative("Martijn Pomp", "1979-06-21");
        repJD = new Representative("Jan Doornbos", "1995-12-26");
        repND = new Representative("Niels Doorn", "1976-02-14");
    }

    @Test
    void getName()
    {

    }

    @Test
    void addVotePaper()
    {

    }

    @Test
    void getResultsWithAllValidNoBlanks()
    {

    }

    @Test
    void getResultsWithAllValidAndBlanks()
    {

    }

    @Test
    void getResultsWithAllValidAndInvalid()
    {

    }

    @Test
    void getAmountOfBlankVotes()
    {

    }

    @Test
    void getAmountOfInvalidVotes()
    {

    }

    @Test
    void getRepresentativesWithAmountOfVotes()
    {

    }
}