// Comment gwn even testen
console.log('hello world');

let car = {
    horsePower: 350,
    weight: 2000,
    tractionFactor: 0.9
}

function getTime(car, distance){
    let force = car.horsePower * 12;
    let acceleration = force / car.weight;
    let time = distance * acceleration;
    console.log(time);
    alert(time + " seconden.");
}

getTime(car, 100);