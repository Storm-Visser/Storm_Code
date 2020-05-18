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
                    <div class="col-8">
                        <h1>wie ben ik</h1>
                        <p>Ik ben Storm, ik ben 16 jaar oud en ik woon in nieuw amsterdam. ik zit op school in emmen op het nhlstenden en studeer informatica.
                            voordat ik hier op school zat deed ik havo op het hondsrugcollege, en daarvoor zat ik op de basisschool de Bascule. ik werk nu al iets
                            meer dan een jaar bij de coop Hebels en ik moet daar vakkenvullen en spiegelen.</p> 
                        <h1>hobby's</h1>
                        <p>
                            <?php
                            echo "mijn hobby's zijn; ";
                            $hobbys = ["Volleybal", "Gamen", "Hiken"];
                            for ($x = 0; $x <= 2; $x++) {
                                echo $hobbys[$x] . ", ";
                            }
                            ?>
                            de games die ik speel zijn; overwatch, tomb raider en minecraft.
                            ik zit nu al 8 jaar op volleybal en vind het nogsteeds erg leuk, ik speel bij EnBlock en trian om de vrijdag bij de 
                            trz(talent regio zwolle). verder vind ik hiken erg leuk, hiken is een soort van extreeme vorm van wandelen waar je
                            een langere wandeling maakt met eventueel een overnachting op de wandeling dus in een tentje of in een trekkershut.
                        </p>
                    </div>
                    <div class="col-4">
                        <video autoplay muted loop id="vid">
                            <source src="styles/media/storm.mp4" type="video/mp4">
                        </video>                      
                    </div>
                </div>
            </div>
            <div class="col-3">
                <!--leeg-->
            </div>
        </div>
    </body>
</html>
