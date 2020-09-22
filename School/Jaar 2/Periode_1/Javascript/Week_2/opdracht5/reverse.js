class checker
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
    checkPalindrome()
    {
        let normal = document.getElementById("toCheck").value;
        let reverse = this.reverseString(normal);
        if (normal === reverse)
        {
            document.getElementById("answer").innerHTML = "This is a palindrome";
        }
        else
        {
            document.getElementById("answer").innerHTML = "This is not a palindrome";
        }
    }
    reverseString(string)
    {
        let array = string.split("").reverse();
        return array.join("");
    }
}

checker = new checker("gert");