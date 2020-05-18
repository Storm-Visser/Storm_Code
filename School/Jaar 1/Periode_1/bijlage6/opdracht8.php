<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>opdracht8</title>
    </head>
    <body>
        <?php
        //14 juni 2016
        $datum = 14062016;
        $dag = ($datum/1000000)%100;
        echo "dag $dag ";
        $maand = ($datum/10000)%100;
        echo "maand $maand ";
        $jaar = $datum%10000;
        echo "jaar $jaar";
        //modulo % pakt aleen getallen voor de comma en anders de laatste gelijk aan het aantal nullen
        ?>
    </body>
</html>
