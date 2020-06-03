<?php
$cache_file = 'weatherdata.json';
if(file_exists($cache_file)){
  $weatherdata = json_decode(file_get_contents($cache_file));
}else{
  $api_url = 'http://weerlive.nl/api/json-data-10min.php?key=00ac1da8ca&locatie=Emmen';
  $weatherdata = file_get_contents($api_url);
  file_put_contents($cache_file, $weatherdata);
  $weatherdata = json_decode($weatherdata);
}

$current = $weatherdata->liveweer[0];
$temperatuur= $current->temp;
$samenvatting =$current->samenv;
?>


<?php
  function convert2cen($value,$unit){
    if($unit=='C'){
      return $value;
    }else if($unit=='F'){
      $cen = ($value - 32) / 1.8;
      	return round($cen,0);
      }
  }
?>

<?php

//time interval for deletion to occur...
$x = 600;  //10 mins

//timestamp
$current_time = time();

//the file you wish to delete
$file_name = 'weatherdata.json';

//timestamp
$file_creation_time = filemtime($file_name);

//extract difference
$difference = $current_time - $file_creation_time;

//if difference = $x...then delete file
if ($difference >= $x) {
unlink($file_name);
}?>