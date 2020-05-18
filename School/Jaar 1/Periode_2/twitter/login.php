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
                <p class="title">Voer hier uw inloggegevens in</p>
                <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="POST">
                    <!--de form-->
                    <p>Gebruikersnaam:</p>
                    <input type="text" name="name"><br><br>
                    <p>Wachtwoord:</p>
                    <input type="password" name="pass"><br><br>
                    <input type="submit" name="submit" value="Log in">
                </form>
                <?php
                if (isset($_POST["submit"])) {
                    if (!empty($_POST["pass"]) || !empty($_POST["name"])) {
                        $DBConnect = mysqli_connect("127.0.0.1", "root", "");
                        if ($DBConnect === FALSE) {
                            echo "Unable to connect to the database server<br>";
                        } else {
                            $DBName = "twitter";
                            $TableName = "users";
                            $passin = $_POST['pass'];
                            $namein = $_POST['name'];
                            mysqli_select_db($DBConnect, $DBName);
                            $SQLstring1 = "SELECT userId, userName, userPass, userMail, userImage FROM " . $TableName . " WHERE `userName` = ? ";
                            if ($stmt = mysqli_prepare($DBConnect, $SQLstring1)) {
                                mysqli_stmt_bind_param($stmt, "s", $namein);
                                mysqli_stmt_execute($stmt);//valideren
                                mysqli_stmt_bind_result($stmt, $userId, $uname, $pass, $mail, $img);
                                while (mysqli_stmt_fetch($stmt)) {
                                    if (password_verify($passin, $pass) && $namein == $uname) {
                                        echo "<p class='title'>succesvol ingelogd</p>";
                                        //session
                                        $_SESSION['uid'] = $userId;
                                        $_SESSION['uname'] = $uname;
                                        $_SESSION['mail'] = $mail;
                                        $_SESSION['img'] = 'img/' . $img;
                                        $_SESSION['loggedin'] = TRUE;
                                    }
                                    else{
                                        echo "incorrect username or password";
                                    }
                                }
                                mysqli_stmt_close($stmt);
                            } else {
                                echo mysqli_error($DBConnect);
                            }
                            mysqli_close($DBConnect);
                        }
                    }else{
                        echo 'vull de velden in';
                    }
                }
                //haal alles op
                //check of gelijk
                //zo ja start session

                //1.  connect to the database
                //2.  select a database
                //3.  create a query
                //4.  prepare statement if necessary
                //5.  bind parameters if necessary
                //6.  execute statement
                //7.  check succes
                //8.  buffer result if necessary
                //9.  check result if necessary
                //10. use results if necessary
                //11. close statement
                //12. close database connection
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