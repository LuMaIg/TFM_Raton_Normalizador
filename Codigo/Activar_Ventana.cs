using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Activar_Ventana : MonoBehaviour
{
	public GameObject ContenedorVentana;

	public void hit()
	{
		ContenedorVentana.SetActive(true);
	}
}
