using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mostrar_Pantalla_Carga :  MonoBehaviour
{
	public static Mostrar_Pantalla_Carga Singleton { get; private set; }
	public bool Enunciado = false;
	public bool Fin_Camino = false;
	public bool Meta = false;
	public GameObject Pantalla_de_Carga;

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
			Pantalla_de_Carga.gameObject.SetActive(false);
        }
        else
        {
			Destroy(gameObject);
        }
	}

	public void CargarNivel(string Nivel)
    {
		StartCoroutine(Mostrar_Carga(Nivel));
		//StartCoroutine(Mostrar_Carga_Prueba(Nivel));
	}

	private IEnumerator Mostrar_Carga_Prueba(string Nivel)
    {
		if(Enunciado)
        {
			Juego.Singleton.inicializar_profundidad();
			Juego.Singleton.asignar_numero_de_opciones(4);
		}

		if (Fin_Camino)
		{
			int numero_opciones_previo = Juego.Singleton.obtener_numero_opciones_anterior();
			Juego.Singleton.incrementar_fallos();
			Debug.Log(Juego.Singleton.obtener_numero_fallos());
			Juego.Singleton.asignar_numero_de_opciones(numero_opciones_previo);
		}

		Pantalla_de_Carga.gameObject.SetActive(true);
		SceneManager.LoadScene(Nivel);
		while (!Nivel.Equals(SceneManager.GetActiveScene().name))
		{
			yield return null;
		}
		Pantalla_de_Carga.gameObject.SetActive(false);
	}

	private IEnumerator Mostrar_Carga(string Nivel)
    {

		if (Enunciado)
		{
			int selector = Juego.Singleton.obtener_id_pregunta();
			Juego.Singleton.inicializar_profundidad();
			WWWForm formulario = new WWWForm();
			formulario.AddField("elegido", selector.ToString());
			formulario.AddField("profundidad", Juego.Singleton.obtener_profundidad());

			using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/contar_numero_opciones.php", formulario))
			{
				yield return www.SendWebRequest();
				if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
				{
					Debug.Log(www.error);
				}
				else
				{
					string resultado = www.downloadHandler.text;
					int resultado_numerico = int.Parse(resultado);
					Juego.Singleton.asignar_numero_de_opciones(resultado_numerico);
				}
			}
		}

		if(Fin_Camino)
        {
			int numero_opciones_previo = Juego.Singleton.obtener_numero_opciones_anterior();
			Juego.Singleton.incrementar_fallos();
			Debug.Log(Juego.Singleton.obtener_numero_fallos());
			Juego.Singleton.asignar_numero_de_opciones(numero_opciones_previo);
        }

		if(Meta)
        {
			WWWForm formulario = new WWWForm();
			formulario.AddField("usuario", Juego.Singleton.obtener_id_usuario());
			formulario.AddField("puntuacion", Juego.Singleton.obtener_tiempo_transcurrido().ToString());
			formulario.AddField("fallos", Juego.Singleton.obtener_numero_fallos());
			formulario.AddField("problema", Juego.Singleton.obtener_id_pregunta());

			using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/registrar_resultados.php", formulario))
			{
				yield return www.SendWebRequest();
				if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
				{
					Debug.Log(www.error);
				}
				else
				{
					Debug.Log("Exito al guardar");
				}
			}
		}

		Pantalla_de_Carga.gameObject.SetActive(true);
		SceneManager.LoadScene(Nivel);
		while(!Nivel.Equals(SceneManager.GetActiveScene().name))
        {
			yield return null;
        }
		Pantalla_de_Carga.gameObject.SetActive(false);
    }
}
