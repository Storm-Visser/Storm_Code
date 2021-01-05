package com.nhlstenden;

import com.nhlstenden.vote.BlankVote;
import com.nhlstenden.vote.InvalidVote;
import com.nhlstenden.vote.Vote;
import com.nhlstenden.vote.VoteOnRepresentative;

import java.util.HashMap;

public class VotePaper
{
    private final HashMap<Representative, Boolean> representatives;

    public VotePaper()
    {
        representatives = new HashMap<>();
    }

    public void addRepresentative(Representative representative)
    {
        representatives.put(representative, Boolean.FALSE);
    }

    public HashMap<Representative, Boolean> getRepresentatives()
    {
        return this.representatives;
    }

    public void addVote(Representative representative)
    {
        representatives.put(representative, Boolean.TRUE);
    }

    /***
     * This function returns a vote type based on the hashmap
     * It returns VoteOnRepresentative if there is one boolean in the map is true
     * It returns BlankVote if there is no boolean in the map true
     * It returns InvalidVote if there are more than one booleans in the map true
     * @return type of vote
     */
    public Vote getVote() {
        int amountTrue = 0;
        Representative representative = null;
        for (HashMap.Entry<Representative, Boolean> entry : this.representatives.entrySet()) {
            if (entry.getValue()) {
                amountTrue++;
                representative = entry.getKey();
            }
        }

        switch (amountTrue) {
            case 0:
                return new BlankVote();
            case 1:
                return new VoteOnRepresentative(representative);
            case 2:
                return new InvalidVote();
        }
        return null;
    }
}
