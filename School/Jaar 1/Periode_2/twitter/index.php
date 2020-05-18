<?php
// Start the session
session_start();
?>
<!DOCTYPE html>
<html>

<head>
    <link href="twitter.css" type="text/css" rel="stylesheet">
    <link href="bootstrap.css" type="text/css" rel="stylesheet">
    <meta charset="UTF-8">
    <title>twitter</title>
</head>

<body>
    <div class="container-fluid">
        <div class="row">
            <div class="col-2 menu">
                <img src="img/download.jpg" class="logo">
                <ul>
                    <li><a href="index.php">home</a></li>
                    <li><a href="message.php">nieuw bericht</a></li>
                    <li><a href="login.php">log in</a></li>
                    <li><a href="logout.php">log uit</a></li>
                    <li><a href="signup.php">maak account</a></li>
                </ul>
            </div>
            <div class="col-7 main">
                <?php
                $DBConnect = mysqli_connect("127.0.0.1", "root", "");
                if ($DBConnect === FALSE) {
                    echo "Unable to connect to the database server<br>";
                } else {
                    $DBName = "twitter";
                    $TableName = "messages";
                    mysqli_select_db($DBConnect, $DBName);
                    $SQLstring1 = "SELECT message, userName, userImage FROM " . $TableName . " JOIN users ON messages.userId = users.userId";
                    if ($stmt = mysqli_prepare($DBConnect, $SQLstring1)) {
                        //check if execute succeeds
                        mysqli_stmt_execute($stmt);
                        
                        mysqli_stmt_bind_result($stmt, $mess, $uname, $img);
                        mysqli_stmt_store_result($stmt);
                        if (mysqli_stmt_num_rows($stmt) == 0) {
                            echo "There are no messages<br>";
                        } else {
                            while (mysqli_stmt_fetch($stmt)) {
                                echo "<table class='message'>";
                                echo "<tr><th><p class='title'><img src='img/" . $img . "' class='msgimg'> " . $uname . "</p></th></tr>";
                                echo "<tr><td>" . $mess . "</td></tr>";
                                echo "</table>";
                            }
                        }
                        mysqli_stmt_close($stmt);
                    } else {
                        echo mysqli_error($DBConnect);
                    }
                    mysqli_close($DBConnect);
                }

                ?>
            </div>
            <div class="col-2 profiel">
                <?php
                    if(isset($_SESSION['loggedin'])){
                        echo'<img src="' . $_SESSION['img'] . '" class="logo">';
                        echo'<p class="title">' . $_SESSION['uname'] . '</p>';
                    }else{
                        echo"<p class='title'>guest</p>";
                    }
                ?>
            </div>
        </div>
    </div>
</body>

</html>