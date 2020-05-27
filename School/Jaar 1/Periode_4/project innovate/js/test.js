let json = {
    firstName: "Gerjan",
    lastName: "Van Oenen",
    status: 0,
    Path : "http//:foto.com"
}
// <head>
// <style>#myDiv {position: relative;}</style>
// </head>
// <body>
//     <script>
//         function myFunction() {
//             var leftvar = Math.random()*1000;
//             var topvar = Math.random()*1000;

//             var elem = document.getElementById('myDiv');

//             elem.style.left = leftvar + 'px';
//             elem.style.top  = topvar + 'px';            
//         }
//         window.onload = myFunction;
//     </script>
//     <div id="myDiv">
//         <p>Test</p>
//     </div>
// </body>

function getColour(){
    let colour;
    switch(json.status) {
        case 0:
            colour = "green"
            break;
        case 1:
            colour = "red"
            break;
        case 2:
            colour = "#ffe066"
            break;
        default:
            colour = "grey"
      }
      return colour;
}
window.onload = getColour;

function getDetails(){
    let colour = getColour()
    let details = json.firstName + " "+ json.lastName + " " + json.Path;
    let element = document.getElementById('header');
    element.style.color = colour;
    let element2 = document.getElementById('head');
    element2.innerHTML = details;
    return details;
}
window.onload = getDetails;

function getTime(){
    let today = new Date();
    let hr = today.getHours();
    let min = today.getMinutes();
    //let sec = today.getSeconds();
    let time = hr + ":" + min ;
    return time;
}

function getCurrentDate(){
    let today = new Date();
    let year = today.getFullYear();
    let month = today.getMonth();
    let day = today.getDate();
    let date = year + "/" + month + "/" + day;
    return date;
}
