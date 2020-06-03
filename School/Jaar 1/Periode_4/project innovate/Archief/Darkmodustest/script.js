//Gets the ID of the button by the id swtich given to the button
//Compares the value inside the button to "Lightmode"
//If thats true it changes the value inside the button to "Darkmode"
//And calls the darkmode function
function switchModus() {

    if (document.getElementById("switch").innerHTML == ("Lightmode"))
    {
        document.getElementById("switch").innerHTML = ("Darkmode");
        darkmode();
    }
    else
    {
        document.getElementById("switch").innerHTML = ("Lightmode");
        lightmode();
    }
}

//Creates a variable that houses all the elements on the page with the "lightmode" class
//This makes the variable element a array like object, 
//It is possible to use.length on this object to see the amount of elements inside
//While the amount of "lightmode" classes inside the object arent 0 it is going to update the classes to darkmode,
//getElementsByClassName is a "living" array like object that means everytime you update it it chances it values,
//So if you remove a object the counter goes down
function darkmode() {
    let element = document.getElementsByClassName('lightmode');

    while (element.length != 0)
    {
        element[0].className = 'darkmode';
    }
}

//Creates a variable that houses all the elements on the page with the "darkmode" class
//This makes the variable element a array like object, 
//It is possible to use.length on this object to see the amount of elements inside
//While the amount of "darkmode" classes inside the object arent 0 it is going to update the classes to darkmode,
//getElementsByClassName is a "living" array like object that means everytime you update it it chances it values,
//So if you remove a object the counter goes down
function lightmode() {
    let element = document.getElementsByClassName('darkmode');

    while (element.length != 0)
    {
        element[0].className = 'lightmode';
    }
}