package com.nhlstenden.vote;

import com.nhlstenden.Representative;

public class VoteOnRepresentative extends Vote
{
    private Representative representativeVotedOn;

    @Override
    public boolean isValid() {
        return true;
    }

    public VoteOnRepresentative(Representative r)
    {
    this.representativeVotedOn = r;
    }

    public Representative getRepresentativeVotedOn()
    {
        return this.representativeVotedOn;
    }

    public void setRepresentativeVotedOn(Representative representativeVotedOn)
    {
        this.representativeVotedOn = representativeVotedOn;
    }
}
