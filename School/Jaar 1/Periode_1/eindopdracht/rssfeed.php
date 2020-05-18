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
                    <div class="col-12">
                        <h2>Tweakers rss-feed voor Gaming</h2>
                        <div class="rss-box">
                            <?php
                            $feed = "http://feeds.feedburner.com/tweakers/games";
                            $xml = simplexml_load_file($feed);
                            $xml2 = simplexml_load_file($feed);
                            foreach ($xml->channel->item as $item2) {
                                echo "<div class='filler'>"; // volledige blok

                                echo "<div class='kleur-fontSize'>" . $item2->title . "</div><br>";

                                echo "<div class='color'>" . $item2->description . "</div><br>";

                                echo "<div class='color2'>" . $item2->pubDate . "</div><br><br>";

                                echo "</div>"; //einde volledige blok
                            }
                            ?>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-3">
                <!--leeg-->
            </div>
        </div>
    </body>
</html>

