//functie om het huidige weeknummer op te halen
function getWeek()
{
    const today = new Date();
    //haal de eerste dag van het jaar op
    let firstDay = new Date(today.getFullYear(), 0, 1);
    /**
     *haal de dagen sinds de eerste dag op, 86400000 is een dag in ms(miliseconden).
     *je pakt het aantal ms sinds 1 jan 1970, en haalt daar het aantal ms sinds 1 jan 1970 van de eerste dag van het jaar vanaf
     *dan hou je het aantal ms in dit jaar over, als je dat deelt door 86400000 krijg je het aantal dagen die zijn geweest
     */
    let pastDays = (today - firstDay) / 86400000;
    //als je het aantal dagen van dit jaar hebt, moet je een toevoegen om de eerste dag (1 januari) mee te rekenen
    let pastWeeks = Math.ceil((pastDays + 1) / 7);
    return pastWeeks;
}