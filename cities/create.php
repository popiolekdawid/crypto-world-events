<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../class/Cities.php';
$database = new Database();
$db = $database->getConnection();
$cities = new Cities($db);
$cities->Id = (isset($_GET['id']) && $_GET['id']) ?$_GET['id'] : '0';
$cities->name = (isset($_GET['name']) && $_GET['name']) ?$_GET['name'] : '1';
$cities->countrycode = (isset($_GET['cc']) && $_GET['cc']) ?$_GET['cc'] : '2';
$cities->district = (isset($_GET['dis']) && $_GET['dis']) ?$_GET['dis'] : '3';
$cities->population = (isset($_GET['pop']) && $_GET['pop']) ?$_GET['pop'] : '4';





$result = $cities->create();

