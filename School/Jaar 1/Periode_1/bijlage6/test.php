<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
    </head>
    <body>
        <form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
            <input type="date" name="datum">voer een datum in<br>
            <input type="submit" value="submit">
        </form>
        <?php
        if (empty($_POST['datum'])) {
            echo "voer een datum in";
        } else {
            $datum = $_POST['datum'];
            // jjjj-mm-dd
            
            //met substring
            
            $dag = substr($datum, 8, 2);
            $maand = substr($datum, 5, 2);
            $jaar = substr($datum, 0, 4);
            echo "dag " . $dag;
            echo "<br>maand " . $maand;
            echo "<br>jaar " . $jaar;
            
            //met array
            
            $datumarray = explode("-", $datum);
            $jaar = $datumarray[0];
            $maand = $datumarray[1];
            $dag = $datumarray[2];
            echo "<br>dag " . $dag;
            echo "<br>maand " . $maand;
            echo "<br>jaar " . $jaar;
        }
        ?>
    </body>
</html>