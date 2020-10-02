class fibonacci
{
    constructor(amount)
    {
        this.amount = amount;
        this.N1 = 0;
        this.N2 = 1;
        this.destination = document.getElementById("toAdd");
    }

    getNumbers()
    {
        for(let i = 0; i < this.amount; i++)
        {
            let add = document.createElement("p");
            add.innerHTML = this.N1;
            this.destination.appendChild(add);
            let N3 = this.N1 + this.N2;
            this.N1 = this.N2;
            this.N2 = N3;
        }
    }
}
series = new fibonacci(20);
Document.onload = series.getNumbers();