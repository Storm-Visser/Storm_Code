<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>opdracht 7</title>
    </head>
    <body>
        <?php
        for ($x = 6; $x >= 1; $x--) {
            for ($z = 1; $z <= $x; $z++) {
                echo "$z&nbsp";
            }
            echo"<br>";
        }
        echo"<br>";



        $x2 = 6;
        while ($x2 >= 1) {
            $z2 = 1;
            while ($z2 <= $x2) {
                echo "$z2&nbsp";
                $z2++;
            }
            echo"<br>";
            $x2--;
        }
        echo"<br>";



        $x3 = 6;
        do {
            $z3 = 1;
            do {
                echo "$z3&nbsp";
                $z3++;
            } while ($z3 <= $x3);
            echo"<br>";
            $x3--;
        } while ($x3 >= 1)
        ?>
    </body>
</html>
