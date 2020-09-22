class calc
{
    constructor(name)
    {
        this.name = name;
    }
    getName()
    {
        return this.name;
    }
    setName(name)
    {
        this.name = name;
    }
    add()
    {
        let nr1 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 1))
        let nr2 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 2))
        document.getElementById("answer").innerHTML = nr1 + nr2;
    }
    substract()
    {
        let nr1 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 1))
        let nr2 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 2))
        document.getElementById("answer").innerHTML = nr1 - nr2;
    }
    multiply()
    {
        let nr1 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 1))
        let nr2 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 2))
        document.getElementById("answer").innerHTML = nr1 * nr2;
    }
    devide()
    {
        let nr1 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 1))
        let nr2 = parseInt(this.explodeNumbers(document.getElementById("toCalc").value, 2))
        document.getElementById("answer").innerHTML = nr1 / nr2;
    }
    explodeNumbers(string, number)
    {
        number = number - 1;
        let numberArray = string.split(",", 3);
        return numberArray[number];
    }
}

calc = new calc('hans');