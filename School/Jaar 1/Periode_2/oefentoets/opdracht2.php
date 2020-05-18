<!--
 Naam:Storm Visser
 Studentnummer:123456
-->
<!DOCTYPE html>
<html>
    <head>
        <title>Wegenbelasting berekenen</title>
    </head>
    <body>
        <h1>Bepalen Wegenbelasting</h1><hr/>
        <?php
        if (empty($_POST["gewicht"])) {
            echo "geef het gewicht van het voertuig op in kilogrammen";
        } 
        else {
            if(!isset($_POST["voertuig"])){
            echo "selecteer een voertuig";
            }
            else {
                $gewicht = $_POST["gewicht"];
                $voertuig = $_POST["voertuig"];
                if($voertuig == 1){
                    $prijs = $gewicht * 0.60;
                    echo "te betalen belasting: $prijs euro";
                }
                elseif($voertuig == 2){
                    $prijs = $gewicht * 0.55;
                    echo "te betalen belasting: $prijs euro";
                }
                else{
                    $prijs = $gewicht * 0.50;
                    echo "te betalen belasting: $prijs euro";
                }
            }
        }
        ?>
        <form action="<?php echo$_SERVER['PHP_SELF']; ?>" method="post">
            <input type="text" name="gewicht"> <br>
            <input type="radio" name="voertuig" value="1">Motor<br>
            <input type="radio" name="voertuig" value="2">Personenwagen<br>
            <input type="radio" name="voertuig" value="3">Vrachtauto<br>
            <input type="submit" name="submit" value="bereken belasting"><br>
        </form>
        
    </body>
</html>