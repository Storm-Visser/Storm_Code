<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>multidimensional array</title>
    </head>
    <body>
        <?php
        $boxes = array(//begin array
            array("small", 12, 10, 2.5),
            array("medium", 30, 20, 4),
            array("large", 60, 40, 11.5)
        );//eind array
        foreach ($boxes as $box) {//elke array in boxes opslaan als box
            $vol = $box[1] * $box[2] * $box[3];//stel volume op uit de 1ste, tweede en derde element uit de array box
            echo "the volume of the " . $box[0] . " box is: " . $vol . " cubic inch<br>";//echo het antwoord
        }
        ?>
    </body>
</html>
