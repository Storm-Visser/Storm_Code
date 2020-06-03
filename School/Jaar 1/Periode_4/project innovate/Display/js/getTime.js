// /**
//  * @deprecated
//  * hoeft geen const te zijn.
//  * const TODAY = new Date();
//  */

// /**
//  * Functie om de tijd van het device op te halen.
//  * Note: Dit gebreurd bij elke refresh.
//  * @return {time} De huidige tijd van het device.
//  */
// function getTime()
// {
//     let hr = Date.getHours();
//     let min = Date.getMinutes();
//     if(hr < 10)
//     {
//         hr = "0" + hr;
//     }
//     if(min < 10)
//     {
//         min = "0" + min;
//     }
//     let sec = Date.getSeconds();
//     let time = hr + ":" + min + ":" + sec;
//     // let time = hr + ":" + min;
//     document.getElementById('clock').innerHTML = time;
//     /**
//      * @deprecated 
//      * let element1 = document.getElementById('date');
//      * element1.innerHTML = date;
//      * return date;
//      */
//     }
// setInterval(getTime, 1000);

/**
 * @source https://www.tutorialrepublic.com/javascript-tutorial/javascript-timers.php
 */
function getTime() 
{
    var time = new Date();
    document.getElementById("clock").innerHTML = time.toLocaleTimeString();
}
// timer die elke seconden de functie aanroept.
setInterval(getTime, 1000);

export { getTime }; 