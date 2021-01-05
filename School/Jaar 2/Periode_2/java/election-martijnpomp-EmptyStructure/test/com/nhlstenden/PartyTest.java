package com.nhlstenden;

import com.nhlstenden.orientation.HorizontalOrientation;
import com.nhlstenden.orientation.Orientation;
import com.nhlstenden.orientation.VerticalOrientation;
import com.nhlstenden.Party;
import com.nhlstenden.Representative;
import com.nhlstenden.exception.PositionAlreadyTakenException;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class PartyTest
{
    private Party partyProgLeft;
    private Party partyConsRight;
    private Representative repJD;
    private Representative repMP;
    private Representative repND;

    @BeforeEach
    void setup()
    {
        partyProgLeft = new Party("partyLeft",
                HorizontalOrientation.LEFT, VerticalOrientation.PROGRESSIVE);
        partyConsRight = new Party("partyRight",
                HorizontalOrientation.RIGHT, VerticalOrientation.CONSERVATIVE);
        repJD = new Representative("Jan Doornbos", "1993-12-26" );
        repMP = new Representative("Martijn Pomp", "1979-06-21");
        repND = new Representative("Niels Doorn", "1976-02-14");
    }

    @Test
    void getName()
    {
        assertEquals("partyLeft", partyProgLeft.getName());
        assertEquals("partyRight", partyConsRight.getName());
    }

    @Test
    void setName()
    {
        partyConsRight.setName("partyRightChanged");
        assertEquals("partyRightChanged", partyConsRight.getName());
    }

    @Test
    void getOrientation()
    {
        Orientation orientation =
                new Orientation(HorizontalOrientation.LEFT, VerticalOrientation.PROGRESSIVE);
        assertEquals(orientation, partyProgLeft.getOrientation());

        orientation.setHorizontalOrientation(HorizontalOrientation.RIGHT);
        orientation.setVerticalOrientation(VerticalOrientation.CONSERVATIVE);
        assertEquals(orientation, partyConsRight.getOrientation());
    }

    @Test
    void setOrientation()
    {
        Orientation orientation = new Orientation(HorizontalOrientation.LEFT, VerticalOrientation.PROGRESSIVE);
        partyConsRight.setOrientation(orientation);
        assertEquals(orientation, partyConsRight.getOrientation());
    }

    @Test
    void addMemberAtFirstAvailableSpotWhenListIsEmpty() throws PositionAlreadyTakenException
    {
        partyConsRight.addMember(repJD, 0);

        // Kijken of 1e positie ook JD bevat
        assertEquals(repJD, partyConsRight.getMemberList().get(1));
        assertEquals(1, partyConsRight.getMemberList().size());
    }

    @Test
    void addMemberAtFirstAvailableSpotWhenListContainsGaps() throws PositionAlreadyTakenException
    {
        // Arrange Party with gap in list
        partyProgLeft.addMember(repMP, 1);
        partyProgLeft.addMember(repJD,3);

        // Add member on first free location
        partyProgLeft.addMember(repND, 0);

        assertEquals(partyProgLeft.getMemberList().get(2), repND);
        assertEquals(3, partyProgLeft.getMemberList().size());
    }

    @Test
    void addMemberAtFirstAvailableSpotAtEnd() throws PositionAlreadyTakenException
    {
        // Arrange Party with members in list
        partyProgLeft.addMember(repMP, 1);
        partyProgLeft.addMember(repJD,2);

        // Add member on first free location
        partyProgLeft.addMember(repND, 0);

        assertEquals(partyProgLeft.getMemberList().get(3), repND);
        assertEquals(3, partyProgLeft.getMemberList().size());

    }

    @Test
    void addMemberAtPositionThatIsAlreadyTaken() throws PositionAlreadyTakenException
    {
        partyConsRight.addMember(repMP, 3);
        assertThrows(PositionAlreadyTakenException.class,
                () -> partyConsRight.addMember(repJD, 3) );
        assertDoesNotThrow(() -> partyConsRight.addMember(repJD,2));
    }

    @Test
    void addMemberAtPredefinedFreeSpot() throws PositionAlreadyTakenException
    {
        // Arrange Party with gap in list
        partyProgLeft.addMember(repMP, 1);
        partyProgLeft.addMember(repJD,2);

        // Add member on first free location
        partyProgLeft.addMember(repND, 5);

        assertEquals(partyProgLeft.getMemberList().get(5), repND);
        assertEquals(3, partyProgLeft.getMemberList().size());
    }
}