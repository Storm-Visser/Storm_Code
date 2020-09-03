let products = ["butter", "eggs", "bread", "flour", "sugar", "milk", "chocolate chip cookies", "potatoes", "sausages", "pizza"]
let destination = document.getElementById("list");
//maak de lijst
function createList()
{
    for (let index = 0; index < products.length; index++) 
    {
        let item = document.createElement("li");
        let text = document.createTextNode(products[index]);
        item.appendChild(text);
        destination.appendChild(item);
    }
}
//verander het negende item
function changeList()
{
    products[8] = (document.getElementById("toAdd").value);
    destination.innerHTML = "";
    createList();
}
document.onload = createList();