function createTable()
{
    //maak de table======================================================
    //maak een div aan waar de list elementen in kunnen
    let table = document.createElement("table");
    //maak een table row aan
    let tr1 = table.insertRow();
    //maak een cell in die tablerow komt
    let td1 = tr1.insertCell();
    //maak de tweede row aan
    let tr2 = table.insertRow();
    //maak 2 cells aan
    let td2 = tr2.insertCell();
    let td3 = tr2.insertCell();
    //plaats de tabel
    document.getElementById("addTable").appendChild(table);
    table.className = "tableFromJS"
    //maak de image en zet hem in de tabel===============================
    //maak een image aan
    let img = document.createElement("img")
    //set de source en de class van de img
    img.src = "img/capture.jpg";
    img.className = "imgInTableFromJS"
    //plak de img aan de td    
    td1.appendChild(img);
    //laat de img 2 colommen breed zijn
    td1.colSpan = 2;
    //maak de knoppen====================================================
    //maak de buttons aan
    let del = document.createElement("button");
    let show = document.createElement("button");
    // maak de onclicks
    del.setAttribute("onclick", "javascript: console.log('you clicked verwijderen');");
    show.setAttribute("onclick", "javascript: console.log('you clicked laat zien');");
    //plaats de tekst in de buttons
    del.textContent = "verwijder";
    show.textContent = "laat zien";
    //plaats de buttons in de tabel
    td2.appendChild(del);
    td3.appendChild(show);
    
}
createTable();