<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>testen in PHP</title>
    <link rel="stylesheet" href="styles/grid1.css">
</head>

<body>
    <?php
        $list = array("appel", "peer", "banaan", "kiwi", "mango");
        //functie 1; alles met een a
        foreach ($list as $fruit1)
        {
            if(strpos($fruit1, "a")!== false)
            {
                echo $fruit1 . " contains an a<br>";
            }
        }
        echo "<br>";
        //functie 2; meer dan zes karakters
        foreach ($list as $fruit2)
        {
            if (strlen($fruit2) > 6) 
            {
                echo $fruit2 . " has more than 6 characters<br>";
            }
        }
        echo "<br>";
        //functie 3; beginnen met k
        foreach ($list as $fruit3)
        {
            $first = substr($fruit3, 0, 1);
            if($first == "k")
            {
                echo $fruit3 . " starts with a k<br>";
            }
        }
        echo "<br>";
    ?>
</body>

</html>