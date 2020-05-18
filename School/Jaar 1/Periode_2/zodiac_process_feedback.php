<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>zodiac</title>
</head>

<body>
    <a href="zodiac_feedback.html">return</a><br>
    <?php
    if (empty($_POST["naam"]) || empty($_POST["mess"])) {
        echo "voer alle velden in";
    } else {
        include("inc_connect.php");
        //1.  connect to the database               x
        //2.  select a database                     x
        //3.  create a query                        x
        //4.  prepare statement if necessary        x
        //5.  bind parameters if necessary          x
        //6.  execute statement                     x
        //7.  check succes                          x
        //8.  buffer and bind result if necessary   x
        //9.  check result if necessary             x
        //10. use results if necessary              X
        //11. close statement                       x
        //12. close database connection             x
        $table = "zodiacfeedback";
        if (isset($_POST["ano"])) {
            $ano = "Y";
        } else {
            $ano = "N";
        }
        $naam = $_POST["naam"];
        $bericht = $_POST["mess"];
        $SQL1 = "INSERT INTO " . $table . " VALUES(CURRENT_DATE(), CURRENT_TIME(), ?, ?, ?)";
        if ($stmt = mysqli_prepare($DBConnect, $SQL1)) {
            mysqli_stmt_bind_param($stmt, 'sss', $naam, $bericht, $ano);
            $QueryResult1 = mysqli_stmt_execute($stmt);
            if ($QueryResult1 == FALSE) {
                echo "query failed";
            } else {
                echo "<h1>Thank you for giving your feedback</h1>";
            }
            mysqli_stmt_close($stmt);
        } else {
            echo "error";
        }
        mysqli_close($DBConnect);
    }
    ?>
    <a href="zodiac_view.php">view feedback</a><br>
</body>

</html>