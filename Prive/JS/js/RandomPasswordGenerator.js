let codes = []
for (let index = 0; index < 20000000; index++) {
    let code = "";
    let type = Math.ceil(Math.random() * 3);
    if (type == 1) {
        let caseType = Math.ceil(Math.random() * 2);
        if (caseType == 1) {
            let possible = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
            let rand = Math.ceil(Math.random() * 26);
            code = possible[rand];
        } else {
            let possible = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
            let rand = Math.ceil(Math.random() * 26);
            code = possible[rand];
        }
    } else if (type == 2) {
        code = Math.ceil(Math.random() * 10) - 1;
    } else {
        let possible = [".", ",", "?", "!", "@", "$", "#", "$", "%", "^", "&", "*", "-", "=", "+"];
        let rand = Math.ceil(Math.random() * 15);
        code = possible[rand];
    }
    codes.push(code)
}
document.getElementById("persoon").innerHTML = codes.join("");