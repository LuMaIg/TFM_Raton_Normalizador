<?php
	$conexion = mysqli_connect('localhost', 'root', '', '');

	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$usuario = $_POST["nombre"];
	$puntuacion = $_POST["puntuacion"];

	$nombrenorepquery = "";

	echo "0";
	mysqli_close($conexion);
?>