class slideshow
{
    constructor(srcFolder)
    {
        this.count = 1;
        this.srcFolder = srcFolder;
        
    }
    
    getImg()
    {
        console.log(this.count);
        let img = document.getElementById("img");
        img.src = this.srcFolder + this.count + ".jpg";
        document.getElementById("toAdd").appendChild(img);
    }

    next()
    {
        if(this.count == 5)
        {
            this.count = 1;
        }
        else
        {
            this.count = this.count + 1;
        }
        this.getImg();
    }

    previous()
    {
        if(this.count == 1)
        {
            this.count = 5;
        }
        else
        {
            this.count = this.count - 1;
        }
        this.getImg();
    }
}
show = new slideshow("img/");
Document.onload = show.getImg()