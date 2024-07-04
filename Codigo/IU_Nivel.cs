using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IU_Nivel
{
	private int numero_opciones_disponibles;
	private int profundidad_nivel;

	public void Establecer_Opciones_Disponibles(int opciones)
	{
		numero_opciones_disponibles = opciones;
	}
	
	public void Inicializar_Profundidad(int profundidad)
    {
		profundidad_nivel = profundidad;
    }

	public void Incrementar_Profundidad()
    {
		profundidad_nivel++;
    }

	public int Obtener_Opciones_Disponibles()
    {
		return numero_opciones_disponibles;
    }

	public int Obtener_Profundidad_Nivel()
    {
		return profundidad_nivel;
    }
}
