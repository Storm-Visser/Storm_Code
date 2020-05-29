const TODAY = new Date();
/**
 * Functie om de tijd van het device op te halen.
 * Note: Dit gebreurd bij elke refresh.
 * @return {time} De huidige tijd van het device.
 */
function getTime()
{
    let hr = TODAY.getHours();
    let min = TODAY.getMinutes();
    if(hr < 10)
    {
        hr = "0" + hr;
    }
    if(min < 10)
    {
        min = "0" + min;
    }
    //let sec = TODAY.getSeconds();
    //let time = hr + ":" + min + ":" + sec;
    let time = hr + ":" + min;
    let element = document.getElementById('time');
    element.innerHTML = time;
    return time;
}
export { getTime }; 