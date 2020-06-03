/**
 * Array list die de JSON file moet voorstellen.
 */
var user = 
[
	{ // user @ 0 index
		username: "mark",
		password: "mark1"
	},
	{ // user @ 1 index
		username: "storm",
		password: "storm1"
	},
	{ // user @ 2 index
		username: "jenny",
		password: "jenny1"
	}
]

/**
 * Constanten voor de {checkUsernameAndPassword()} functie.
 */
const username = document.getElementById('name')
const password = document.getElementById('password')
const formLogin = document.getElementById('form')
const errorElement = document.getElementById('error')

/**
 * Functie om de user input voor username en password te valideren.
 * Na de validate met de array user wordt de gebruiker doorgestuurd en stopt de code. 
 * 
 * Validatie lijst:
 * - Alle input velden moeten ingelvuld zijn.
 * - Alle input moet meer dan 3 karakters bevatten.
 * - Alle input moet minder dan 20 karakters bevatten.
 * - Wachtwoorden mogen niet wachtwoord of password zijn.
 * - Username cannot be te password.
 * - Check of username en password bij elkaar horen.
 */
function checkUsernameAndPassword()
{
	formLogin.addEventListener
	('submit', (e) => 
		{
			// array voor de error meldingen.
			let messages = []

			// if input username is leeg error.
			if (username.value === '' || username.value == null || username.value === ' ') 
			{
				messages.push('Username is required')
			}

			// if input password is leeg error.
			else if (password.value === '' || password.value == null || password.value === ' ') 
			{
				messages.push('Password is required')
			}

			// if password bestaat uit minder dan 3 karakters error.
			else if (username.value.length <= 3) 
			{
				messages.push('Password must be longer than 3 characters')
			}

			// if password beaat uit meer dan 19 karakters error.
			else if (username.value.length >= 20) 
			{
				messages.push('Password must be less than 20 characters')
			}

			// if password bestaat uit minder dan 3 karakters error.
			else if (password.value.length <= 3) 
			{
				messages.push('Password must be longer than 3 characters')
			}

			// if password beaat uit meer dan 19 karakters error.
			else if (password.value.length >= 20) 
			{
				messages.push('Password must be less than 20 characters')
			}

			// if password is wachtwoord of password error.
			else if (password.value === 'password'|| password.value === 'wachtwoord' 
					|| password.value === 'Password'|| password.value === 'Wachtwoord') 
			{
				messages.push('Password cannot be password or wachtwoord')
			}

			// if username is password error.
			else if(username.value === password.value)
			{
				messages.push('The username cannot be used as password')
			}

			// if input username en input password gelijk zijn aan username en password uit array user.
			// ga naar de volgende pagina, anders geef een errror. 
			else
			{
				var inputUsername = username.value
				var inputPassword = password.value
				// loop door de array list en vergelijk met user input.
				for(var i = 0; i < user.length; i++) 
				{
					// Checkt of user input overeenkomt met een waarde die in de user array staat.
					if(inputUsername == user[i].username && inputPassword == user[i].password) 
					{
						// stuur de gebruiker na validatie door naar de volgende pagina.
						e.preventDefault()
						alert(inputUsername + " is logged in!!!")
						window.location.href = "Test_newsfeedLogin.html";
						return
					}
				}
				e.preventDefault()
				messages.push("Incorrect username or password.")
			}

			// Als de input niet voldoet stuur dan de error naar het scherm
			if(messages.length > 0) 
			{
				e.preventDefault()
				errorElement.innerText = messages.join(', ')
			}
		}
	)
}


/**
 * @note na de validatie zou je een get kunnen maken waarin je de username in de url balk zet.
 * op die manier kun je kijken of de gebruiker op een pagina mag komen, en of de gebruiker een gebruiker is.
 */


/**
 * @deprecated {getInfo()} validate is ingebouwd bij de checkUsernameAndPassword functie.
 * Waardoor de check al gedaan wordt in de functie en is aangepast aan de eisen van het systeem.
 * Functie om de user input te valideren met de array.
 * Validate {true} Ingelogd melding, waarna je wordt doorgelinkt naar de ingelogde pagina.
 * Validate {false} Error melding.
 * @param {username} De input die de user invuld.
 * @param {password} De input die de user invuld.
 */
// function getInfo() 
// {
// 	// user input naar var 
// 	var username = document.getElementById('username').value
// 	var password = document.getElementById('password').value

//     for(var i = 0; i < user.length; i++) 
//     {
//         // Checkt of user input overeenkomt met een waarde die in de objPeople array staat.
//         if(username == user[i].username && password == user[i].password) 
//         {
// 			alert(inputUsername + " is logged in!!!")
//             // stop de functie als je ingelogd bent
//             window.location.href = "Test_newsfeedLogin.html";
// 			return
// 		}
// 	}
// 	alert("Incorrect username or password.")
//}