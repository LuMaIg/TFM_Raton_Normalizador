using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador
{
	private int fallos_permitidos = 6;
	private float velocidad_movimiento = 5f; 

	public int Fallos_Permitidos()
	{
		return fallos_permitidos;
	}

	public float Velocidad_Movimiento()
    {
		return velocidad_movimiento;
    }
}
