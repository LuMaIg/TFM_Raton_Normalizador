<?php
	$conexion = mysqli_connect('localhost', 'root', '', '');

	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$usuario = $_POST["nombre"];
	$contrasena = $_POST["contrasena"];

	$identificarquery = "SELECT * FROM registro WHERE Usuario = '" . $usuario . "' AND Contrasena = '" .$contrasena. "'";
	$identificar = mysqli_query($conexion, $identificarquery) or die("Error al logearse")

	if(mysqli_num_rows($identificar) == 0)
	{
		echo "El Usuario no existe";
		exit();
	}

	echo "0";
	mysqli_close($conexion);
?>