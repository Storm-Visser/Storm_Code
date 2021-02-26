let random = Math.round(Math.random());
let persoon = "persoon";
if (random == 0) 
{
    persoon = "Ramon";
} else {
    persoon = "Kayliegh";
}

document.getElementById("persoon").innerHTML = persoon;