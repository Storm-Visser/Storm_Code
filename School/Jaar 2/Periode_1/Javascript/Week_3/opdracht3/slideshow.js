class slideshow
{
    constructor(srcFolder)
    {
        this.count = 1;
        this.srcFolder = srcFolder;
        
    }
    
    getNextImg()
    {
        if(this.count == 5)
        {
            this.count = 1;
        }
        else
        {
            this.count = this.count + 1;
        }
        let img = document.getElementById("img");
        img.src = this.srcFolder + this.count + ".jpg";
        document.getElementById("toAdd").appendChild(img);
    }
}
show = new slideshow("img/");
Document.onload = counter(); //als de pagina laad voer de counter functie uit
function counter()
{
    show.getNextImg();//laat de volgende foto zien
    setTimeout(counter, 10000);//wacht 10 seconden en roept zichzelf aan
}
