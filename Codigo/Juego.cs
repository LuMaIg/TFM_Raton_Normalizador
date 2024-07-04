using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{

	public static Juego Singleton { get; set; }
	private int callejones_sin_salida;
	private int numero_fallos;
	private int id_pregunta;
	private int numero_de_opciones;
	private float tiempo_transcurrido;
	private int numero_de_opciones_anterior;
	private int profundidad;
	private List<string> consejos;
	private IU_Nivel nivel;
	private Jugador jugador;
	private string id_usuario;
	private int aciertos;

	void Awake()
	{
		Definicion();
	}

	private void Definicion()
    {
		if(Singleton == null)
        {
			Singleton = this;
			DontDestroyOnLoad(this);
        }
		else
        {
			Destroy(gameObject);
        }
    }

	public IU_Nivel Obtener_IU_Nivel()
	{
		return nivel;
	}

	public Jugador Obtener_Jugador()
    {
		return jugador;
    }

	public void inicializar_fallos()
    {
		numero_fallos = 0;
    }

	public void inicializar_aciertos()
    {
		aciertos = 0;
    }

	public void asignar_id_pregunta(int id)
	{
		id_pregunta = id;
	}

	public void asignar_numero_de_opciones(int no)
    {
		numero_de_opciones = no;
    }

	public void inicializar_consejos()
    {
		consejos = new List<string>();
    }

	public void inicializar_profundidad()
    {
		profundidad = 1;
    }
	public void inicializar_callejones()
    {
		callejones_sin_salida = 0;
    }

	public void incrementar_callejones_encontrados()
    {
		callejones_sin_salida++;
    }

	public void incrementar_fallos()
    {
		numero_fallos++;
    }

	public int obtener_numero_fallos()
    {
		return numero_fallos;
    }

	public int obtener_id_pregunta()
	{
		return id_pregunta;
	}

	public int obtener_numero_de_opciones()
    {
		return numero_de_opciones;
    }

	public void agregar_consejo(string consejo)
    {
		consejos.Add(consejo);
    }

	public List<string> obtener_consejos()
    {
		return consejos;
    }

	public int numero_callejones_sin_salida()
    {
		return callejones_sin_salida;
    }

	public void incrementar_numero_aciertos()
    {
		aciertos++;
    }
	public int numero_aciertos()
    {
		return aciertos;
    }

	public int obtener_profundidad()
    {
		return profundidad;
    }

	public void incrementar_profundidad()
    {
		profundidad++;
    }

	public void asignar_numero_opciones_anterior(int noa)
	{
		numero_de_opciones_anterior = noa;
	}

	public int obtener_numero_opciones_anterior()
    {
		return numero_de_opciones_anterior;
    }

	public void asignar_tiempo_transcurrido(float tiempo)
    {
		tiempo_transcurrido = tiempo;
    }

	public float obtener_tiempo_transcurrido()
    {
		return tiempo_transcurrido;
    }

	public void guardar_id_usuario(string id)
    {
		id_usuario = id;
    }

	public string obtener_id_usuario()
    {
		return id_usuario;
    }
}
