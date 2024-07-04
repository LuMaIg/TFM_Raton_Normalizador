<?php
	$conexion = mysqli_connect('localhost','root','','ejercicios_normalizacion');
	if(mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}
	
	$elegido = $_POST["elegido"];
	$profundidad = $_POST["profundidad"];
	$id_opcion = $_POST["id_opcion"];

	$opcionquery = "SELECT Descripcion FROM opciones_verdaderas WHERE ID_Enunciado= '" .$elegido. "' and Profundidad = '" .$profundidad. "' and Letra = '".$id_opcion."';";
	
	$opcion = mysqli_query($conexion, $opcionquery) or die ("Fallo al Cargar la Tabla");

	$row = mysqli_fetch_array($opcion);

	echo $row["Descripcion"];

	mysqli_close($conexion);
?>