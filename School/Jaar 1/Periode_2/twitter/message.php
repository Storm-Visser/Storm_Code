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
                //check of ingelogd
                if (isset($_SESSION['loggedin'])) {
                    echo '<form action="' . $_SERVER['PHP_SELF'] . '" method="POST">
                        <p class="title">voer hier u bericht in:</p>
                        <input type="textarea" class="txtmsg" name="msg"><br><br>
                        <input type="submit" name="submit" value="stuur bericht">
                        </form>';
                } else {
                    echo "<p class='title'>please log in to send a message</p>";
                }
                //nu de form verwerken
                if (isset($_POST["submit"])) {
                    if (!empty($_POST["msg"])) {
                        //1.  connect to the database
                        $DBConnect = mysqli_connect("127.0.0.1", "root", "");
                        if ($DBConnect === FALSE) {
                            echo "Unable to connect to the database server<br>";
                        } else {
                            $DBName = "twitter";
                            $TableName = "messages";
                            $msg = htmlentities($_POST['msg']);
                            $usrid = $_SESSION['uid'];
                            //2.  select a database
                            mysqli_select_db($DBConnect, $DBName);
                            //3.  create a query
                            $SQLstring1 = "INSERT INTO " . $TableName . " VALUES(NULL, ?, ?)";
                            //4.  prepare statement if necessary
                            if ($stmt = mysqli_prepare($DBConnect, $SQLstring1)) {
                                //5.  bind parameters if necessary
                                mysqli_stmt_bind_param($stmt, 'ss', $usrid, $msg);
                                //6.  execute statement
                                $QueryResult1 = mysqli_stmt_execute($stmt);
                                //7.  check succes
                                if ($QueryResult1 == FALSE) {
                                    echo "query failed";
                                } else {
                                    echo "<a href='index.php'>Home</a>";
                                }
                                //11. close statement
                                mysqli_stmt_close($stmt);
                            } else {
                                echo mysqli_error($DBConnect);
                            }
                            //12. close database connection
                            mysqli_close($DBConnect);
                        }
                    }
                }
                ?>
            </div>
            <div class="col-2 profiel">
                <?php
                if (isset($_SESSION['loggedin'])) {
                    echo '<img src="' . $_SESSION['img'] . '" class="logo">';
                    echo '<p class="title">' . $_SESSION['uname'] . '</p>';
                } else {
                    echo "<p class='title'>guest</p>";
                }
                ?>
            </div>
        </div>
    </div>
</body>

</html>
<?php
//11. close statement
//12. close database connection
?>