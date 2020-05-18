<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title></title>
</head>

<body>
    <?php
    if (empty($_POST['name']) || empty($_POST['version']) || empty($_POST['hardware']) || empty($_POST['OS']) || empty($_POST['frequency'])) {
        echo "enter al the fields";
    } else {
        //connect to database
        $DBConnect = mysqli_connect("127.0.0.1", "root", "");
        if ($DBConnect === FALSE) {
            die("There was an error connecting to the database. Error: " . mysqli_connect_errno());
        } else {
            //select the database
            $DBName = "bugrep";
            if (mysqli_select_db($DBConnect, $DBName)) {
                //set updated variables
                $id = $_GET["id"];
                $bugtitle = htmlentities($_POST['bugtitle']);
                $prodNamenew = htmlentities($_POST['name']);
                $prodVersionnew = htmlentities($_POST['version']);
                $HardwareTypenew = htmlentities($_POST['hardware']);
                $OSnew = htmlentities($_POST['OS']);
                $freqnew = htmlentities($_POST['frequency']);
                $sollnew = htmlentities($_POST['sollution']);
                //create new  query
                $query2 =  "UPDATE bugs
                            SET
                                `bug_title` = ? ,
                                `product_name`= ? ,
                                `product_version`= ? ,
                                `hardware_type`= ? ,
                                `OS`=?,
                                `frequency`= ? ,
                                `sollution`= ?
                            WHERE `countID`= ?";

                //prepare statement
                if ($stmt = mysqli_prepare($DBConnect, $query2)) {

                    //bind parameters
                    mysqli_stmt_bind_param($stmt, 'ssssssss', $bugtitle, $prodNamenew, $prodVersionnew, $HardwareTypenew, $OSnew, $freqnew, $sollnew, $id);
                    //execute stmt && check succes
                    if (mysqli_stmt_execute($stmt)) {
                        echo "bug updated<br>";
                    } else {
                        echo "Error updating bug<br>";
                        die(mysqli_error($DBConnect));
                    }
                } else {
                    die(mysqli_error($DBConnect));
                }
            }
            mysqli_close($DBConnect);
        }
    }
    ?>
    <a href='bug_rep.php'>home</a>
</body>

</html>