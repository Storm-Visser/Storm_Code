<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title></title>
</head>

<body>
    <?php
    for ($i = 100; $i > 0; $i--) {
        echo "blablabla" . $i . "blablabla";
        echo "<br>";
        $i = $i - 1;
        echo "blablabla" . $i . "blablabla";
        echo "<br><br>";
    }
    ?>
</body>

</html>