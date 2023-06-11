<?php
class Database{
private $host = 'localhost';
 private $user = 'root';
 private $password = "";
 private $database = "ethereum";

 public function getConnection(){
$conn = new mysqli($this->host, $this->user, $this->password, $this->database);
$conn->query("SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED");
if($conn->connect_error){
die("Error failed to connect to MySQL: " .
$conn->connect_error);
} else {
return $conn;
}
 }
}