/**
 * main functies
 * hier worden alle functies aangeroepen
 * 
 * @manual
 * Stap 1. 
 * plaats je import in het volgende formaat:
 * import { functieNaam } from 'fileLocatie';
 * 
 * Stap 2.
 * roep daarna de functie aan
 * 
 * Stap 3.
 * aan het eind van de file met de functie zet je een export in dit formaat:
 * export { functienaam };
 */
import { getTime } from './getTime.js';
import { getCurrentDate } from './getDate.js';
import { getDetails } from './getDetails.js';

/**
 * @note deze werkt niet
 * @Storm_Visser kun jij dit oplossen?
 * import { getDetails } from './getDetails.js';
*/

getTime();

getCurrentDate();

getDetails("#737373");





