<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>opdracht 7,2</title>
    </head>
    <body>
       <?php
        $gr=6;
        
        
        if ($gr==3 || $gr==2 || $gr==1 ){
            echo "zeer slecht";
        }
        
        elseif ($gr==5 || $gr==4){
            echo "onvoldoende";
        }
        
        elseif ($gr==7 || $gr==6){
            echo "voldoende";
        }
        
        elseif ($gr==8){
            echo "goed";
        }  
        
        elseif ($gr==9){
            echo "zeer goed";
        }
        
        elseif ($gr==10){
            echo "uitmuntend";
        }
        
        else {
            echo "ongeldig cijfer";
        }
        ?>
        
        <?php
       Switch($gr) {
           case 1:
           case 2:
           case 3:
               echo "zeer slecht";
               break;
           
           case 4:
           case 5:
               echo "onvoldoende";
               break;

           case 6:
           case 7:
               echo "voldoende";
               break;

           case 8:
               echo "goed";
               break;

           case 9:
               echo "zeer goed";
               break;
       
           case 10:
               echo "uitmuntend";
               break;
           
           default:
               echo "ongeldig cijfer";
       }
       
       ?>
    </body>
</html>
