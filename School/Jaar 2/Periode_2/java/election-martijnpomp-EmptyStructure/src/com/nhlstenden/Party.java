package com.nhlstenden;

import com.nhlstenden.exception.PositionAlreadyTakenException;
import com.nhlstenden.orientation.HorizontalOrientation;
import com.nhlstenden.orientation.Orientation;
import com.nhlstenden.orientation.VerticalOrientation;

import java.util.HashMap;

public class Party
{
    private final HashMap<Integer, Representative> memberList;
    private String name;
    private Orientation orientation;

    public Party(String name, HorizontalOrientation horOrientation, VerticalOrientation verOrientation)
    {
        this.name = name;
        this.orientation = new Orientation(horOrientation, verOrientation);
        this.memberList = new HashMap<>();
    }

    public String getName()
    {
        return this.name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public Orientation getOrientation()
    {
        return this.orientation;
    }

    public void setOrientation(Orientation orientation)
    {
        this.orientation = orientation;
    }

    public HashMap<Integer, Representative> getMemberList()
    {
        return this.memberList;
    }

    /***
     * This function adds a representative to the list on a provided position
     * if 0 is provided, the representative will be put on the first available free spot.
     *
     * @param representative The representative to add
     * @param position The position on the list
     * @throws PositionAlreadyTakenException When the position that is provided is already taken.
     */
    public void addMember(Representative representative, int position) throws PositionAlreadyTakenException
    {
        if (position == 0)
        {
            putRepresentativeAtFirstAvailableSpot(representative);
        }
        else if (memberList.containsKey(position))
        {
            // What do we do here.... we throw an exception.
            throw new PositionAlreadyTakenException();
        }
        else
        {
            this.memberList.put(position, representative);
        }
    }

    /***
     * This function puts the representative on the first available spot
     * @param representative The representative that needs to be added to the hashmap
     */
    private void putRepresentativeAtFirstAvailableSpot(Representative representative)
    {
        // Iterate through map and put it on first available stop
        for (int i = 1; i <= memberList.size() + 1; i++)
        {
            if (!memberList.containsKey(i))
            {
                memberList.put(i, representative);
                return;
            }
        }
    }

    /***
     * This function returns the leader of the party (lijsttrekker)
     * @return The leader of the party
     */
    public  Representative getPartyLeader()
    {

    }
}
