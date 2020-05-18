<!--
 Naam:Storm Visser
 Studentnummer: 1234567
-->
<!DOCTYPE html>
<html>
    <head>
        <title>Lus(loop)opdracht</title>
    </head>
    <body>
        <?php
            for($x=1; $x<=8; $x++){
                for($i=1; $i<=8; $i++){
                    if($i==$x){
                        echo"Y";
                    }
                    else{
                        echo"O";
                    }
                }
                echo"<br>";
            }
            for($x=7; $x>=1; $x--){
                for($i=1; $i<=8; $i++){
                    if($i==$x){
                        echo"Y";
                    }
                    else{
                        echo"O";
                    }
                }
                echo"<br>";
            }
        ?>
    </body>
</html>
