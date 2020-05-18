<!DOCTYPE html>

<html lang="en">

    <head>

        <meta charset="UTF-8" />

        <title>Uploadform</title>

    </head>

    <body>

        <div id="container">

            <form enctype= "multipart/form-data" method="post">

                <p><input type="submit" name="submit" value="Submit" /></p>

                <p><input type="file" name="file"/> </p>

            </form>

        </div>      
        <?php
            if(isset($_POST["submit"]))
            {
                echo "de naam van de file is: ";
                echo $_FILES["file"]["name"];
                echo "<br>";
                echo "de locatie van de file is: ";
                echo $_FILES["file"]["tmp_name"];
                echo "<br>";
                echo "de groote van de file is: ";
                echo $_FILES["file"]["size"] . "  bytes";
                echo "<br>";
                echo "het type van de file is: ";
                echo $_FILES["file"]["type"];
            }
        ?>
    </body>

</html>