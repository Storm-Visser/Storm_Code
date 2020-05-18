<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>eindopdracht PHP</title>
        <link rel="stylesheet" href="styles/grid1.css">
    </head>
    <body>
        <div class="row header">
            <div class="col-1">
                <!--leeg-->
            </div>
            <div class="col-2 link">
                <a href="weer.php">Weer</a>
            </div>
            <div class="col-1">
                <!--leeg-->
            </div>
            <div class="col-2 link">
                <a href="rssfeed.php">RSS-feed</a>
            </div>
            <div class="col-1">
                <!--leeg-->
            </div>
            <div class="col-2 link">
                <a href="info.php">Stijl</a>
            </div>
            <div class="col-1">
                <!--leeg-->
            </div>
            <div class="col-1 link">
                <a href="home.php">Home</a>
            </div>
            <div class="col-1">
                <!--leeg-->
            </div>
        </div>

        <div class="row content">
            <div class="col-3">
                <!--leeg-->
            </div>
            <div class="col-6 tekst">
                <div class="row">
                    <div class="col-12 groot">
                        <h2>Geef een woord een stijl.</h2>
                        <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
                            Woord:<input type="text" class="groot" name="naam"> <br>

                            <select class="groot" name="RGB">
                                <option value="red" >rood</option>
                                <option value="blue">blauw</option>
                                <option value="green">groen</option>
                            </select><br>

                            <input class="groot" type="radio" name="groot" value="xl">Groot<br>
                            <input class="groot" type="radio" name="groot" value="xs" checked="checked">klein<br>
                            <input class="groot" type="checkbox" name="zien[]" value="toepassen">Toepassen?<br>
                            <input class="groot" type="checkbox" name="zien[]" value="niet toepassen">niet toepassen<br>
                            <input class="groot" type="checkbox" name="zien[]" value="iets anders">overig?<br>
                            <input class="groot" type="submit" name="submit">
                        </form>
                        <?php
                        //=============================eind form===========================================================
                        if (empty($_POST["naam"])) {//check naam ingevult
                            echo"woord is verplicht";
                        } else {
                            
                            $naam = $_POST["naam"];
                            $groot = $_POST["groot"];
                            if (isset($_POST["zien"])) {//checked of je wil zien
                                $checkbox = $_POST["zien"];
                                foreach ($checkbox as $check){
                                    echo $check ."<br>";
                                }
                                if ($groot === "xl") {//checked groote
                                    if ($_POST["RGB"] === "red") {//checked kleur
                                        echo "<p style='color:red;font-size:100px;'>" . $naam;
                                    } elseif ($_POST["RGB"] === "blue") {//checked kleur
                                        echo "<p style='color:blue;font-size:100px;'>" . $naam;
                                    } elseif ($_POST["RGB"] === "green") {//checked kleur
                                        echo "<p style='color:green;font-size:100px;'>" . $naam;
                                    }
                                } else {//checked groote
                                    if ($_POST["RGB"] === "red") {//checked kleur
                                        echo "<p style='color:red;font-size:20px;'>" . $naam;
                                    } elseif ($_POST["RGB"] === "blue") {//checked kleur
                                        echo "<p style='color:blue;font-size:20px;'>" . $naam;
                                    } elseif ($_POST["RGB"] === "green") {//checked kleur
                                        echo "<p style='color:green;font-size:20px;'>" . $naam;
                                    }
                                }
                            } else {
                                echo $naam;
                            }
                        }
                        ?>
                    </div>
                </div>
            </div>
            <div class="col-3">
                <!--leeg-->
            </div>
        </div>
    </body>
</html>