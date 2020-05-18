<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>sing guest book</title>
</head>

<body>
    <?php
    if (empty($_POST['first_name']) || empty($_POST['last_name'])) {
        echo "<p>You must enter your first and last name! Click your
    browser's Back button to return to the Guest Book form.</p>";
    } else {
        $DBConnect = mysqli_connect("127.0.0.1", "root", "");
        if ($DBConnect === FALSE) {
            echo "<p>Unable to connect to the database server.</p>"
                . "<p>Error code " . mysqli_connect_errno() . ": "
                . mysqli_connect_error() . "</p>";
        } else {
            $DBName = "guestbook";
            if (!mysqli_select_db($DBConnect, $DBName)) {
                $SQLstring = "CREATE DATABASE `" . $DBName . "`";
                if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                    $QueryResult = mysqli_stmt_execute($stmt);
                    if ($QueryResult === FALSE) {
                        echo "<p>Unable to create the database.</p>"
                            . "<p>Error code "
                            . mysqli_errno($DBConnect)
                            . ": " . mysqli_error($DBConnect)
                            . "</p>";
                    } else {
                        echo "<p>You are the first visitor!</p>";
                    }
                    //Clean up the $stmt after use
                    mysqli_stmt_close($stmt);
                }
            }
            mysqli_select_db($DBConnect, $DBName);
            $TableName = "visitors";
            $SQLstring = "SHOW TABLES LIKE '" . $TableName . "' ";
            if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                mysqli_stmt_execute($stmt);
                mysqli_stmt_store_result($stmt);
                if (mysqli_stmt_num_rows($stmt) == 0) {
                    //Clean up the $stmt after use
                    mysqli_stmt_close($stmt);
                    $SQLstring = "CREATE TABLE " . $TableName . "(countID
             SMALLINT NOT NULL AUTO_INCREMENT
             PRIMARY KEY, last_name VARCHAR(40),
             first_name VARCHAR(40))";
                    if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                        $QueryResult = mysqli_stmt_execute($stmt);
                        if ($QueryResult === FALSE) {
                            echo "<p>Unable to create the table.</p>"
                                . "<p>Error code "
                                . mysqli_errno($DBConnect)
                                . ": " . mysqli_error($DBConnect)
                                . "</p>";
                        }
                        //Clean up the $stmt after use
                        mysqli_stmt_close($stmt);
                    }
                }
            }
            $LastName = htmlentities($_POST['last_name']);
            $FirstName = htmlentities($_POST['first_name']);
            $SQLstring2 = "INSERT INTO " . $TableName . " VALUES(NULL, ?, ?)";
            if ($stmt = mysqli_prepare($DBConnect, $SQLstring2)) {
                mysqli_stmt_bind_param($stmt, 'ss', $LastName, $FirstName);
                $QueryResult2 = mysqli_stmt_execute($stmt);
                if ($QueryResult2 === FALSE) {
                    echo "<p>Unable to execute the query.</p>"
                        . "<p>Error code "
                        . mysqli_errno($DBConnect)
                        . ": "
                        . mysqli_error($DBConnect)
                        . "</p>";
                } else {
                    echo "<h1>Thank you for signing our guestbook!</h1>";
                }
                //Clean up the $stmt after use
                mysqli_stmt_close($stmt);
            }
            mysqli_close($DBConnect);
        }
    }
    ?>
</body>

</html>