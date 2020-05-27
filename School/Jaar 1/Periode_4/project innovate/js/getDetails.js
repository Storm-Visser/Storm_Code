//een simpele json file die ik verwacht te krijgen
let json = {
    gerjan={
        firstName: "Gerjan",
        lastName: "Van Oenen",
        status: 0,
        Path : "http//:foto.com"
    }
}
for (let index = 0; index < array.length; index++) {
    const element = array[index];
    
}
//een functie om aan de hand van de status de kleur te returnen
function getColour(){
    let colour;
    switch(json.status) {
        case 0:
            colour = "green"    //aanwezig en beschikbaar
            break;
        case 1:
            colour = "red"      //afwezig
            break;
        case 2:
            colour = "#ffe066"  //geel, aanwezig maar niet beschikbaar
            break;
        default:
            colour = "grey"     //default als het onbekend is
      }
      return colour;
}
window.onload = getColour;

//functie om de naam en foto path op te halen
function getDetails(){
    let colour = getColour()
    // voeg de voor en achternaam samen
    let details = json.firstName + " "+ json.lastName + " " + json.Path;
    //haal het element op van H1
    let element = document.getElementById('header');
    //set de style van die header aan de hand van getColour()
    element.style.color = colour;
    //haal het element "span" op
    let element2 = document.getElementById('head');
    //zet de inoud van dat element aan de hand van de details
    element2.innerHTML = details;
    return details;
}
window.onload = getDetails;
