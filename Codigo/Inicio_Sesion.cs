using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Inicio_Sesion : MonoBehaviour
{
	public GameObject VentanaAbrir;
	public GameObject VentanaCerrar;
	public InputField Usuario;
	public InputField Contrasena;

	public void click()
    {
		StartCoroutine(request());
    }

	public IEnumerator request()
    {
		if (Usuario.text.Length >= 1 || Contrasena.text.Length >= 1)
		{
			WWWForm formulario = new WWWForm();
			formulario.AddField("usuario", Usuario.text);
			formulario.AddField("contrasena", Contrasena.text);

			using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/comprobar_usuario.php", formulario))
            {
				yield return www.SendWebRequest();
				if ((www.result==UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
                {
					Debug.Log(www.error);
                }
				else
                {
					//WWW web = new WWW("", formulario);
					//yield return web;
					Debug.Log(www.downloadHandler.text);
					if (www.downloadHandler.text == "1")
						StartCoroutine(guardar_ip());
					else
						Debug.Log("Usuario o Contrasena erronea");
                }
			}
				
		}

    }

	public IEnumerator guardar_ip()
	{
		WWWForm formulario = new WWWForm();
		formulario.AddField("usuario", Usuario.text);
		using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/obtener_id.php", formulario))
		{
			yield return www.SendWebRequest();
			if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
			{
				Debug.Log(www.error);
			}
			else
			{
				string id_actual = www.downloadHandler.text;
				Debug.Log(id_actual);
				Juego.Singleton.guardar_id_usuario(id_actual);
				cambio();
			}
		}
	}

	public void cambio()
	{
		VentanaAbrir.SetActive(true);
		VentanaCerrar.SetActive(false);
	}
}

