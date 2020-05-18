<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>bug reporter</title>
</head>

<body>
    <?php
    $DBConnect = mysqli_connect("127.0.0.1", "root", "");
    if ($DBConnect === FALSE) {
        echo "Unable to connect to the database server<br>";
    } else {
        $DBName = "bugrep";
        if (!mysqli_select_db($DBConnect, $DBName)) {
            echo "there are no reported bugs<br>";
        } else {
            $TableName = "bugs";
            $SQLstring = "SELECT countID, bug_title, product_name, product_version, hardware_type, OS, frequency, sollution FROM " . $TableName;
            if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                mysqli_stmt_execute($stmt);
                mysqli_stmt_bind_result($stmt,$ID, $bugtitle, $prodName, $prodVersion, $hardwareType, $OS, $freq, $soll);
                mysqli_stmt_store_result($stmt);
                if (mysqli_stmt_num_rows($stmt) == 0) {
                    echo "There are no entries<br>";
                } else {
                    echo "<h1>The following bugs are reported</h1>";
                    echo "<table width='100%' border='1'>";
                    echo "<tr><th>ID</th>";
                    echo "<th>bug title</th>";
                    echo "<th>product name</th>";
                    echo "<th>product version</th>";
                    echo "<th>hardware type</th>";
                    echo "<th>operating system</th>";
                    echo "<th>frequency</th>";
                    echo "<th>sollution</th>";
                    while (mysqli_stmt_fetch($stmt)) {
                        echo "<tr><td><a href='updatebug.php?id=" . $ID . "'>".$ID."</a></td>";
                        echo "<td>" . $bugtitle . "</td>";
                        echo "<td>" . $prodName . "</td>";
                        echo "<td>" . $prodVersion . "</td>";
                        echo "<td>" . $hardwareType . "</td>";
                        echo "<td>" . $OS . "</td>";
                        echo "<td>" . $freq . "</td>";
                        echo "<td>" . $soll . "</td>";
                    }
                    echo "</table>";
                }
                mysqli_stmt_close($stmt);
            }
            mysqli_close($DBConnect);
        }
    }
  
    ?>
    <a href="bug_rep_form.php">report a bug</a>
</body>

</html>