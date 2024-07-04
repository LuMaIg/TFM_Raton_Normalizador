using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Respuesta_Seleccionada : MonoBehaviour
{
    public GameObject Pantalla_de_Carga;
    public int Letra;
    public TMP_Text opcion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Proceso_Seleccion());
        //Proceso_Seleccion_Prueba();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void CargarNivel(string Nivel)
    {
        StartCoroutine(Comprobar_Acierto(Nivel));
        //Comprobar_Acierto_Prueba(Nivel);
    }

    private void Proceso_Seleccion_Prueba()
    {
        if(Juego.Singleton.obtener_profundidad() == 1)
        {
            switch (Letra)
            {
                case 1: opcion.text = "Claves Primarias: nombre_emp, cod_emp, cod_proy"; break;
                case 2: opcion.text = "Claves Primarias: nombre_emp, cod_emp"; break;
                case 3: opcion.text = "Claves Primarias: nombre_emp, cod_proy"; break;
                default: opcion.text = "Claves Primarias: cod_emp, cod_proy"; break;
            }
        }
        else if(Juego.Singleton.obtener_profundidad() == 2)
        {
            switch (Letra)
            {
                case 1: opcion.text = "Primera Tabla: CP(cod_emp), nombre_emp"; break;
                case 2: opcion.text = "Primera Tabla: CP(cod_emp), nombre_emp, CP(cod_proy), presupuestop"; break;
                default: opcion.text = "Primera Tabla: CP(cod_emp), nombre_emp, cod_proy, presupuesto"; break;
            }
        }    
        else if(Juego.Singleton.obtener_profundidad() == 3)
        {
            switch (Letra)
            {
                case 1: opcion.text = "Segundo tabla: CP(cod_proy), presupuesto"; break;
                default: opcion.text = "Segundo tabla: CP(cod_proy), presupuesto, CP(cod_emp), horas"; break;
            }
        }
        else
        {
            switch (Letra)
            {
                case 1: opcion.text = "Tercera tabla: CP(cod_emp), cod_proy, horas"; break;
                case 2: opcion.text = "Tercera tabla: CP(cod_emp), CP(cod_proy), horas"; break;
                default: opcion.text = "Tercera tabla: cod_emp, CP(cod_proy), horas"; break;
            }
        }
    }

    private IEnumerator Proceso_Seleccion()
    {
        int selector = Juego.Singleton.obtener_id_pregunta();
        WWWForm formulario = new WWWForm();
        formulario.AddField("elegido", selector.ToString());
        formulario.AddField("profundidad", Juego.Singleton.obtener_profundidad());
        formulario.AddField("id_opcion", Letra.ToString());
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/obtener_opcion.php", formulario))
        {
            yield return www.SendWebRequest();
            if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                opcion.text = www.downloadHandler.text; 
            }
        }
    }

    private void Comprobar_Acierto_Prueba(string Nivel)
    {
        int numero_opciones_previo = Juego.Singleton.obtener_numero_de_opciones();
        if(Juego.Singleton.obtener_profundidad() == 1)
        {
            if(Letra != 4)
            {
                Juego.Singleton.asignar_numero_de_opciones(-1);
                Juego.Singleton.asignar_numero_opciones_anterior(numero_opciones_previo);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
            else
            {
                Juego.Singleton.incrementar_numero_aciertos();
                Juego.Singleton.incrementar_profundidad();
                Juego.Singleton.asignar_numero_de_opciones(3);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
        }

        else if (Juego.Singleton.obtener_profundidad() == 2)
        {
            if (Letra != 1)
            {
                Juego.Singleton.asignar_numero_de_opciones(-1);
                Juego.Singleton.asignar_numero_opciones_anterior(numero_opciones_previo);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
            else
            {
                Juego.Singleton.incrementar_numero_aciertos();
                Juego.Singleton.incrementar_profundidad();
                Juego.Singleton.asignar_numero_de_opciones(2);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
        }

        else if (Juego.Singleton.obtener_profundidad() == 3)
        {
            if (Letra != 1)
            {
                Juego.Singleton.asignar_numero_de_opciones(-1);
                Juego.Singleton.asignar_numero_opciones_anterior(numero_opciones_previo);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
            else
            {
                Juego.Singleton.incrementar_numero_aciertos();
                Juego.Singleton.incrementar_profundidad();
                Juego.Singleton.asignar_numero_de_opciones(3);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
        }

        else
        {
            if (Letra != 2)
            {
                Juego.Singleton.asignar_numero_de_opciones(-1);
                Juego.Singleton.asignar_numero_opciones_anterior(numero_opciones_previo);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
            else
            {
                Juego.Singleton.incrementar_numero_aciertos();
                Juego.Singleton.incrementar_profundidad();
                Juego.Singleton.asignar_numero_de_opciones(1);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
        }
    }

    private IEnumerator Comprobar_Acierto(string Nivel)
    {
        int selector = Juego.Singleton.obtener_id_pregunta();
        WWWForm formulario = new WWWForm();
        formulario.AddField("elegido", selector.ToString());
        formulario.AddField("profundidad", Juego.Singleton.obtener_profundidad());
        formulario.AddField("id_opcion", Letra.ToString());
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/obtener_si_respuesta_correcta.php", formulario))
        {
            yield return www.SendWebRequest();
            if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                string resultado = www.downloadHandler.text;
                if (resultado == "0")
                {
                    int numero_opciones_previo = Juego.Singleton.obtener_numero_de_opciones();
                    Juego.Singleton.asignar_numero_de_opciones(-1);
                    Juego.Singleton.asignar_numero_opciones_anterior(numero_opciones_previo);
                    StartCoroutine(Mostrar_Carga(Nivel));
                }
                else
                {
                    Juego.Singleton.incrementar_numero_aciertos();
                    StartCoroutine(Comprobar_Profundidad(Nivel));
                }
            }
        }
    }

    private IEnumerator Comprobar_Profundidad(string Nivel) { 
        //Juego.Singleton.incrementar_numero_aciertos();
        int profundidad;

        WWWForm formulario = new WWWForm();
        formulario.AddField("enunciado", Juego.Singleton.obtener_id_pregunta());
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/profundidad_maxima.php", formulario))
        {
            yield return www.SendWebRequest();
            if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log(Juego.Singleton.numero_aciertos());
                string resultado = www.downloadHandler.text;
                profundidad = int.Parse(resultado);

                if (Juego.Singleton.numero_aciertos() >= profundidad)
                {
                    Juego.Singleton.asignar_numero_de_opciones(1);
                    //Debug.Log(Nivel);
                    StartCoroutine(Mostrar_Carga(Nivel));
                }
                else
                {
                    Juego.Singleton.incrementar_profundidad();
                    //Debug.Log(Nivel);
                    StartCoroutine(Obtener_Numero_Opciones(Nivel));
                }
                
            }
        }
    }

    private IEnumerator Obtener_Numero_Opciones(string Nivel)
    {
        int selector = Juego.Singleton.obtener_id_pregunta();
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
                //Debug.Log(www.downloadHandler.text);
                string resultado = www.downloadHandler.text;
                int resultado_numerico = int.Parse(resultado);
                Juego.Singleton.asignar_numero_de_opciones(resultado_numerico);
                StartCoroutine(Mostrar_Carga(Nivel));
            }
        }
    }

    private IEnumerator Mostrar_Carga(string Nivel)
    {
        Pantalla_de_Carga.gameObject.SetActive(true);
        SceneManager.LoadScene(Nivel);
        while (!Nivel.Equals(SceneManager.GetActiveScene().name))
        {
            yield return null;
        }
        Pantalla_de_Carga.gameObject.SetActive(false);
    }
}
