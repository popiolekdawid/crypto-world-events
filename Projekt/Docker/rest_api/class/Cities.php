<?php
class Cities{

   private $citiesTable = "futureprices";
   public $id;
   public $name;
   public $price;
public function __construct($db){$this->conn = $db;
 }

 function read(){
 if($this->id) {
 $stmt = $this->conn->prepare("SELECT * FROM ".$this->citiesTable." WHERE ID = ?");
 $stmt->bind_param("i", $this->id);
 } else {
 $stmt = $this->conn->prepare("SELECT * FROM ".$this->citiesTable);
 }
 $stmt->execute();
 $result = $stmt->get_result();
 return $result;
 }
 function create(){

    $stmt = $this->conn->prepare("INSERT INTO ".$this->citiesTable." VALUES (?,?,?,?,?)");
    
    $stmt->bind_param("dsisi", $this->id,$this->name,$this->countrycode,$this->district,$this->population);


    $stmt->execute();
    $result = $stmt->get_result();
    return $result;
    }

 function delete()
 {
    if($this->id) {
        $stmt = $this->conn->prepare("DELETE FROM ".$this->citiesTable." WHERE ID = ?");
        $stmt->bind_param("i", $this->id);
        } 
        $stmt->execute();
        $result = "Succesfully deleted!";
        return $result;
 }
}
