<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title></title>
</head>

<body>
    <?php
    $DBConnect = mysqli_connect("127.0.0.1", "root", "");
    if ($DBConnect === FALSE) {
        echo "Unable to connect to the database server<br>";
    } else {
        $DBName = "airline";
        if (!mysqli_select_db($DBConnect, $DBName)) {
            echo "there are no reports<br>";
        } else {
            $TableName = "revieuws";
            $SQLstring = "SELECT friend, space, comfort, clean, noice FROM " . $TableName;
            if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                mysqli_stmt_execute($stmt);
                mysqli_stmt_bind_result($stmt, $friend, $space, $comfort, $clean, $noice);
                mysqli_stmt_store_result($stmt);
                if (mysqli_stmt_num_rows($stmt) == 0) {
                    echo "There are no entries<br>";
                } else {
                    echo "<h1>Revieuws</h1>";
                    echo "<table width='100%' border='1'>";
                    echo "<tr><th>friendliness</th>";
                    echo "<th>space</th>";
                    echo "<th>comfort</th>";
                    echo "<th>cleanliness</th>";
                    echo "<th>noice level</th></tr>";
                    while (mysqli_stmt_fetch($stmt)) {
                        echo "<tr><td>" . $friend . "</td>";
                        echo "<td>" . $space . "</td>";
                        echo "<td>" . $comfort . "</td>";
                        echo "<td>" . $clean . "</td>";
                        echo "<td>" . $noice . "</td></tr>";
                    }
                    echo "</table>";
                }
                mysqli_stmt_close($stmt);
            }
            mysqli_close($DBConnect);
        }
    }
    ?>
    <a href="airline_rep.php">give a revieuw</a>
</body>

</html>