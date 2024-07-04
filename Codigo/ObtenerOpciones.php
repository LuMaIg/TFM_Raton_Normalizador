<?php
	$conexion = mysqli_connect('localhost', 'root', '', '');

	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$profundidad = $_POST["profundidad"];
	$n_enunciado = $_POST["n_enunciado"];

	$opcionesquery = "SELECT Descripcion, Correcta, Consejo FROM opciones where WHERE ID_Enunciado= '" . $n_enunciado . "' AND Profundidad = '" . $profundidad . "';";
	$opciones = mysqli_query($conexion, $opcionesquery) or die("Fallo al Obtener Opciones");

	while($row = mysqli_fetch_array($opciones))
	{
		echo $row['Descripcion'] . "|" . $row['Correcta'] . "|" . $row['Consejo'] . "\n"; 
	}
	mysqli_close($conexion);
?>