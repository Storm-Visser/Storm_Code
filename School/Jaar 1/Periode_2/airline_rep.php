<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>sing guest book</title>
</head>

<body>
    <form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
        <p>friendliness<br>
            <input type="radio" name="friendliness" value="exellent">exellent<br>
            <input type="radio" name="friendliness" value="good">good<br>
            <input type="radio" name="friendliness" value="fair">fair<br>
            <input type="radio" name="friendliness" value="poor">poor<br>
            <input type="radio" name="friendliness" value="no opinion" checked="checked">no opinion<br>
        </p>
        <p>space<br>
            <input type="radio" name="space" value="exellent">exellent<br>
            <input type="radio" name="space" value="good">good<br>
            <input type="radio" name="space" value="fair">fair<br>
            <input type="radio" name="space" value="poor">poor<br>
            <input type="radio" name="space" value="no opinion" checked="checked">no opinion<br>
        </p>
        <p>comfort<br>
            <input type="radio" name="comfort" value="exellent">exellent<br>
            <input type="radio" name="comfort" value="good">good<br>
            <input type="radio" name="comfort" value="fair">fair<br>
            <input type="radio" name="comfort" value="poor">poor<br>
            <input type="radio" name="comfort" value="no opinion" checked="checked">no opinion<br>
        </p>
        <p>cleanliness<br>
            <input type="radio" name="cleanliness" value="exellent">exellent<br>
            <input type="radio" name="cleanliness" value="good">good<br>
            <input type="radio" name="cleanliness" value="fair">fair<br>
            <input type="radio" name="cleanliness" value="poor">poor<br>
            <input type="radio" name="cleanliness" value="no opinion" checked="checked">no opinion<br>
        </p>
        <p>noice<br>
            <input type="radio" name="noice" value="exellent">exellent<br>
            <input type="radio" name="noice" value="good">good<br>
            <input type="radio" name="noice" value="fair">fair<br>
            <input type="radio" name="noice" value="poor">poor<br>
            <input type="radio" name="noice" value="no opinion" checked="checked">no opinion<br>
        </p>
        <p><input type="submit" value="Submit"></p>
    </form>
    <?php
    if (!empty($_POST)) {
        $DBConnect = mysqli_connect("127.0.0.1", "root", "");
        if ($DBConnect === FALSE) {
            echo "Unable to connect to the database server";
        } else {
            $DBName = "airline";
            mysqli_select_db($DBConnect, $DBName);
            $TableName = "revieuws";
            $friend = $_POST["friendliness"];
            $space = $_POST["space"];
            $comfort = $_POST["comfort"];
            $clean = $_POST["cleanliness"];
            $noice = $_POST["noice"];
            $SQLstring2 = "INSERT INTO " . $TableName . " VALUES(NULL, ?, ?, ?, ?, ?)";
            if ($stmt = mysqli_prepare($DBConnect, $SQLstring2)) {
                mysqli_stmt_bind_param($stmt, 'sssss', $friend, $space, $comfort, $clean, $noice);
                $QueryResult2 = mysqli_stmt_execute($stmt);
                if ($QueryResult2 === FALSE) {
                    echo "query failed";
                } else {
                    echo "<h1>Thank you for your revieuw</h1>";
                }
                mysqli_stmt_close($stmt);
            }
            mysqli_close($DBConnect);
        }
    }else{echo"";}
    ?>
    <a href="airline_show.php">home</a>
</body>

</html>