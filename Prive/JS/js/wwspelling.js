let woord;
if(woord.isPersoonsvorm())
{
    if(woord.isVerledenTijd())
    {
        if (woord.stam() in "TXKFSCHP")//in taxikofschip
        {
            console.log("stam + te(n)");
        }
        else if(!(woord.stam() in "TXKFSCHP"))//niet in taxikofschip
        {
            console.log("stam + de(n)");
        }
    }
    else if(woord.isTegenwoordigeTijd())
    {
        console.log("stam + t");
    }
}
else if(woord.isNotPersoonsvorm())
{
    if(woord.isBijvoegelijkNaamwoord())
    {
        console.log("zo kort mogelijk");
    }
    else if(woord.isVoltooidDeelwoord())
    {
        if (woord.stam() in "TXKFSCHP")//in taxikofschip
        {
            console.log("stam + t");
        }
        else if(!(woord.stam() in "TXKFSCHP"))//niet in taxikofschip
        {
            console.log("stam + d");
        }
    }
}
//functies
function isPersoonsvorm()
{
    return true;

}
function isVoltooideTijd()
{
    return true;

}
function isTegenwoordigeTijd()
{
    return false;

}
function isNotPersoonsvorm()
{
    return false;
}
function isBijvoegelijkNaamwoord()
{
    return false;
}
function isVoltooidDeelwoord()
{
    return false;
}
function stam()
{
    return woord - "en";
}
