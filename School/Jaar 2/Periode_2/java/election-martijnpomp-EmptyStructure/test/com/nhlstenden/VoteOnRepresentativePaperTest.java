package com.nhlstenden;

import com.nhlstenden.vote.BlankVote;
import com.nhlstenden.vote.InvalidVote;
import com.nhlstenden.vote.VoteOnRepresentative;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class VoteOnRepresentativePaperTest
{
    private VotePaper vp;
    private Representative repMP;
    private Representative repJD;
    private Representative repND;


    @BeforeEach
    void setUp()
    {
        vp = new VotePaper();
        repMP = new Representative("Martijn Pomp", "1979-06-21");
        repJD = new Representative("Jan Doornbos", "1993-12-26");
        repND = new Representative("Niels Doorn", "1976-02-14");
    }
    @Test
    void addRepresentative()
    {

    }

    @Test
    void addVote()
    {

    }

    @Test
    void getVote()
    {

    }
}