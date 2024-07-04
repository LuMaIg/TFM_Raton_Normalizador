<?php
	$conexion = mysqli_connect('localhost','root','','ejercicios_normalizacion');
	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}
	
	$enunciado = $_POST["enunciado"];

	$opcionquery = "SELECT MAX(Profundidad) FROM opciones_verdaderas WHERE ID_Enunciado= '" .$enunciado. "';";

	$opcion = mysqli_query($conexion, $opcionquery) or die ("Fallo al Cargar la Tabla");

	$row = mysqli_fetch_array($opcion);

	echo $row['MAX(Profundidad)'];

	mysqli_close($conexion);
?>