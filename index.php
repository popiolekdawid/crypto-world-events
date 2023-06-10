<?php
$csvFile = fopen('btc-usd-max.csv', 'r');

include_once './config/Database.php';
include_once './class/Cities.php';
$labels = [];
$values = [];
while (($row = fgetcsv($csvFile)) !== false) {
    $dateString = $row[0];
    $price = $row[1];
    $date = date('d-m-Y', strtotime($dateString));
    $labels[] = $date;
    $values[] = $price;
}

fclose($csvFile);

?>

<!DOCTYPE html>
<html>
<head>
    <title>Chart Example</title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <link rel="stylesheet" href="css/styles.css">
</head>
<body>
    <h2>Bitcoin prices! </h2>
    <button id="drawChartButton" name="bitcoinChart">Draw Bitcoin Chart</button>
    <button id="hideChartButton">Hide Bitcoin Chart</button>
    <canvas id="bitcoinChart" class="chart"></canvas>

    <form method="get">
        <input type="hidden" name="get_ethereum" value="1">
        <button type="submit">Load Ethereum into database</button>
       
    </form>
    <?php
        if (isset($_GET['get_ethereum'])) {
            $url = "https://localhost:7259/api/values";
            $options = [
                'ssl' => [
                    'verify_peer' => false,
                    'verify_peer_name' => false,
                ],
            ];
            $context = stream_context_create($options);
            $response = file_get_contents($url, false, $context);
            if ($response === false) {
                echo "Error: Unable to retrieve data.";
            } else {
                $database = new Database();
                $db = $database->getConnection();
                $cities = new Cities($db);
                $cities->id = (isset($_GET['id']) && $_GET['id']) ? $_GET['id'] : '0';

                $result = $cities->read();
                $labels2[] = null;
                $values2[] = null;
                while ($row = $result->fetch_assoc()) {
                    array_push($labels2,$row['date']);
                    array_push($values2,$row['price']);
                }
                echo '<button id="drawEthereumButton" name="bitcoinChart">Draw Ethereum Chart</button>';
                echo '<button id="hideEthereumButton" name="bitcoinChart">Hide Ethereum Chart</button>';
                echo ' <canvas id="EthereumChart" class="chart"></canvas>';
            }
        }
        if (isset($_GET['get_top20'])) {
            $url = "https://localhost:7259/api/cryptocurrencies";
            $options = [
                'ssl' => [
                    'verify_peer' => false,
                    'verify_peer_name' => false,
                ],
            ];
            $context = stream_context_create($options);
            $response = file_get_contents($url, false, $context);
            if ($response === false) {
                echo "Error: Unable to retrieve data.";
            } else {
                $data = json_decode($response, true);
                $columns = ['Symbol', 'Name', 'Price (Intraday)','Change','% Change','Market Cap','Volume in Currency (Since 0:00 UTC)','Volume in Currency (24Hr)','Total Volume All Currencies (24Hr)','Circulating Supply'];
                $tableHtml = '<table class="styled-table">';
$tableHtml .= '<tr>';
foreach ($columns as $column) {
    $tableHtml .= '<th>' . $column . '</th>';
}
$tableHtml .= '</tr>';

foreach ($data as $item) {
    $tableHtml .= '<tr>';
    foreach ($columns as $column) {
        $tableHtml .= '<td>' . $item[$column] . '</td>';
    }
    $tableHtml .= '</tr>';
}

$tableHtml .= '</table>';

// Output the table
echo $tableHtml;
            }
        }
        ?>
</body>
<script>
        var ctx = document.getElementById("bitcoinChart").getContext('2d');
        var chart;
        document.getElementById('drawChartButton').addEventListener('click', function() {
            chart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: <?php echo json_encode($labels); ?>,
                    datasets: [{
                        label: 'Price',
                        data: <?php echo json_encode($values); ?>,
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    interaction: {
      intersect: false,
    },
                    scales: {
                        x: {
                            display: true,
                            title: {
                                display: true,
                                text: 'Date'
                            }
                        },
                        
                        y: {
                            display: true,
                            title: {
                                display: true,
                                text: 'Price'
                            }
                        }
                    }
                }
            });
        });

        document.getElementById('hideChartButton').addEventListener('click', function() {
            if (chart) {
                chart.destroy();
                chart = null;
            }
        });
    </script>
    <script>
        var ctx2 = document.getElementById("EthereumChart").getContext('2d');
        var chart;
        document.getElementById('drawEthereumButton').addEventListener('click', function() {
            chart = new Chart(ctx2, {
                type: 'line',
                data: {
                    labels: <?php echo json_encode($labels2); ?>,
                    datasets: [{
                        label: 'Price',
                        data: <?php echo json_encode($values2); ?>,
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    interaction: {
      intersect: false,
    },
                    scales: {
                        x: {
                            display: true,
                            title: {
                                display: true,
                                text: 'Date'
                            }
                        },
                        
                        y: {
                            display: true,
                            title: {
                                display: true,
                                text: 'Price'
                            }
                        }
                    }
                }
            });
        });

        document.getElementById('hideEthereumButton').addEventListener('click', function() {
            if (chart) {
                chart.destroy();
                chart = null;
            }
        });
    </script>
    <form method="get">
        <input type="hidden" name="get_top20" value="1">
        <button type="submit">Get info about TOP 20</button>
       
    </form>
</html>
