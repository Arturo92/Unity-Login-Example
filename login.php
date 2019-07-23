<?php
$link = mysqli_connect("localhost", "root", "", "db");
$username = mysqli_real_escape_string($link, $_POST['username']); 
$password = mysqli_real_escape_string($link, $_POST['password']); 

$check = mysqli_query($link, "SELECT * FROM `users` WHERE `username`='$username'" ) or die (mysql_error());
$numrows = mysqli_num_rows($check);
if ($numrows == 0)
	die("Username doesn't exist");
else {
	while ($row = mysqli_fetch_assoc($check)) {
		if($row['password'] == $password){
			echo $username;
		}
		else {
			die("");
		}
	}
}
?>
