<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Palindrom</title>
</head>
<body>
<div>
    <?php
    include 'ownLibrary.class.php';
    $test_words_array =  [
        'Abba',
        'Lagerregal',
        'Reliefpfeiler',
        'Rentner',
        'Dienstmannamtsneid',
        'Tarne nie deinen Rat!',
        'Eine güldne, gute Tugend: Lüge nie!',
        'Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!',
        'ein anderes Beispiel!'
    ];
    foreach ( $test_words_array as $test ) {
        echo ownLibrary::checkWord($test) . '<br /><br />';
    }
    ?>
</div>
</body>
</html>
