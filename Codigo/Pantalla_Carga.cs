using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pantalla_Carga :  MonoBehaviour
{
	public Sprite[] Pantallas_Carga;
	public Image Carga;

	void Start()
	{

	}

	void Update()
    {
		Carga.sprite = Pantallas_Carga[(int)(Time.time * 5) % Pantallas_Carga.Length];
    }
}
