/**
 * Functie om de tijd van het device op te halen.
 * Note: Dit gebreurd bij elke refresh.
 * @return {time} De huidige tijd van het device.
 */
function getTime()
{
    let today = new Date();
    let hr = today.getHours();
    let min = today.getMinutes();
    //let sec = today.getSeconds();
    let time = hr + ":" + min;
    return time;
}