<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title></title>
    </head>
    <body>
        <?php
            // str_replace()  --> Vervangt het aangegeven gedeelte van een variabele.
            // str_ireplace() --> Idem, maar deze functie is case 'i'nsensitive.
            $email = "student@stenden.com";
            $newemail = str_replace("student", "naam", $email);
            echo $newemail . "<br />";
            
            // substr_replace() --> Vervangt het aantal chars aangegeven door de indexwaarden. 
            $newemail2 = substr_replace($newemail, "leerling", 0, 4);
            echo $newemail2 . "<br />";
            
            // String -> Array
            $cat = "longcat is long";
        
            $arraySplit = str_split($cat, 6);
            echo "<pre>";
            print_r($arraySplit);
            echo "</pre>";

            echo "<pre>";
            var_dump($arraySplit);
            echo "</pre>";
        
            // explode() -->  Breekt een string op in array-elementen op het aangegeven teken/char.
            $arrayExplode = explode(" ", $cat);
            echo "<pre>";
            var_export($arrayExplode);
            echo "</pre>";
            
            // Array -> String
            $catsArray = array("Bob", "Bob2", "Bob3");
            print_r($catsArray);
            echo "<br />";
            
            // implode() -->  Maakt een string uit de elementen van een array.
            $cats = implode(" ", $catsArray);
            echo $cats;
            
            // Sorteer Array
            $numberArray =  array(12, 14, 3, 29, 312, 0);
            foreach ($numberArray as $number)
            {
                echo $number . " ";
            }
            echo "<br />";
    
            sort($numberArray);

            foreach ($numberArray as $number)
            {
                echo $number . " ";
            }
            // String? --> Afgeleide van array, ieder teken (character) staat op een bepaalde positie!
            $hogeschool = "<p>Stenden";
            $hogeschool .= " is een hogeschool.</p>";
            echo $hogeschool;
            
            // strlen() --> Retourneert het aantal chars (karakters).
            $nummer = 45654;
            echo "<p>" . strlen($nummer) . "</p>";
            
            // str_word_count() --> Retourneert het aantal woorden.
            $film2 = "Alice in Wonderland";
            echo "<p>" . str_word_count($film2)  . "</p>";
            
            // ucfirst() --> Eerste woord, alleen de eerste letter UpperCase.
            // lcfirst() --> Eerste woord, alleen de eerste letter LowerCase.
            // ucwords() --> Alle woorden, eerste letter UpperCase.
            // strtolower() --> Alle woorden lowercase. 
            // strotoupper() --> Alle woorden uppercase.
            // ctype_upper() --> Controleert of de input uit hoofdletters bestaat.
            // ctype_lower() --> Controleert of de input uit kleine letters bestaat.
            $quote = "May ThE FOrCe bE WIth yOU!";
            echo ucfirst($quote) . "<br />";
            echo lcfirst($quote) . "<br />"; 
            echo ucwords(strtolower($quote)) . "<br />";  

            if(ctype_upper("HALLO"))
            {
                echo "De string bestaat uit hoofdletters.";
            }
            if (ctype_lower("hallo")) {
                echo "De string bestaat uit kleine letters.";
            }
             //substr() --> Retourneert chars, hierbij kan een startwaarde en eindwaarde worden meegegeven.
            //             Als de waarde negatief is dan wordt achteraan de variabele begonnen.
            $php = "hypertext preprocessor";
            echo substr($php, 4) . "<br />";
            echo substr($php, 0, 9) . "<br />";
            echo substr($php, -12) . "<br />";
            echo substr($php, -7, 5) . "<br />";
        
            // strrev() --> Omdraaien string
            echo "<p>" . strrev($php) . "</p><br />";
            
            // strpos() --> Retourneert de positie (getal) van de meegegeven variabele.
            // strchr() --> Retourneert het gedeelte van de string dat begint vanaf de aangegeven variabele.
            // strrchr() --> Retourneert het gedeelte van de string dat begint vanaf de aangegeven variabele, 
            //               maar begint nu achteraan met zoeken.
            $email = "student@stenden.com";
            echo strpos($email, '@') . "<br />";
            echo strchr($email, 's') . "<br />";
            echo strrchr($email, 's') . "<br />";
        ?>
    </body>
</html>


            
            

