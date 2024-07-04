<?php
	$conexion = mysqli_connect('localhost', 'root', '', 'ejercicios_normalizacion');
	
	if (mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}
	
	$usuario = $_POST["usuario"];

	$tablaquery = "SELECT Tiempo, Fallos, ID_Problema FROM resultados WHERE ID_Usuario= '" . $usuario . "' ORDER BY ID_Problema DESC;";

	$tabla = mysqli_query($conexion, $tablaquery) or die("Fallo al Cargar la Tabla");

	while($row = mysqli_fetch_array($tabla))
	{
		echo $row['ID_Problema'] . " " . $row['Tiempo'] . " " . $row['Fallos'] . "\n";
	}
	mysqli_close($conexion);
?>