class Singer
{
    constructor(name, song)
    {
        this.name = name;
        this.song = song;
    }
    sing()
    {
        let destination = document.getElementById("toAdd");
        
        let title = document.createElement("h1");
        let titletext = document.createTextNode(this.name + " wil now sing: " + this.song);
        title.appendChild(titletext);
        destination.appendChild(title);
        for(let i = 99; i > -1; i--)
        {
            if(i > 1)
            {
                let item = document.createElement("p");
                let text = document.createTextNode(i + " bottles of beer on the table");
                item.appendChild(text);
                destination.appendChild(item);
                let item2 = document.createElement("p");
                let text2 = document.createTextNode(i + " bottles of beer, take one away");
                item2.appendChild(text2);
                destination.appendChild(item2);
                
            }
            else if(i == 1)
            {
                let item = document.createElement("p");
                let text = document.createTextNode(i + " bottle of beer on the table");
                item.appendChild(text);
                destination.appendChild(item);
                let item2 = document.createElement("p");
                let text2 = document.createTextNode(i + " bottle of beer, take it away");
                item2.appendChild(text2);
                destination.appendChild(item2);
                
            }
            else
            {
                let item = document.createElement("p");
                let text = document.createTextNode("no more bottles of beer on the table");
                item.appendChild(text);
                destination.appendChild(item);
            }
        }
    }
}

const hans = new Singer("Hans", "99 Bottles");
hans.sing();
