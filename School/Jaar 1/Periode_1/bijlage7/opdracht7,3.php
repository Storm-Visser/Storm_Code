<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body>
       <?php
       
       function numbers ($number){
            if ($number>100) {
                 $result = $number . " is greater than 100";
            }
            else {
                $result = $number . " is less than or equal to 100";
            }
        echo"$result";
       }
       numbers (78);
        ?>
    </body>
</html>