<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Show Guest Book</title>
    </head>
    <body>    
        <?php
        $DBConnect = mysqli_connect("127.0.0.1", "root", "");
        if ($DBConnect === FALSE)
        {
        echo "<p>Unable to connect to the database server.</p>"
        . "<p>Error code " . mysqli_connect_errno() . ": " . mysqli_connect_error()
        . "</p>";
        }else{
            $DBName = "guestbook";
            if(!mysqli_select_db ($DBConnect, $DBName))
            {
            echo "<p>There are no entries in the guest book!</p>";
            }
            else {
                $TableName = "visitors";
                $SQLstring = "SELECT first_name, last_name FROM ".$TableName;
                if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {
                    mysqli_stmt_execute($stmt);
                    mysqli_stmt_bind_result($stmt, $fname, $lname);
                    mysqli_stmt_store_result($stmt);
                    if (mysqli_stmt_num_rows($stmt) == 0) {
                    echo "<p>There are no entries in the guest
                    book!</p>";
                        }else {
                            echo "<p>The following visitors have signed our guest
                            book:</p>";
                            echo "<table width='100%' border='1'>";
                            echo "<tr><th>First Name</th>
                            <th>Last Name </th></tr>";
                            while (mysqli_stmt_fetch($stmt)) {
                            echo "<tr><td>".$fname."</td>";
                            echo "<td>".$lname."</td></tr>";
                            }
                        }
                     mysqli_stmt_close($stmt);
                   }
                mysqli_close($DBConnect);
                }
            }
        ?>
    </body>
</html>