<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8"/>
        <title>opdracht8,2</title>
    </head>
    <body>
        <form action="<?php echo htmlentities($_SERVER['PHP_SELF']); ?>" method="post">
            <textarea name="textarea"></textarea> <br>
            <input type="submit">
        </form>
        <?php
        $wordsin = $_POST["textarea"];
        $wordarray = explode (" ",$_POST["textarea"]);
        foreach ($wordarray as $word)
        {
            $letter1 = substr ($word, 0,1);
            $letterrest = substr ($word, 1);
            if (ctype_upper($letter1) && (ctype_lower ($letterrest)))
            {
                echo $word . "<br>"; 
            }
            else
            {
                echo strtolower($word) . "<br>";
            }
        }
        ?>
    </body>
</html>

