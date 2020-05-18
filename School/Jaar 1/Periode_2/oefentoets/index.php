<!--
 Naam:Storm Visser
 Studentnummer: 123412345
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
        if ($maand==1){
            echo " Januari";
        }
        elseif ($maand==2){
            echo " Februari";
        }
        elseif ($maand==3){
            echo " Maart";
        }
        elseif ($maand==4){
            echo " April";
        }
        elseif ($maand==5){
            echo " Mei";
        }
        elseif ($maand==6){
            echo " Juni";
        }
        elseif ($maand==7){
            echo " Juli";
        }
        elseif ($maand==8){
            echo " Augustus";
        }
        elseif ($maand==9){
            echo " September";
        }
        elseif ($maand==10){
            echo " Oktober";
        }
        elseif ($maand==11){
            echo " November";
        }
        elseif ($maand==12){
            echo " December";
        }
        else{
            echo"die maand bestaat niet";
        }
        echo " $jaar"; 
        
        switch ($maand){
            case 3:
                echo " in de voorjaarperiode";
                break;
            case 6:
                echo " in de zomerperiode";
                break;
            case 9:
                echo " in de herfstperiode";
                break;
            case 12:
                echo " in de winterperiode";
                break;
            case 4:
                echo " in de voorjaarperiode";
                break;
            case 7:
                echo " in de zomerperiode";
                break;
            case 10:
                echo " in de herfstperiode";
                break;
            case 1:
                echo " in de winterperiode";
                break;
            case 5:
                echo " in de voorjaarperiode";
                break;
            case 8:
                echo " in de zomerperiode";
                break;
            case 11:
                echo " in de herfstperiode";
                break;
            case 2:
                echo " in de winterperiode";
                break;
                
        }
        ?>
    </body>
</html>