/**
 * Functie om van CSS style file te wisselen.
 * Wordt gebruikt voor de darkmode van de pagina.
 * @param {*} sheet De file waar je de huidige stijle mee wil verwisselen.
 * @see {toggle()} De functie die wisselen tussen de dark style en light style mogelijk maakt.
 */
function swapStyleSheet(sheet)
{
    document.getElementById('pagestyle').setAttribute('href', sheet);
}

/**
 * Constanten om de afbeeldingen aan te roepen.
 */
const docent = "../img/icons-scherm/docent.png";
const docentWit = "../img/icons-scherm/docent_wit.png";
const aanwezigheid = "../img/icons-scherm/aanwezigheid.png";
const aanwezigheidWit = "../img/icons-scherm/aanwezigheid_wit.png";
const addMessage = "../img/icons-scherm/addmessage.png";
const addMessageWit = "../img/icons-scherm/addmessage_wit.png"

/**
 * Functie om de inlog afbeelding te wijzigen
 * @note Deze apparte functie is nodig voor de niet ingelogde pagina buienrader en newsfeed.
 * @param {*} button De knop waar op gedrukt wordt om te wisselen van afbeelding.
 */
function toggleBasic(button) 
{
    switch (button.value) 
    {
        case "ONN":
            swapStyleSheet('../Css/Darkstyle.css')
            swapColour("#585656")
            document.getElementById("docentLogoColorChange").src = docentWit;
            button.value = "OFF";

            break;
        case "OFF":
            swapStyleSheet('../Css/style.css')
            swapColour("white")
            document.getElementById("docentLogoColorChange").src = docent;
            button.value = "ONN";
            break;
    }
}

/**
 * Functie van de Dark mode knop.
 * Zorgt er voor dat er gewisseld kan worden tussen:
 * - Darkstyle.css
 * - style.css
 * Zorgt ook dat de afbeeldingen gewisseld worden tussen donker en wit.
 * Waardoor de styling van de pagina verandert wordt.
 * @param {*} button De knop waar op gedrukt wordt om te wisselen van style.
 */
function toggle(button) 
{
        switch (button.value) {
            case "ONN":
                swapStyleSheet('../Css/Darkstyle.css')
                document.getElementById("docentLogoColorChange").src = docentWit;
                document.getElementById("aanwezigheidLogoColorChange").src = aanwezigheidWit;
                document.getElementById("addMessageLogoColorChange").src = addMessageWit;
                button.value = "OFF";

                break;
            case "OFF":
                swapStyleSheet('../Css/style.css')
                document.getElementById("docentLogoColorChange").src = docent;
                document.getElementById("aanwezigheidLogoColorChange").src = aanwezigheid;
                document.getElementById("addMessageLogoColorChange").src = addMessage;
                button.value = "ONN";
                break;
    }
}
import { getDetails, swapColour } from './getDetails.js';
// function iconsDark()
// {
//     document.getElementById("imgClickAndChange").src = "../img/icons-scherm/docent_wit.png";
// }

// function iconsLight()
// {
//     document.getElementById("imgClickAndChange").src = "../img/icons-scherm/docent.png";
// }

/**
 * @Bug Neemt darkmode niet mee naar volgende pagina, 
 * misschien kun je de set pagestyle die in de main style.css link staat overschrijven door de gewenste.
 */

 // potensele bugfix
 // bron: https://stackoverflow.com/questions/6764961/change-an-image-with-onclick
 // mogelijke andere oplossing bron https://www.w3schools.com/howto/howto_js_toggle_dark_mode.asp
// optie om waardes te versturen in  javascript bron: https://www.youtube.com/watch?v=GNZg1KRsWuU
// $(".plus").click(function(){
//     $(this).toggleClass("minus")  ; 
//    })

//    .plus{
//     background-image: url("https://cdn0.iconfinder.com/data/icons/ie_Bright/128/plus_add_blue.png");
//     width:130px;
//     height:130px;
//     background-repeat:no-repeat;
// }

// .plus.minus{
//     background-image: url("https://cdn0.iconfinder.com/data/icons/ie_Bright/128/plus_add_minus.png");
//     width:130px;
//     height:130px;
//     background-repeat:no-repeat;
// }

// <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
// <a href="#"><div class="plus">CHANGE</div></a>