<?php
$conexion = mysqli_connect('localhost','root','','ejercicios_normalizacion');
	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$elegido = $_POST["elegido"];

	$enunciadoquery = "SELECT Descripcion FROM enunciados_verdaderos WHERE ID= '" .$elegido. "';";

	$enunciado = mysqli_query($conexion, $enunciadoquery) or die("Fallo al Cargar la Tabla");

	$row = mysqli_fetch_array($enunciado);

	echo $row['Descripcion'];

	mysqli_close($conexion);
?>