class converter
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
    getMorse()
    {
        let normal = document.getElementById("toConvert").value;
        let array = normal.split("")
        let result = [];
        for (let i = 0; i < array.length; i++)
        {
            result.push(this.convertToMorse(array[i]));
        }
        document.getElementById("result").innerHTML = result.join("&nbsp&nbsp");
    }
    convertToMorse(letter)
    {
        switch(letter.toLowerCase())
        {
            case " ":
                return " / ";
                break;
            case "a":
                return "•-";
                break;
            case "b":
                return "-•••";
                break;
            case "c":
                return "-•-•";
                break;
            case "d":
                return "-••";
                break;
            case "e":
                return "•";
                break;
            case "f":
                return "••-•";
                break;
            case "g":
                return "--•";
                break;
            case "h":
                return "••••";
                break;
            case "i":
                return "••";
                break;
            case "j":
                return "•---";
                break;
            case "k":
                return "-•-";
                break;
            case "l":
                return "•-••";
                break;
            case "m":
                return "--";
                break;
            case "n":
                return "-•";
                break;
            case "o":
                return "---";
                break;
            case "p":
                return "•--•";
                break;
            case "q":
                return "--•-";
                break;
            case "r":
                return "•-•";
                break;
            case "s":
                return "•••";
                break;
            case "t":
                return "-";
                break;
            case "u":
                return "••-";
                break;
            case "v":
                return "•••-";
                break;
            case "w":
                return "•--";
                break;
            case "x":
                return "-••-";
                break;
            case "y":
                return "-•--";
                break;
            case "z":
                return "--••";
                break;
            default:
                return "not a letter";
        }
    }   
}

converter = new converter("geert");