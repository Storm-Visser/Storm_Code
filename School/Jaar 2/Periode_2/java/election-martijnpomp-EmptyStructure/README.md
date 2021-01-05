# Elections

The Dutch government asked us to implement a piece of software that takes care of registering and counting the votes that are done for the House of Representatives.



The process of voting can be described in the following chapter.

## Process

The ballot paper contains a list with all political parties and the members of those parties. All of the parties have a name and have an horizontal orientation:

* Left;
* Right;
* Centre.

They also have a vertical orientation:

* Progressive
* Conservative

![](https://imgd.rgcdn.nl/ee1624b9e7c0495f845022b2d9c4e918/opener/Er-staan-45-Drenten-op-het-stembiljet-Rechten-ANP-Remko-de-Waal.jpg?v=hpd_IFatdudH1uJ4HL_fxg2)

The first person on the list of a certain party is called the party leader. The other members are located on a certain position of the list. 

![](https://images3.persgroep.net/rcs/fr7B94sRXuxWPsr8wrJiolnlXzA/diocontent/147751657/_fitwidth/763?appId=93a17a8fd81db0de025c8abd1cca1279&quality=0.8)

In this case "Gerard Roos" is the party leader.  Every party can consist of a different amount of members. 

Every person of 18 years and older have the right to vote. They go to the Polling Station and vote on a certain person of a certain party. It is possible to put in a blank form, this will be counted as a valid vote (but blank). It is also possible to vote on multiple persons, but then the vote will be invalid. The form with the vote will be put in a large container and when the polling station is closed the votes will be counted. (In the future other ways of voting should be taken into account like an app or voting computer)

These results will all be send to the municipality who will add up the results of every Polling Station in that municipality. After this the results of all municipalities will be gathered by the "Kiesraad"  

If the results of all the municipalities are in. The they start dividing the 150 seats.

## Calculation of seats

### "Kiesdeler"

First a "kiesdeler" needs to be determined. The following formula is used for that
$$
kiesdeler = \frac{amount Of ValidVotes}{150}
$$

### Seats

After that there is calculated how many times the parties have reached the kiesdeler.


$$
seats = \frac{amountOfVotesPerParty}{kiesdeler}
$$
The remaining value after calculating the seats is used for the residual seats. 

#### Residual Seats

Below is a step-by-step description of how the residual seats are distributed according to the 'system of the largest averages'.

1.  it is calculated for all parties how many votes would have been cast per seat on a party, if that party were to receive one additional seat. The votes cast on the party are divided by the number of 'full' seats + 1 obtained
2. the results of this calculation are averages; they are ordered by size
3. the first remaining seat goes to the party with the greatest average. For this party, the current average is recalculated, based on the number of full seats, the allocated residual seat and one extra seat
4. if there is still a residual seat to be allocated, it will be allocated to the party with the largest average now
5. if necessary, the central electoral committee repeats this procedure until all remaining seats have been allocated



When everything is calculated the results should be presented on screen. Ordered by the amount of seats, where the most seats are on top.