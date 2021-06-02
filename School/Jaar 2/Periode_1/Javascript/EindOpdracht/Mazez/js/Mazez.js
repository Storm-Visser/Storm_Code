class Game {
    constructor(Player, Maze) {
        this.player = Player;
        this.maze = Maze;
        this.points = 0;
        this.timer = new easytimer.Timer();
        this.timer.start({ countdown: true, startValues: { seconds: 180 } });
    }

    startGame() {
        document.getElementById("score").innerText = ("Score: " + this.points)
        document.getElementById("maze").innerHTML = "";
        //timer
        this.timer.reset();
        let timer = this.timer
            //set de start tijd in de timer
        $('#timer').html("<h2>" + timer.getTimeValues().toString() + "<h2>");
        //verander de timer elke seconde
        timer.addEventListener('secondsUpdated', function(e) {
            $('#timer').html("<h2>" + timer.getTimeValues().toString() + "<h2>");
        });
        //als de timer null berijkt
        this.timer.addEventListener('targetAchieved', function(e) {
            location.reload();
        });
        //voer functies uit
        this.maze.generateMaze();
        this.showMap();
    }

    showMap() {
        document.getElementById("maze").innerHTML = "";
        let last = false;
        for (let index1 = 0; index1 < this.maze.grid.length; index1++) {
            if (index1 == 30) {
                last = true
            }
            for (let index2 = 0; index2 < this.maze.grid[index1].length; index2++) {
                let div = document.createElement("div");
                let id = (index1 + "," + index2);
                div.id = id;
                if (index1 == 0 && index2 == 0) {
                    div.setAttribute("class", "start");
                } else if (last && index2 == 50) {
                    div.setAttribute("class", "finish");
                } else if (this.maze.grid[index1][index2] == 1) {
                    div.setAttribute("class", "path");
                } else {
                    div.setAttribute("class", "wall");
                }
                document.getElementById("maze").appendChild(div)
            }
        }
        let playerPos = (this.player.XPos + "," + this.player.YPos)
        document.getElementById(playerPos).setAttribute("style", "background-color: cyan;");
        if (this.player.XPos == 30 && this.player.YPos == 50) {
            this.finish();
        }
        //this.hideVision();
    }

    hideVision() {
        let XPos = this.player.XPos;
        let YPos = this.player.YPos;
        //hide alles
        $(".wall").css("background-color", "rgb(40,40,40)");
        $(".path").css("background-color", "rgb(40,40,40)");
        let toShow = [];
        //haal alle blokjes in een radius van 5 op
        for (let index = 0; index < 5; index++) {
            if (index == 0 || index == 4) {
                toShow.push(((XPos - 2) + index) + "," + (YPos - 1));
                toShow.push(((XPos - 2) + index) + "," + (YPos));
                toShow.push(((XPos - 2) + index) + "," + (YPos + 1));
            } else {
                toShow.push(((XPos - 2) + index) + "," + (YPos - 2));
                toShow.push(((XPos - 2) + index) + "," + (YPos - 1));
                toShow.push(((XPos - 2) + index) + "," + (YPos));
                toShow.push(((XPos - 2) + index) + "," + (YPos + 1));
                toShow.push(((XPos - 2) + index) + "," + (YPos + 2));
            }
        }
        //laat alle blojes in die radius zien
        for (let index = 0; index < 21; index++) {
            let coords = toShow[index];
            let coordArrayString = coords.split(",");
            let coordArrayInt = [parseInt(coordArrayString[0]), parseInt(coordArrayString[1])];
            let element = document.getElementById(coords);
            if (index == 10) {
                $(element).css("background-color", "cyan");
            } else if (this.maze.isInMaze(coordArrayInt)) {
                if (element.className == "wall") {
                    $(element).css("background-color", "black");
                } else if (element.className == "path") {
                    $(element).css("background-color", "wheat");
                }
            }
        }
    }

    moveN() {
        if (this.canMove(this.player.XPos - 1, this.player.YPos)) {
            this.player.XPos = this.player.XPos - 1;
        }
        this.showMap();
    }

    moveW() {
        if (this.canMove(this.player.XPos, this.player.YPos + 1)) {
            this.player.YPos = this.player.YPos + 1;
        }
        this.showMap();
    }

    moveS() {
        if (this.canMove(this.player.XPos + 1, this.player.YPos)) {
            this.player.XPos = this.player.XPos + 1;
        }
        this.showMap();
    }

    moveE() {
        if (this.canMove(this.player.XPos, this.player.YPos - 1)) {
            this.player.YPos = this.player.YPos - 1;
        }
        this.showMap();
    }

    canMove(XPos, YPos) {
        if (XPos >= 0 && XPos < 31) {
            if (YPos >= 0 && YPos < 51) {
                if (this.maze.grid[XPos][YPos] == 1) {
                    return true;
                } else {
                    return false
                }
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    finish() {
        this.player.XPos = 0;
        this.player.YPos = 0;
        this.points++;
        this.timer.reset();
        this.startGame();
    }
}

class Maze {
    constructor() {
        this.grid = []
    }

    generateMaze() {
        //0 is een wall, 1 is een path
        //vul het doolhof met muuren
        for (let index1 = 0; index1 < 31; index1++) {
            this.grid[index1] = []
            for (let index2 = 0; index2 < 51; index2++) {
                this.grid[index1][index2] = 0;
            }
        }
        //maak de startpositie
        this.grid[0][0] = 1;
        //nodige variabelen
        let currentX = 0;
        let currentY = 0;
        let dir;
        //een neigbour bestaat uit het volgende: x coordinaat, y coordinaat, richting
        let neighbours = [];
        //new neighbours bestaat uit de vier mogelijk nieuwe neighbours
        let newNeighbours = [];
        //maak de eerste neaighbour aan
        neighbours[0] = [2, 0, "N"];
        neighbours[1] = [0, 2, "E"];
        //loop door alle neighbours
        while (neighbours.length > 0) {
            //selecteer een van de neighbours
            let randNR = Math.ceil(Math.random() * neighbours.length) - 1;
            let selected = neighbours[randNR];
            //maak die neighbour een path
            currentX = selected[0];
            currentY = selected[1];
            dir = selected[2];
            this.grid[currentX][currentY] = 1;
            //maak de connectie aan de hand van de richting (hij gaat met stappen van een dus moet ook het overgeslagen muurtje worden laten zien)
            switch (dir) {
                case "S":
                    this.grid[(currentX + 1)][currentY] = 1;
                    break;
                case "W":
                    this.grid[currentX][(currentY + 1)] = 1;
                    break;
                case "N":
                    this.grid[(currentX - 1)][currentY] = 1;
                    break;
                case "E":
                    this.grid[currentX][(currentY - 1)] = 1;
                    break;
            }
            //haal de gekozen neigbour uit de lijst met neighbours 
            neighbours.splice(randNR, 1);
            //haal alle mogelijke nieuwe neighbours op en voeg ze aan de neighbours lijst toe
            newNeighbours[0] = [(currentX + 2), currentY, "N"];
            newNeighbours[1] = [(currentX - 2), currentY, "S"];
            newNeighbours[2] = [currentX, (currentY + 2), "E"];
            newNeighbours[3] = [currentX, (currentY - 2), "W"];
            //loop deoor de nieuwe neighbours
            for (let index = 0; index < 4; index++) {
                //check of ze niet buiten de maze zitten
                if (this.isInMaze(newNeighbours[index])) {
                    //check of het al een pad is
                    if (this.isNotAPath(newNeighbours[index])) {
                        //maak de mogelijke richtinen van de nieuwe neighbour aan om te checken
                        let toCheck1 = [newNeighbours[index][0], newNeighbours[index][1], "N"];
                        let toCheck2 = [newNeighbours[index][0], newNeighbours[index][1], "W"];
                        let toCheck3 = [newNeighbours[index][0], newNeighbours[index][1], "S"];
                        let toCheck4 = [newNeighbours[index][0], newNeighbours[index][1], "E"];
                        //check of de lijst met neighbours de nieuwe neigbour van alle mogelijke richtingen al bevat
                        if (!this.contains(neighbours, toCheck1) && !this.contains(neighbours, toCheck2) && !this.contains(neighbours, toCheck3) && !this.contains(neighbours, toCheck4)) {
                            //voeg de nieuwe neighbour toe aan de neighbours lijst
                            neighbours.push(newNeighbours[index]);
                        }
                    }
                }
            }
        }
    }

    isInMaze(coords) {
        if (coords[0] >= 0 && coords[0] < 31) {
            if (coords[1] >= 0 && coords[1] < 51) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    isNotAPath(coords) {
        if (this.grid[coords[0]][coords[1]] == 0) {
            return true;
        } else {
            return false;
        }
    }

    contains(array, toFind) {
            let toFindString = JSON.stringify(toFind);

            let contains = array.some(function(ele) { return JSON.stringify(ele) === toFindString; });
            return contains;
        }
        // simpele wait functie
    wait(ms) {

    }

}

class Player {
    constructor() {
        this.XPos = 0
        this.YPos = 0
    }
}

function main() {
    let maze = new Maze();
    let player = new Player();
    let game = new Game(player, maze);
    let timer = new easytimer.Timer();

    game.startGame();
    //eventlistener voor het bewegen
    window.addEventListener("keyup", onKeyPress, false);

    function onKeyPress(event) {
        let key = event.keyCode;
        switch (key) {
            case 68:
                game.moveW();
                break;
            case 83:
                game.moveS();
                break;
            case 65:
                game.moveE();
                break;
            case 87:
                game.moveN();
                break;
            default:
                break;
        }
    }


}

Document.onload = main();