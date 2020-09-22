class cookie
{
    constructor(name)
    {
        this.name = name;
        this.fortunes = ["Believe it can be done.",
            "Better ask twice than lose yourself once.",
            "Bide your time, for success is near.",
            "Carve your name on your heart and not on marble.",
            "Change is happening in your life, so go with the flow!",
            "Competence like yours is underrated.",
            "Congratulations! You are on your way.",
            "Could I get some directions to your heart?",
            "Curiosity kills boredom. Nothing can kill curiosity.",
            "Dedicate yourself with a calm mind to the task at hand.",
            "Depart not from the path which fate has you assigned.",
            "Determination is what you need now."];
    }

    tellFortune()
    {
        document.getElementById("fortune").innerHTML = this.fortunes[Math.ceil(Math.random() * this.fortunes.length)-1];
    }

}
teller = new cookie("chocholate chips");