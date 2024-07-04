using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Resultados : MonoBehaviour
{
    public TMP_Text tabla;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(obtener());
    }

    // Update is called once per frame
    IEnumerator obtener()
    {
        WWWForm formulario = new WWWForm();
        formulario.AddField("usuario", Juego.Singleton.obtener_id_usuario());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/obtener_ultimos_resultados.php", formulario))
        {
            yield return www.SendWebRequest();
            if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.Log(www.error);
            }
            else
            {
                tabla.text = www.downloadHandler.text;
            }
        }
    }
}
