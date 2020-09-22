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
        console.log(this.count);
        let img = document.getElementById("img");
        img.src = this.srcFolder + this.count + ".jpg";
        document.getElementById("toAdd").appendChild(img);
    }
}
show = new slideshow("img/");
Document.onload = counter();
function counter()
{
    show.getNextImg();
    setTimeout(counter, 2000);
}