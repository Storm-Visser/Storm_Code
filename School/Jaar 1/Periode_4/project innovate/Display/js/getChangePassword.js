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
const newPassword = document.getElementById('newPassword')
const form = document.getElementById('form')
const errorElement = document.getElementById('error')

/**
 * Functie om het wachtwoord te wijzigenen met validatie eisen
 * Validatie lijst:
 * - Alle input velden moeten ingelvuld zijn.
 * - Alle input moet meer dan 3 karakters bevatten.
 * - Alle input moet minder dan 20 karakters bevatten.
 * - Wachtwoorden mogen niet wachtwoord of password zijn.
 * - New password mag niet old password zijn.
 * - Username cannot be te password.
 * - Username cannot be te New password.
 * - Check of username en password bij elkaar horen.
 * @todo Zorg er voor dat het wachtwoord echt gewijzigd wordt.
 */
function changePassword()
{
	form.addEventListener
	('submit', (e) => 
		{
			// array voor de error meldingen.
			let messages = []

			// if input username is leeg error.
			if (username.value === '' || username.value === ' ') 
			{
				messages.push('Username is required')
			}
			// if input password is leeg error.
			else if (password.value === '' || password.value === ' ') 
			{
				messages.push('Old password is required')
			}
			// if input nwePassword is leeg error.
			else if (newPassword.value === '' || newPassword.value === ' ') 
			{
				messages.push('New password is required')
			}

			// if username bestaat uit minder dan 3 karakters error.
			else if (username.value.length <= 3) 
			{
				messages.push('username must be longer than 3 characters')
			}
			// if username beaat uit meer dan 19 karakters error.
			else if (username.value.length >= 20) 
			{
				messages.push('username must be less than 20 characters')
			}

			// if old password bestaat uit minder dan 3 karakters error.
			else if (password.value.length <= 3) 
			{
				messages.push('Old password must be longer than 3 characters')
			}
			// if old password beaat uit meer dan 19 karakters error.
			else if (password.value.length >= 20) 
			{
				messages.push('Old password must be less than 20 characters')
			}

			// if new password bestaat uit minder dan 3 karakters error.
			else if (newPassword.value.length <= 3) 
			{
				messages.push('NewPassword must be longer than 3 characters')
			}
			// if new password beaat uit meer dan 19 karakters error.
			else if (newPassword.value.length >= 20) 
			{
				messages.push('NewPassword must be less than 20 characters')
			}

			// if old password is "wachtwoord" of "password" error.
			else if (password.value === 'password'|| password.value === 'wachtwoord' 
			|| password.value === 'Password'|| password.value === 'Wachtwoord') 
			{
				messages.push('Password cannot be password or wachtwoord')
			}
			// if new password is "wachtwoord" of "password" error.
			else if (newPassword.value === 'password'|| newPassword.value === 'wachtwoord' 
			|| newPassword.value === 'Password'|| newPassword.value === 'Wachtwoord') 
			{
				messages.push('New Password cannot be password or wachtwoord')
			}

			// if new password is old password error.
			else if(newPassword.value === password.value)
			{
				messages.push('New Password cannot be old password')
			}

			// if username is password error.
			else if(username.value === password.value)
			{
				messages.push('The username cannot be used as password')
			}

			// if username is new password error.
			else if(username.value === newPassword.value)
			{
				messages.push('The username cannot be used as new password')
			}

			// if input username en input password gelijk zijn aan username en password uit array user.
			else
			{
				// loop door de array list en vergelijk met user input.
				for(var i = 0; i < user.length; i++) 
				{
					// Checkt of user input overeenkomt met een waarde die in de user array staat.
					if(username.value == user[i].username && password.value == user[i].password) 
					{
						// stuur de gebruiker na validatie door naar de volgende pagina.
						e.preventDefault()

						// if validatie accord change te password in te array list
						// ik weet niet hoe dat moet. 
						alert(username.value + " heeft inderdaad " + password.value + 
								' als wachtwoord, maar ik weet niet hoe ik het moet veranderen naar ' + newPassword.value +".")
								window.location.href = "Test_logoffPage.html";
								/**
								 * @todo 
								 * Hier zou de code moeten komen om ook daadwerkelijk het waschtwoord te wijzigen
								 */
						return
					}
				}
				e.preventDefault()
				messages.push("Somting went wrong, please try again.")
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
