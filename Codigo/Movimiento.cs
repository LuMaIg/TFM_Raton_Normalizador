using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    private Vector3 direccion;
    public float Velocidad = 20.0f;
    public string Nivel = "Raton_Pensando";
    private Rigidbody rb;
    public bool Inicio_Fin;
    public bool Camino_Tomado;
    public bool Final = false;
    public GameObject Abrir;
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
        rb.velocity = direccion * Velocidad;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Barrera"))
        {
            Velocidad = 0f;
            string Nivel;
            if (Inicio_Fin)
            {
                Abrir.SetActive(true);
                if(Final)
                {
                    float tiempo = Time.time;
                    Debug.Log(tiempo);
                    Juego.Singleton.asignar_tiempo_transcurrido(tiempo);
                }
            }
            else
            {
                if (Camino_Tomado)
                {
                    int n_respuestas = Juego.Singleton.obtener_numero_de_opciones();

                    switch (n_respuestas)
                    {
                        case -1: Nivel = "Fin_Camino"; break;
                        case 1: Nivel = "Meta_Laberinto"; break;
                        case 2: Nivel = "Encrucijada_Laberinto_Bifurcacion"; break;
                        case 3: Nivel = "Encrucijada_Laberinto_Trifurcacion"; break;
                        default: Nivel = "Encrucijada_Laberinto"; break;
                    }
                }
                else
                {
                    Nivel = "Raton_Pensando";
                }
                
                CargarNivel(Nivel);
            }
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
}
