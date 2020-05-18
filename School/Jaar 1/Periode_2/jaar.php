<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>Guestbook</title>
</head>

<body>
    <?php
        $value = 59;
        $limit = 60;
        $new = ($value + 1) % $limit;
        echo $new;
    ?>
</body>

</html>