let strings = ["hallo", "wij", "zijn", "losse", "strings"];
function showStrings()
{
    let toAdd = "";
    for (let index = 0; index < strings.length; index++) {
        toAdd = toAdd + strings[index] + " ";
    }
    document.getElementById("strings").innerText = toAdd;
}
function addString()
{
    strings.push(document.getElementById("toAdd").value);
    showStrings();
}
document.onload = showStrings();