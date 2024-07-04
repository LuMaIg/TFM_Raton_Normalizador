using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cambio_Ventana : MonoBehaviour
{
	public GameObject VentanaAbrir;
	public GameObject VentanaCerrar;

	public void click()
	{
		VentanaAbrir.SetActive(true);
		VentanaCerrar.SetActive(false);
	}
}
