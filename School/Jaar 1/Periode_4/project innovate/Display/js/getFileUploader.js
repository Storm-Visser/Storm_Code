/**
 * File upload voor Message. 
 * @note html valideerd op .jpg, .jpeg, png 
 * @note js valideert op .jpg, .jpeg, png 
 * @todo send to database.
 */
var form = document.getElementById('form')
var parentDiv = document.getElementById('result')

function validate_fileupload(fileName)
{
    // input waardes die toegestaan zijn.
    var allowed_extensions = new Array("jpg","jpeg","png");

    // split function split op de(.)
    // pop function geeft het laatste element en geeft hierdoor de extentie
    // toLower functie maak de waarde naar kleine letters voor de validatie
    var file_extension = fileName.split('.').pop().toLowerCase(); 

    for(var i = 0; i <= allowed_extensions.length; i++)
    {
        if(allowed_extensions[i]==file_extension)
        {
            form.addEventListener
            ('submit', function (event)
                {
                    event.preventDefault()

                    var reader = new FileReader()
                    var name = document.getElementById("image").files[0].name

                    reader.addEventListener
                    ('load', function()
                        {
                            if (this.result && localStorage)
                            {
                                window.localStorage.setItem(name, this.result)
                                alert("Image is saved locally.")
                                showImage()
                            }
                            else
                            {
                                alert("Somthing went wrong please try again.")
                            }
                        }
                    )
                    reader.readAsDataURL(document.getElementById("image").files[0])
                    console.log(name)
                }
            )

            // return om de functie te stoppen
            return true;
        }
    }
    alert('File upload went wrong pleas try again.'); 

    // haald de input weg uit de uploader, zodat je niks upload.
    fileInput.value = '';

    // return om de functie te stoppen
    return false;
}

/**
 * Functie om de files weer te geven
 * @note het is een loop, en er kunnen meerdere foto's in gezet worden.
 */
function showImage()
{
    for(let i = 0; i < window.localStorage.length; i++)
    {
        let res = window.localStorage.getItem(window.localStorage.key(i))
        var image = new Image()
        image.src = res;

        parentDiv.appendChild(image)
    }
}
showImage()

/**
 * Functie om alle files te verwijderen.
 * Verwijderd alle locale data.
 * @note Verwijderd dus ook ander data die bewaard wordt.
 */
function remove()
{
    window.localStorage.clear()
    parentDiv.innerHTML = ''
}

