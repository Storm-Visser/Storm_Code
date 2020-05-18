<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>opdracht 1</title>
    </head>
    <body>
        <?php
        // Opgave L1
        // Gegeven een verzameling woorden: [appel, peer, banaan, kiwi, mango]    
        // Maak een PHP functie die:
        // Alle elementen netjes weergeeft met een foreach en while loop;
        //         Alle elementen in omgekeerde volgorde weergeeft;
        //         Alle elementen zo print dat ze allemaal een hoofdletter als eerste karakter hebben (dus: Appel, Peer, Banaan, Kiwi, Mango).// Maak een PHP functie die kan aantonen of een gegeven woord in de gegeven verzameling voorkomt met een optie om hoofdlettergevoelig te zoeken.
        $list = array("appel", "peer", "banaan", "kiwi", "mango");
        $i = 4;
        foreach($list as $fruit)
        {
            echo $list[$i];
            echo "<br>";
            $i--;
        }
        echo "<br>";
        $i2 = 4;
        while($i2 >= 0)
        {
            echo $list[$i2];
            echo "<br>";
            $i2--;
        }
        echo "<br>";
        foreach($list as $fruit)
        {
            echo ucfirst($fruit);
            echo "<br>";
        }
        echo "<br>";
        $i3 = 4;
        while($i3 >= 0)
        {
            echo ucfirst($list[$i3]);
            echo "<br>";
            $i3--;
        }
        ?>
    </body>
</html>