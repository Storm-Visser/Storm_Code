<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8"/>
        <title>opdracht8,1</title>
    </head>
    <body>
        <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
            <textarea name="textarea"></textarea> <br>
            <input type="submit">
        </form>
        <?php
        $wordsin = $_POST["textarea"];
        $wordarray = explode (" ",$_POST["textarea"]);
        foreach ($wordarray as $word)
        {
            if (strlen ($word) >= 4)
            {
                $first = $word[0];
                $last = $word[strlen($word)-1];

                $word[0] = $last;
                $word[strlen($word)-1] = $first;

                echo $word;
                echo "<br/>";
            }
            else
            {
                echo "$word <br>";
            }
        }
        ?>
    </body>
</html>