<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>opdracht 7</title>
    </head>
    <body>
        <?php
        for ($x = "10"; $x >= 1; $x--) {
            for ($y = 1; $y <= $x; $y++) {
                echo"*";
            }
            echo"<br>";
        }
        echo"<br>";



        $x2 = 10;
        while ($x2 >= 1) {
            $y2 = 1;
            while ($y2 <= $x2) {
                echo"*";
                $y2++;
            }
            echo"<br>";
            $x2--;
        }
        echo "<br>";



        $x3 = 10;
        do {
            $y3 = 1;
            do {
                echo"*";
                $y3++;
            } while ($y3 <= $x3);
            echo"<br>";
            $x3--;
        } while ($x3 >= 1)
        ?>
    </body>
</html>
