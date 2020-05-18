<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>bug reporter</title>
</head>

<body>
    <?php
    include("inc_connect.php");
    $TableName = "zodiacfeedback";
    $SQLstring = "SELECT message_date, message_time, sender, message FROM " . $TableName . " WHERE `public_message` = 'Y'";
    if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
        mysqli_stmt_execute($stmt);
        mysqli_stmt_bind_result($stmt, $md, $mt, $sender, $mess);
        mysqli_stmt_store_result($stmt);
        if (mysqli_stmt_num_rows($stmt) == 0) {
            echo "There are no entries<br>";
        } else {
            echo "<h1>feedback given:</h1>";
            echo "<table width='100%' border='1'>";
            echo "<tr><th>message date</th>";
            echo "<th>message time</th>";
            echo "<th>sender</th>";
            echo "<th>message</th></tr>";
            while (mysqli_stmt_fetch($stmt)) {
                echo "<tr><td>" . $md . "</td>";
                echo "<td>" . $mt . "</td>";
                echo "<td>" . $sender . "</td>";
                echo "<td>" . $mess . "</td></tr>";
            }
            echo "</table>";
        }
        mysqli_stmt_close($stmt);
    }
    mysqli_close($DBConnect);
    ?>
    <a href="zodiac_feedback.html">give feedback</a>
</body>

</html>