<!--
 Naam:
 Studentnummer:
-->
<!DOCTYPE html>
<html>
    <head>
        <title>Stringbewerking</title>
    </head>
    <body>
        <?php
        $invoerString = "23-07-2010"; // dagen < als 10 moet een 0 voor staan. Voorbeeld: 01.
        $datumarray = explode("-",$invoerString);
        $dag = $datumarray[0];
        $maand = $datumarray[1];
        $jaar = $datumarray[2];
        $daggoed= $dag + 1 - 1;
        echo "deze persoon is gebooren op: $daggoed";
        if ($maand=01){
            echo " Januari";
        }
        elseif ($maand==02){
            echo " Februari";
        }
        elseif ($maand=03){
            echo " Maart";
        }
        elseif ($maand=04){
            echo " April";
        }
        elseif ($maand=05){
            echo " Mei";
        }
        elseif ($maand=06){
            echo " Juni";
        }
        elseif ($maand==7){
            echo " Juli";
        }
        elseif ($maand==08){
            echo " Augustus";
        }
        elseif ($maand=09){
            echo " September";
        }
        elseif ($maand10){
            echo " Oktober";
        }
        elseif ($maand=11){
            echo " November";
        }
        elseif ($maand=12){
            echo " December";
        }
        else{
            echo"die maand bestaat niet";
        }
        ?>
    </body>
</html>
