using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Mostrar_Enunciado : MonoBehaviour
{
    public Text enunciado;
    public bool Empezamos = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(obtener());
        //obtener_prueba();
    }

    void obtener_prueba()
    {
        if(Empezamos)
        {
            Juego.Singleton.asignar_numero_de_opciones(1);
            Juego.Singleton.inicializar_fallos();
            Juego.Singleton.inicializar_aciertos();
        }
        enunciado.text = "Deseamos normalizar a la maxima forma posible la siguiente relacion: Relacion(cod_emp, nombre_emp, cod_proy, presupuesto, horas)" +
            " siendo cod_emp y cod_proy claves primarias. Dependencias: nombre_emp depende de cod_emp, presupuesto depende de cod_proy y horas " +
            "depende tanto de cod_emp, como de cod_proy.";
    }

    IEnumerator obtener() {
        WWWForm formulario = new WWWForm();
        if (Empezamos)
        {
            int selector = (int)Random.Range(1, 3);
            Juego.Singleton.asignar_id_pregunta(selector);
            Juego.Singleton.inicializar_fallos();
            Juego.Singleton.inicializar_aciertos();
            formulario.AddField("elegido", selector.ToString());
        }
        else
        {
            formulario.AddField("elegido", Juego.Singleton.obtener_id_pregunta());
        }

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/obtener_enunciado.php", formulario))
        {
            yield return www.SendWebRequest();
            if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.Log(www.error);
            }
            else
            {
                enunciado.text = www.downloadHandler.text;
            }
        }
    }

}
