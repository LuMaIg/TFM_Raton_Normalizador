using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cerrar_Ventana : MonoBehaviour
{

	public GameObject ContenedorVentana;

	public void click()
	{
		ContenedorVentana.SetActive(false);
	}
}
