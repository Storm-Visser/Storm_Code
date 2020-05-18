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
                <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post" enctype="multipart/form-data">
                    <p>username<br><input type="text" name="username"></p>
                    <p>e-mail<br><input type="text" name="mail"></p>
                    <p>password<br><input type="password" name="pass1"></p>
                    <p>kies uw plaatje:<input type="file" name="image"></p>
                    <p><input type="submit" name="submit" value="Submit"></p>
                </form>
                <?php
                if (isset($_POST['submit'])) {
                    if (empty($_POST['username']) || empty($_POST['mail']) || empty($_POST['pass1'])) {
                        echo "enter all fields";
                    } else {

                        //check user bestaat----------------------------------------------------------------------------------------
                        //1.  connect to the database           x
                        $DBConnect = mysqli_connect("127.0.0.1", "root", "");
                        if ($DBConnect == FALSE) {
                            echo "Unable to connect to the database server";
                        } else {
                            $DBName = "twitter";
                            $TableName = "users";
                            $selectedname = ($_POST['username']);
                            $mail = ($_POST['mail']);
                            $pass = ($_POST['pass1']);
                            $passhash = password_hash($pass, PASSWORD_DEFAULT);
                            //2.  select a database
                            mysqli_select_db($DBConnect, $DBName);
                            //3.  create a query
                            $SQLstring = "SELECT userName FROM " . $TableName . " WHERE userName = ?";
                            //4.  prepare statement if necessary
                            if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                                mysqli_stmt_bind_param($stmt, "s", $selectedname);
                                //6.  execute statement
                                $QueryResult = mysqli_stmt_execute($stmt);
                                mysqli_stmt_bind_result($stmt, $uname);
                                mysqli_stmt_store_result($stmt);
                                //7.  check succes
                                if ($QueryResult == FALSE) {
                                    echo "query failed 1";
                                    die();
                                }
                                if (!mysqli_stmt_num_rows($stmt) == 0) {
                                    echo 'this username already exist';
                                    die();
                                }

                                mysqli_stmt_close($stmt);
                            } else {
                                echo mysqli_error($DBConnect);
                                die();
                            }
                            //file check upload---------------------------------------------------------------------------------
                            $allow = array("image/jpeg", "image/png", "image/bmp", "image/gif");
                            $todir = "img/";

                            if (isset($_FILES['image']['tmp_name'])) {
                                $info = $_FILES['image']['type'];
                                if (in_array($info, $allow)) {
                                    if (filesize($_FILES["image"]) < 200000){
                                        if (!move_uploaded_file($_FILES['image']['tmp_name'], $todir . basename($_FILES['image']['name']))) {
                                            echo 'plaatje niet geupload';
                                            die;
                                        }
                                    } else {
                                        echo "het plaatje is te groot";
                                        die();
                                    }
                                } else {
                                echo 'dit is geen plaatje';
                                die();
                                }
                            }
                            //sla de locatie op
                            $location = basename($_FILES['image']['name']);
                            //in de database gooien================================================================================
                            //3. create statement
                            $SQLstring1 = "INSERT INTO " . $TableName . " VALUES(NULL, ?, ?, ?, ?)";
                            //4.  prepare statement if necessary
                            if ($stmt = mysqli_prepare($DBConnect, $SQLstring1)) {
                                //5.  bind parameters if necessary
                                mysqli_stmt_bind_param($stmt, 'ssss', $selectedname, $passhash, $mail, $location);
                                //6.  execute statement
                                $QueryResult1 = mysqli_stmt_execute($stmt);
                                //7.  check succes
                                if ($QueryResult1 == FALSE) {
                                    echo "query failed 2";
                                } else {
                                    echo "<a href='login.php'>Log in</a>";
                                }
                                //11. close statement
                                mysqli_stmt_close($stmt);
                            } else {
                                echo mysqli_error($DBConnect);
                            }
                        }
                        //12. close database connection
                        mysqli_close($DBConnect);
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