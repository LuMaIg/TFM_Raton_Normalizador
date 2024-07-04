using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimiento_Retardado : MonoBehaviour
{
    private Vector3 direccion;
    public float Velocidad = 20.0f;
    private Rigidbody rb;
    public LayerMask Etiqueta_Tope;
    public GameObject Pantalla_de_Carga;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direccion = -transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Esperar());
        rb.velocity = direccion * Velocidad;
        /*if (Physics.Raycast(transform.position, transform.forward, Distancia_Limite, Etiqueta_Tope))
        {
            string Nivel = "Encrucijada_Laberinto";
            Velocidad = 0f; 
            CargarNivel(Nivel);
        }*/
    }


    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Barrera"))
        {
            int n_respuestas = Juego.Singleton.obtener_numero_de_opciones();
            Debug.Log(n_respuestas);
            string Nivel;

            switch(n_respuestas)
            {
                case 2: Nivel = "Encrucijada_Laberinto_Bifurcacion"; break;
                case 3: Nivel = "Encrucijada_Laberinto_Trifurcacion"; break;
                default: Nivel = "Encrucijada_Laberinto"; break;
            }
            //string Nivel = "Encrucijada_Laberinto";
            Velocidad = 0f;
            CargarNivel(Nivel);
        }
    }

    public void CargarNivel(string Nivel)
    {
        StartCoroutine(Mostrar_Carga(Nivel));
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

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2);
    }
}
