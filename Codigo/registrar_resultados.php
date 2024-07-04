<?php
	$conexion = mysqli_connect('localhost', 'root', '', 'ejercicios_normalizacion');
	
	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$usuario = $_POST["usuario"];
	$salida = $_POST["fallos"];
	$puntuacion = $_POST["puntuacion"];
	$problema = $_POST["problema"];

	$nombrenorepquery = "INSERT INTO resultados (ID_Usuario, Tiempo, Fallos, ID_Problema) VALUES ('" . $usuario . "', '" . $puntuacion . "', '" . $salida . "', '" . $problema . "');";
	mysqli_query($conexion, $nombrenorepquery) or die("Fallo al registrar puntuacion");
	
	echo "0";
	mysqli_close($conexion);
?>