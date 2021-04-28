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
                    <?php
                    /*
                      113 Sunny
                      116 Partly cloudy
                      119 Cloudy
                      122 Overcast
                      143 Mist
                      176 Patchy rain possible
                      179 Patchy snow possiblE
                      182 Patchy sleet possible
                      185 Patchy freezing drizzle possible
                      200 Thundery outbreaks possible
                      227 Blowing snow
                      230 Blizzard
                      248 Fog
                      260 Freezing fog
                      263 Patchy light drizzle
                      266 Light drizzle
                      281 Freezing drizzle
                      284 Heavy freezing drizzle
                      296 Light rain
                      299 Moderate rain at times
                      302 Moderate rain
                      305 Heavy rain at times
                      308 Heavy rain
                      311 Light freezing rain
                     */

                    //krijg een weatherstring
                    function getWeatherStringEmmen() {
                        $tempLocation = "3℃";
                        $tempText = "weer";
                        $tempCode = 122;
                        $location = "Emmen";

                        return $location . " " . $tempLocation . " " . $tempCode . " " . $tempText;
                    }

                    //sla alles individueel op
                    $weatherinfo = getWeatherStringEmmen();
                    $weerarray = explode(" ", $weatherinfo);
                    $locatie = $weerarray[0];
                    $temperatuur = $weerarray[1];
                    $code = $weerarray[2];
                    $text = "";

                    for ($i = 3; $i < count($weerarray); $i++) {
                        $max = 5;
                        if ($i < $max + 3) {
                            $text = $text . " " . $weerarray[$i];
                        }
                    }


                    if ($code == 113) {
                        echo'<div class="col-12 img sunny"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 116) {
                        echo'<div class="col-12 img Partlycloudy"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 119) {
                        echo'<div class="col-12 img Cloudy"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 122) {
                        echo'<div class="col-12 img Overcast"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 143) {
                        echo'<div class="col-12 img Mist"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 176) {
                        echo'<div class="col-12 img Patchyrainpossible"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 179) {
                        echo'<div class="col-12 img Patchysnowpossible"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 182) {
                        echo'<div class="col-12 img Patchysleetpossible"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 185) {
                        echo'<div class="col-12 img Patchyfreezingdrizzlepossible"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 200) {
                        echo'<div class="col-12 img Thunderyoutbreakspossible"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 227) {
                        echo'<div class="col-12 img Blowingsnow"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 230) {
                        echo'<div class="col-12 img Blizzard"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 248) {
                        echo'<div class="col-12 img Fog"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 260) {
                        echo'<div class="col-12 img Freezingfog"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 263) {
                        echo'<div class="col-12 img Patchylightdrizzle"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 266) {
                        echo'<div class="col-12 img Lightdrizzle"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 281) {
                        echo'<div class="col-12 img Freezingdrizzle"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 284) {
                        echo'<div class="col-12 img Heavyfreezingdrizzle"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 293) {
                        echo'<div class="col-12 img Patchylightrain"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 296) {
                        echo'<div class="col-12 img Lightrain"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 299) {
                        echo'<div class="col-12 img Moderaterainattimes"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 302) {
                        echo'<div class="col-12 img Moderaterain"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 305) {
                        echo'<div class="col-12 img Heavyrainattimes"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 308) {
                        echo'<div class="col-12 img Heavyrain"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } elseif ($code == 311) {
                        echo'<div class="col-12 img Lightfreezingrain"><h1>' . $text . '</h1></div>';
                        echo "temperatuur:&nbsp$temperatuur";
                    } else {
                        echo "foute weercode";
                    }
                    ?>
                </div>
            </div>
            <div class="col-3">
                <!--leeg-->
            </div>
        </div>
    </body>
</html>

