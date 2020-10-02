let words = ["testen", "fietsen", "tentoonstelling", "iets", "ik", "jazz", "score", "etui", "cactus", "liquidatie"];
let word = "";
let letters = [];
let amountCorrect = 0;
let amountWrong = 0;

//functie om het woord te selecteren en de letters op te slaan
function getLetters()
{
    word = words[Math.round(Math.random() * words.length - 1)];
    letters = word.split("");

    for (let index = 0; index < letters.length; index++) 
    {
        let toAdd = document.createElement("div");
        toAdd.className = "letter";
        toAdd.id = index + 1;
        let destination = document.getElementById("letters");
        destination.appendChild(toAdd)
    }
}
//funtie om de input te checken en te verwerken
function checkLetter()
{
    let input = document.getElementById("inputForJs").value;
    if(input.toLowerCase() === word)
    {
        correctWord()
    }
    else if(letters.includes(input.toLowerCase()))
    {
        correctLetter(input.toLowerCase());
    }
    else
    {
        wrongLetter()
    }
}
//functie als de input fout is
function wrongLetter()
{
    let toHide = getNextHangManPart(amountWrong);
    if(toHide === "error")
    {
        alert("error, wrong hangman part")
    }
    else
    {
        if(amountWrong == 10)
        {
            document.getElementById(toHide).style.backgroundColor = "transparent";
            lost()
        }
        else
        {
            document.getElementById(toHide).style.backgroundColor = "transparent";
            amountWrong++;
        }
    }
}
//functie als je hebt verloren
function lost()
{
    alert("You lose");
    setTimeout(location.reload(), 5000)
}
//functie als de letter goed is
function correctLetter(letter)
{
    let positions = [];
    for (let index = 0; index < letters.length; index++) 
    {
        if(letters[index] === letter)
        {
            positions.push(index + 1);
        }
    }
    showLetters(positions)
}
//functie om de geraden letters te laten zien
function showLetters(position)
{
    //positions ziet er zo uit:
    // 0 : 4
    // 1 : 7
    //daar staan de posities van de opgegeven letters
    //dus op positie 4 en op positie 7 staan bijvoorbeeld een t
    for (let index = 0; index < position.length; index++) 
    {
        document.getElementById(position[index]).innerHTML = letters[position[index] - 1];
        //haalt het alle elementen in positions op en zoekt de positie van de letters 
        //aan de hand van de divs met de streepjes eronder plaats de goede letters
    }
}

//funtie als het woord goed is en je hebt gewonnen
function correctWord()
{
    alert("Congratulations, You won");
    setTimeout(location.reload(), 5000)
}
//functie om het volgende HngMan onderdeel te selecteren
function getNextHangManPart(input)
{
    let i = input;
    let output = "";
    switch(i) {
        case 0:
            output = "poleLeg1";
            break;

        case 1:
            output = "poleLeg2";
            break;

        case 2:
            output = "pole";
            break;

        case 3:
            output = "topPole";
            break;

        case 4:
            output = "rope";
            break;

        case 5:
            output = "head";
            break;

        case 6:
            output = "torso"
            break;

        case 7:
            output = "arm1";
            break;

        case 8:
            output = "arm2";
            break;

        case 9:
            output = "leg1";
            break;

        case 10:
            output = "leg2";
            break;

        default:
            output = "error";
      }
      return output;
}
Document.onload = getLetters();