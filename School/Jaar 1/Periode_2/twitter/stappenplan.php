<?php
//1. connect to the database
$DBConnect = mysqli_connect("127.0.0.1", "root", "");
if ($DBConnect == FALSE) {
    echo "Unable to connect to the database server";
} else {


    //2. define variables
    $DBName = "twitter";
    $TableName = "users";


    //3. select a database
    mysqli_select_db($DBConnect, $DBName);


    //3. create a query
    $SQLstring = "SELECT userName FROM " . $TableName . " WHERE userName = ?";


    //4. prepare statement if necessary
    if ($stmt = mysqli_prepare($DBConnect, $SQLstring)) {


        //5. bind parameters if necessary
        mysqli_stmt_bind_param($stmt, "s"/*s=string, i=int, net zoveel als de vraagtekens in de Sqlstring*/, $selectedname);


        //6. execute statement if neccecary
        $QueryResult = mysqli_stmt_execute($stmt);


        //7. bind result if neccecary
        mysqli_stmt_bind_result($stmt, $uname);


        //8. store result if nececary // this stores the number of rows that contain result
        mysqli_stmt_store_result($stmt);


        //9. check succes
        if ($QueryResult == FALSE) {
            echo "query failed 1";
            die();
        }
        //10. use results


        //11. close statement
        mysqli_stmt_close($stmt);


    } else { //12check of de statement heeft geprepared
        echo mysqli_error($DBConnect);
    }

    
    //13. close database connection
    mysqli_close($DBConnect);
}
