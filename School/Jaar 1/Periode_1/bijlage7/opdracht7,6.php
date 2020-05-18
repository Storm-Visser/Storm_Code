<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>opdracht 7</title>
    </head>
    <body>
        <?php
        $getal = 1;
        do {
            $getal2 = 1;
            do {
                echo "*";
                $getal2++;
            } while ($getal2 <= 10);
            echo "<br>";
            $getal++;
        } while ($getal <= 5);
        echo"<br>";




        for ($getal3 = 1; $getal3 <= 5; $getal3++) {
            for ($x = 1; $x <= 10; $x++) {
                echo"*";
            }
            echo"<br>";
        }
        echo "<br>";


        
        $x2 = 1;
        while ($x2 <= 5) {
            $y2 = 1;
            while ($y2 <= 10) {
                echo"*";
                $y2++;
            }
            echo"<br>";
            $x2++;
        }
        ?>
    </body>
</html>
