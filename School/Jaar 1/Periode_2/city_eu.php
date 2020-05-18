<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>periode 2</title>
</head>

<body>
    <?php
    $info = array(
        "populatie" => array(
            "Berlin" => 1111,
            "Moscow" => 2222,
            "brussel" => 3333,
        ),
        "grootte" => array(
            "Berlin" => 4444,
            "Moscow" => 5555,
            "brussel" => 6666,
        )
    );
    echo $info[0][0] ;// 1111
    echo $info[0][2] ;// 3333
    echo $info[1][1] ;// 5555
    echo $info['populatie']['Moscow'] ;//2222
    echo $info['grootte']['brussel']  ;//6666
    ?>
</body>

</html>