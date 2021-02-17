let array = [1,23,14212,231,1];

function getHighestElement()
{
    let highest = array[0];
    for (let i = 0; i < array.length; i++) {
        
        if (array[i] > highest)
        {
            highest = array[i];
        }      
    }
    return highest;
}

//dit geeft een O(n)