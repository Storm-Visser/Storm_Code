<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>

<body>


    <?php
    $id = $_GET["id"];
    //connect to database
    $DBConnect = mysqli_connect("127.0.0.1", "root", "");
    if ($DBConnect === FALSE) {
        die("There was an error connecting to the database. Error: " . mysqli_connect_errno());
    }

    //select the database
    $DBName = "bugrep";
    if (mysqli_select_db($DBConnect, $DBName)) {

        //create query
        $query1 = "SELECT bug_title, product_name, product_version, hardware_type, OS, frequency, sollution FROM bugs WHERE countID = ? ";

        //prepare statement
        if ($stmt = mysqli_prepare($DBConnect, $query1)) {

            //bind parameters
            mysqli_stmt_bind_param($stmt, 's', $id);

            //execute stmt && check succes
            if (mysqli_stmt_execute($stmt)) {
                echo "";
            } else {
                echo "Error executing query<br>";
                die(mysqli_error($DBConnect));
            }
            // Step #6.2: And buffer the result if and only if you want to check the number of rows
            mysqli_stmt_store_result($stmt);

            //check if there are results
            if (mysqli_stmt_num_rows($stmt) === 0) {
                echo "There are no bugs with this ID<br>" . $bugid;
                //die("error");
            }
            //bind result
            mysqli_stmt_bind_result($stmt, $bugtitle, $prodName, $prodVersion, $hardwareType, $OS, $freq, $soll);

            //echo results
            echo "<p> de oude informatie staat voor u ingevult </p>";
            echo '<form method="post" action="bug_edit_confirm.php?id=' . $id . '">';
            while (mysqli_stmt_fetch($stmt)) {
                echo '<p>new title<br><input type="text" name="bugtitle" value="' . $bugtitle . '"></p>';
                echo '<p>new product name<br><input type="text" name="name" value="' . $prodName . '"></p>';
                echo '<p>new product version<br><input type="text" name="version" value="' . $prodVersion . '"></p>';
                echo '<p>new hardware type<br><input type="text" name="hardware" value="' . $hardwareType . '"></p>';
                echo '<p>new operating system<br><input type="text" name="OS" value="' . $OS . '"></p>';
                echo '<p>new frequency<br><input type="text" name="frequency" value="' . $freq . '"></p>';
                echo '<p>new sollution (optional)<br><input type="text" name="sollution" value="' . $soll . '"></p>';
            }
            echo '<p><input type="submit" value="Edit"></p>';
            echo '</form>';
            echo "<br>";
            //close statement
            mysqli_stmt_close($stmt);
        } else {
            die(mysqli_error($DBConnect));
        }
        mysqli_close($DBConnect);
    }
    ?>
</body>

</html>