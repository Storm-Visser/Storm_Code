//hier worden alle functies aangeroepen
//zet hier je import neer in het volgende formaat:
//import { functieNaam } from 'fileLocatie';
import { getTime } from './getTime.js';
import { getCurrentDate } from './getDate.js';
import { getDetails } from './getDetails.js';
//roep je functie aan
getDetails();
getTime();
getCurrentDate();
//aan het eind van de file met de functie zet je een export in dit formaat:
//export { functienaam }; 