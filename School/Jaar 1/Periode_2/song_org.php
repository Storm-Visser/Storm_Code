<!DOCTYPE html>

<html>
    <head>
        <meta charset="UTF-8">
        <title>Song Organizer</title>
    </head>
    <body>
        <h1>Song Organizer</h1>
        <?php
        //form van volgorde keuze
        if (isset($_GET['action'])) {
            if ((file_exists("SongOrganizer/songs.txt")) &&
                    (filesize("SongOrganizer/songs.txt") != 0)) {
                $SongArray = file("SongOrganizer/songs.txt");
                switch ($_GET['action']) {
                    case 'Remove Duplicates':
                        $SongArray = array_unique($SongArray);
                        $SongArray = array_values($SongArray);
                        break;
                    case 'Sort Ascending':
                        sort($SongArray);
                        break;
                    case 'Shuffle':
                        shuffle($SongArray);
                        break;
                    case 'Sort Descending':
                        rsort($SongArray);
                        break;
                    case 'remove first':
                        $SongArray = array_slice($SongArray, 1);
                        break;
                    case 'remove last':
                        $SongArray = array_slice($SongArray, 0, -1);
                        break;
                } // End of the volgorde keuze
                    if (count($SongArray) > 0) {
                    $NewSongs = implode($SongArray);
                    $SongStore = fopen("SongOrganizer/songs.txt", "wb");
                    if ($SongStore === false) {
                        echo "There was an error updating the song file\n";
                    } else {
                        fwrite($SongStore, $NewSongs);
                        fclose($SongStore);
                    }
                } else {
                    unlink("SongOrganizer/songs.txt");
                }
            }
        }
        if (isset($_POST['submit'])) {
            if (!empty($_POST['SongName']) || !empty($_POST['Artist'])) {
                $SongToAdd = stripslashes($_POST['SongName']);
                $ArtistToAdd = stripslashes($_POST['Artist']) . "\n";
                $ToAdd = $SongToAdd . "-" . $ArtistToAdd;
                $ExistingSongs = array();
                if (file_exists("SongOrganizer/songs.txt") &&
                        filesize("SongOrganizer/songs.txt") > 0) {
                    $ExistingSongs = file("SongOrganizer/songs.txt");
                }
                if (in_array($ToAdd, $ExistingSongs)) {
                    echo "<p>The song you entered already exists!<br>\n";
                    echo "Your song was not added to the list.</p>";
                } else {
                    $SongFile = fopen("SongOrganizer/songs.txt", "ab");
                    if ($SongFile === false) {
                        echo "There was an error saving your message!\n";
                    } else {
                        fwrite($SongFile, $ToAdd);
                        fclose($SongFile);
                        echo "Your song has been added to the list.\n";
                    }
                }
            } else {
                echo"Please enter a name first";
            }
        }
        if ((!file_exists("SongOrganizer/songs.txt")) ||
                (filesize("SongOrganizer/songs.txt") == 0)) {
            echo "<p>There are no songs in the list.</p>\n";
        } else {
            $SongArray = file("SongOrganizer/songs.txt");
            echo "<table border=\"1\" width=\"50%\"
                         style=\"background-color:lightgray\">\n";
            echo "<tr>\n";
            echo "<th>Song</th> ";
            echo "<th>Artist</th> ";
            echo "</tr>\n";
            foreach ($SongArray as $Song) {
                $songartistarr = explode("-", $Song);
                echo "<tr>\n";
                echo "<td>" . $songartistarr[0] . "</td>";
                echo "<td>" . $songartistarr[1] . "</td>";
                echo "</tr>\n";
            }
            echo "</table>\n";
        }
        $str = "Hello world. It's a beautiful day.";
        ?>
        <p>
            <a href="song_org.php?action=Sort%20Ascending">
                Sort Song List Ascending</a><br>
            <a href="song_org.php?action=Sort%20Descending">
                Sort Song List Descending</a><br>
            <a href="song_org.php?action=Remove%20Duplicates">
                Remove Duplicate Songs</a><br>
            <a href="song_org.php?action=Shuffle">
                Randomize Song list</a><br>
            <a href="song_org.php?action=remove%20first">
                Remove First Song</a><br>
            <a href="song_org.php?action=remove%20last">
                Remove Last Song</a><br>
        </p>
        <form action="song_org.php" method="post">
            <p><b>Add a New Song</b></p>
            <p>Song Name: <input type="text" name="SongName"/></p>
            <p>Artist: <input type="text" name="Artist"/></p>
            <p>
                <input type="submit" name="submit"
                       value="Add Song to List" />
                <input type="reset" name="reset"
                       value="Reset Song Name" />
            </p>
        </form>
    </body>
</html>
