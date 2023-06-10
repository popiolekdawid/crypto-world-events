<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../class/Cities.php';
$database = new Database();
$db = $database->getConnection();
$cities = new Cities($db);
$cities->id = (isset($_GET['id']) && $_GET['id']) ?
$_GET['id'] : '0';

$result = $cities->delete();

