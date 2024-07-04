<?php
	$conexion = mysqli_connect('localhost', 'root', '', '');

	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$n_seleccionado = $_POST["numero"];

	$preguntaquery = "SELECT * FROM enunciados WHERE ID = '" . $n_seleccionado . "';";
	
	$pregunta = mysqli_query($conexion, $preguntaquery) or die("Fallo al Obtener Pregunta");
	
	$row = mysqli_fetch_array($pregunta)

	echo $row['Descripcion'];
	mysqli_close($conexion);
?>