<?php
	$conexion = mysqli_connect('localhost', 'root', '', 'ejercicios_normalizacion');
	if (mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$usuario = $_POST["usuario"];
	$contrasena = $_POST["contrasena"];

	$nombrenorepquery = "SELECT Usuario FROM registro WHERE Usuario= '" . $usuario . "' and Contrasena = '" .$contrasena. "';";

	$nombrenorep = mysqli_query($conexion, $nombrenorepquery) or die("Fallo al Comprobar Nombre de Usuario");

	if(mysqli_num_rows($nombrenorep) > 0)
	{
		echo "1";
		exit();
	}

	echo "0";

	mysqli_close($conexion);
?>