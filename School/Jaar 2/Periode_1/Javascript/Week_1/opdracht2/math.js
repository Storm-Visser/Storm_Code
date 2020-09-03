let number1 = 8;
let number2 = 4;

function addition()
{
    return number1 + number2;
}
function substraction()
{
    return number1 - number2;
}
function multiplication()
{
    return number1 * number2;
}
function devision()
{
    return number1 / number2;
}

document.getElementById("math").innerHTML = "with the numbers " + number1 + " and " + number2 + ", you can do these calculations:";
document.getElementById("math+").innerHTML = number1 + " + " + number2 + " = " + addition();
document.getElementById("math-").innerHTML = number1 + " - " + number2 + " = " + substraction();
document.getElementById("math*").innerHTML = number1 + " * " + number2 + " = " + multiplication();
document.getElementById("math/").innerHTML = number1 + " / " + number2 + " = " + devision();