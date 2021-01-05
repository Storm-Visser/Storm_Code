package com.nhlstenden;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;

import java.time.LocalDate;

import static org.junit.jupiter.api.Assertions.*;

class RepresentativeTest
{
    private Representative rpMartijn;

    @BeforeEach
    void arrange()
    {
        rpMartijn = new Representative("Martijn Pomp", "1979-06-21");
    }

    @Test
    void getName()
    {
        assertEquals("Martijn Pomp", rpMartijn.getName());
    }

    @Test
    void getDOB()
    {
        assertEquals(LocalDate.of(1979,6,21), rpMartijn.getDateOfBirth());
    }

    @Test
    @Disabled
    void getAge()
    {

    }
}