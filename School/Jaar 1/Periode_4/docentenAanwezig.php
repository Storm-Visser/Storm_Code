<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="Css\style.css" type="text/css">
    <title></title>
</head>

<body>
    <?php
    $DBConnect = mysqli_connect("127.0.0.1", "root", "");
    if ($DBConnect == false)
    {
        echo "unable to connect to the database server";
    }
    else 
    {
        $DBName = "innovate";
        $Tablename = "docent";
        mysqli_select_db($DBConnect, $DBName);

        $SQL = "SELECT `Status`, `Voornaam`, `Achternaam`, `Foto` FROM `docent`";

        if ($stmt = mysqli_prepare($DBConnect, $SQL))
        {
            $SQLResult = mysqli_stmt_execute($stmt);
            mysqli_stmt_bind_result($stmt, $status, $fname, $lname, $picpath);
            mysqli_stmt_store_result($stmt);

            if ($SQLResult !== false)
            {
                $numberOfRows = mysqli_stmt_num_rows($stmt);
                while (mysqli_stmt_fetch($stmt))
                {
                    // echo alles (moet nog in een tabel)
                    $name = $fname . " " . $lname;
                    // set de kleur aan de hand van de status
                    switch ($status) {
                        case 0:
                            $color = "green";
                            break;
                        case 1:
                            $color = "yellow";
                            break;
                        case 2:
                            $color = "red";
                            break;
                        default:
                            $color = "grey";
                    }
                    echo "<table style='border: 2px solid black; width: 100%;'>
                            <tr>
                                <td style='color:" . $color . ";border: 2px solid black;'> &#9751 </td>
                                <td style='color:" . $color . ";border: 2px solid black;'>" . $name . "</td>
                            </tr>
                          </table>";
                }
            }
            else
            {
                echo "Query failed";
            }
        }
    }
    //refresh de pagina na 10 seconden
    header("refresh:10; url = docentenAanwezig.php");
    ?>
</body>
</html>