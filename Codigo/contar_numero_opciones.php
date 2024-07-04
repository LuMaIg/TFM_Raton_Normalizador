<?php
	$conexion = mysqli_connect('localhost','root','','ejercicios_normalizacion');
	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}
	
	$elegido = $_POST["elegido"];
	$profundidad = $_POST["profundidad"];
	
	$opcionesquery = "SELECT COUNT(Descripcion) FROM opciones_verdaderas WHERE ID_Enunciado= '" .$elegido. "' and Profundidad = '" .$profundidad. "';";

	$opciones = mysqli_query($conexion, $opcionesquery) or die ("Fallo al Cargar la Tabla");

	$row = mysqli_fetch_array($opciones);

	echo $row['COUNT(Descripcion)'];

	mysqli_close($conexion);
?>