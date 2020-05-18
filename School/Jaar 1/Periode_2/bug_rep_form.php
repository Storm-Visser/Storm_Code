<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>report a bug</title>
</head>

<body>
    <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
        <p>title<br><input type="text" name="bugtitle"></p>
        <p>product name<br><input type="text" name="name"></p>
        <p>product version<br><input type="text" name="version"></p>
        <p>hardware type<br><input type="text" name="hardware"></p>
        <p>operating system<br><input type="text" name="OS"></p>
        <p>frequency<br><input type="text" name="frequency"></p>
        <p>sollution (optional)<br><input type="text" name="sollution"></p>
        <p><input type="submit" value="Submit"></p>
    </form>
    <?php
        if (empty($_POST['bugtitle']) || empty($_POST['name']) || empty($_POST['version']) || empty($_POST['hardware']) || empty($_POST['OS']) || empty($_POST['frequency'])) {
            echo "enter all fields";
        } else {
            $DBConnect = mysqli_connect("127.0.0.1", "root", "");
            if ($DBConnect == FALSE) {
                echo "Unable to connect to the database server";
            } else {
                $DBName = "bugrep";
                if (!mysqli_select_db($DBConnect, $DBName)) {
                    $SQLstring = "CREATE DATABASE `" . $DBName . "`";
                    if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                        $QueryResult = mysqli_stmt_execute($stmt);
                        if ($QueryResult === FALSE) {
                            echo "Unable to create the database<br>";
                        } else {
                            echo "You are the first to report a bug<br>";
                        }
                        mysqli_stmt_close($stmt);
                    }
                }
                mysqli_select_db($DBConnect, $DBName);
                $TableName = "bugs";
                $SQLstring = "SHOW TABLES LIKE '" . $TableName . "' ";
                if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                    mysqli_stmt_execute($stmt);
                    mysqli_stmt_store_result($stmt);
                    if (mysqli_stmt_num_rows($stmt) == 0) {
                        mysqli_stmt_close($stmt);
                        $SQLstring = "CREATE TABLE " . $TableName . "(countID
        SMALLINT NOT NULL AUTO_INCREMENT
        PRIMARY KEY, bug_title VARCHAR(40),
        product_name VARCHAR(40),
        product_version VARCHAR(40),
        hardware_type VARCHAR(40),
        OS VARCHAR(40),
        frequency VARCHAR(40),
        sollution VARCHAR(100))";
                        if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                            $QueryResult = mysqli_stmt_execute($stmt);
                            if ($QueryResult === FALSE) {
                                echo "Unable to create the table";
                            } else {
                                echo "table created";
                            }
                            mysqli_stmt_close($stmt);
                        }
                    }
                }
                $bugID = htmlentities($_POST['bugtitle']);
                $prodName = htmlentities($_POST['name']);
                $prodVersion = htmlentities($_POST['version']);
                $HardwareType = htmlentities($_POST['hardware']);
                $OS = htmlentities($_POST['OS']);
                $freq = htmlentities($_POST['frequency']);
                $soll = htmlentities($_POST['sollution']);

                $SQLstring2 = "INSERT INTO " . $TableName . " VALUES(NULL, ?, ?, ?, ?, ?, ?, ?)";
                if ($stmt = mysqli_prepare($DBConnect, $SQLstring2)) {
                    mysqli_stmt_bind_param($stmt, 'sssssss', $bugID, $prodName, $prodVersion, $HardwareType, $OS, $freq, $soll);
                    $QueryResult2 = mysqli_stmt_execute($stmt);
                    if ($QueryResult2 === FALSE) {
                        echo "query failed";
                    } else {
                        echo "<h1>Thank you for reportig a bug</h1>";
                    }
                    mysqli_stmt_close($stmt);
                }
                mysqli_close($DBConnect);
            }
        }
    ?>
    <a href="bug_rep.php">home</a>
</body>

</html>