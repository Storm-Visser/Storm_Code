//haal het aantal miliseconden na 1 jan 1970 op
const TODAY = new Date();

/**
 * Functie om huidige week op te hallen.
 * @return {pastWeeks} De het nummer van de huidige week.
 */
function getWeek()
{
    //haal de eerste dag van het jaar op
    let firstDayOfYear = new Date(TODAY.getFullYear(), 0, 1);
    /**
     *haal de dagen sinds de eerste dag op, 86400000 is een dag in ms(miliseconden).
     *je pakt het aantal ms sinds 1 jan 1970, en haalt daar het aantal ms sinds 1 jan 1970 van de eerste dag van het jaar vanaf
     *dan hou je het aantal ms in dit jaar over, als je dat deelt door 86400000 krijg je het aantal dagen die zijn geweest
     */
    let pastDaysOfYear = (TODAY - firstDayOfYear) / 86400000;
    //als je het aantal dagen van dit jaar hebt, moet je een toevoegen om de eerste dag (1 januari) mee te rekenen
    //math.ceil zorgt dat het naar boven wordt afgerond
    let pastWeeks = Math.ceil((pastDaysOfYear + 1) / 7);
    return pastWeeks;
}

/**
 * Functie om de huidige datum in het gewenste format op te halen.
 * @example Friday 29 May WeekNr. 22.
 */
function getCurrentDate()
{
    //let year = TODAY.getFullYear();
    let week = getWeek();
    let months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    let month = months[TODAY.getMonth()];
    let day = TODAY.getDate();
    let weekDays = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    let weekDay = weekDays[TODAY.getDay()]
    if(month < 10)
    {
        month = "0" + month;
    }
    if(day < 10)
    {
        day = "0" + day;
    }
    let date = weekDay + " " + day +  " " + month + " WeekNr. " + week;
    //let date = year + "/" + month + "/" + day;

        document.getElementById('date').innerHTML = date;
    /**
     * @deprecated 
     * let element1 = document.getElementById('date');
     * element1.innerHTML = date;
     * return date;
     */
}
// dit is een auto refresher van een uur.
// Tussen 23:59 en 00:01 zal de de date updaten.
setInterval(getCurrentDate, 3600);

// function getCurrentDate() 
// {
//     var time = new Date();
//     document.getElementById("date").innerHTML = time.toDateString();
// }
//setInterval(getCurrentDate, 3600000);

export { getCurrentDate }; 