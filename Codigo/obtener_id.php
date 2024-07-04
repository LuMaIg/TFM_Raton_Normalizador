<?php
	$conexion = mysqli_connect('localhost', 'root', '', 'ejercicios_normalizacion');
	if (mysqli_connect_errno())
	{
		echo "Conexion Fallida";
		exit();
	}

	$usuario = $_POST["usuario"];

	$nombrenorepquery = "SELECT ID FROM registro WHERE Usuario= '" . $usuario . "';";
	
	$id_usuario = mysqli_query($conexion, $nombrenorepquery) or die("Fallo al Comprobar Nombre de Usuario");
	
	$row = mysqli_fetch_array($id_usuario);

	echo $row['ID'];

	mysqli_close($conexion);
?>