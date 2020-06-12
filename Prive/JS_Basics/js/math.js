// simpele wait functie
function wait(ms){
    var start = new Date().getTime();
    var end = start;
    while(end < start + ms) {
      end = new Date().getTime();
   }
}
//functie om een random getal tussen 0 en 365 te krijgen
function random()
{
    let x = Math.random() * 256;
    return x;
}

//         var degree = Math.round((Math.random() * 10) + 10);
//         toString(degree);

document.body.style.background = "rgb(" + random() +"," + random() + "," + random() +")";
let text = document.getElementById("text");
text.style.color = "rgb(" + random() +"," + random() + "," + random() +")";
console.log("rgb(" + random() +"," + random() + "," + random() +")")
text.style.textAlign = "center";
text.style.fontSize = "230px";
text.style.paddingTop = "230px";
text.style.fontFamily = "verdana"
wait(200);

location.reload();