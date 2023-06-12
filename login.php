<?php
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Retrieve input values
    $input1 = $_POST['username'];
    $input2 = $_POST['password'];

    // Build the request data
    $postData = [
        'username' => $input1,
        'password' => $input2,
        // Add more parameters as needed
    ];
    
    // Encode the data
    $postData = json_encode($postData);
    
    // Set the URL endpoint for the POST request
    $url = 'https://localhost:7259/api/users/authenticate';

    // Send the POST request
    $options = [
        'ssl' => [
            'verify_peer' => false,
            'verify_peer_name' => false,
        ],
        'http' => [
            'method' => 'POST',
            'header' => 'Content-Type: application/json',
            'content' => $postData,
        ],
    ];

    $context = stream_context_create($options);
    ini_set('display_errors', 0);
    $response = file_get_contents($url, false, $context);
    
    $result = json_decode($response,true);
    
    // Check if the authentication was successful
    if ($result && isset($result['token'])) {
        // Authentication successful, echo the token
        echo "Your token is: ".$result['token'];
        echo '<div class="alert">Attention! Only for authorized users!</div>';
        echo ' <button onclick="showFuture()" id="future-button">Show future!</button>';
    $url = 'http://localhost:8001/cities/read';
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    $response = curl_exec($ch);
    if (curl_errno($ch)) {
        $error_msg = curl_error($ch);
    }
    curl_close($ch);
    $tmp = json_decode($response, true);
    $future = $tmp['cities'];
    $columns = ['date','price'];
                $tableHtml = '<table class="styled-table" id="future-table" style="display:none">';
                $tableHtml .= '<tr>';
                foreach ($columns as $column) {
                    $tableHtml .= '<th>' . $column . '</th>';
                }
                $tableHtml .= '</tr>';

                foreach ($future as $item) {
                    $tableHtml .= '<tr>';
                    foreach ($columns as $column) {
                        $tableHtml .= '<td>' . $item[$column] . '</td>';
                    }
                    $tableHtml .= '</tr>';
                }

                $tableHtml .= '</table>';

                // Output the table
                echo $tableHtml;

    } else {
        // Authentication failed, handle the error
        echo "Authentication failed. Please check your username and password.";
    }
    ini_set('display_errors', 1);
   
        $mysqli = new mysqli("localhost", "root", "", "ethereum");
        $sql = 'SELECT * FROM allcrypto';
        if ($result = $mysqli->query($sql)) {
            while ($data = mysqli_fetch_array($result)) {
                $users[] = $data;
            }
        }
        if (is_array($users) || is_object($users))
        {   
            echo "<h2>2021 Prices</h2>";
            echo "<table>";
            echo "<th>Name</th><th>Symbol</th><th>Price (Intraday)</th><th>Change</th><th>% Change</th><th>Market Cap</th><th>Circulating Supply</th>";
            foreach ($users as $user) {
                echo "<tr>";
                echo  "<td>".$user['Name']. "</td><td> " . $user['Symbol']."</td><td> ". $user['Price (Intraday)']."</td><td> ". $user['Change']."</td><td> ". $user['% Change']."</td><td> ". $user['Market Cap'] . "</td><td> " . $user['Circulating Supply']. "</td>";
            
                echo "<tr>";
            }
            echo "</table>";
        } 
    
}
?>
<head>
    <title>Authorization</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <link rel="stylesheet" href="css/styles.css">
</head>
<script>
    $count = 0;
    function showFuture(){
        if ($count==0)
        {
            document.getElementById("future-table").style.display="table";
            document.getElementById("future-button").innerHTML="Hide future!";
            $count++;
        }
        else
        {
            document.getElementById("future-table").style.display="none";
            document.getElementById("future-button").innerHTML="Show future!";
            $count = 0;
        }

}
</script>