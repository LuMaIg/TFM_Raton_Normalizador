using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacia_La_Salida : MonoBehaviour
{
    private Vector3 direccion;
    private float Distancia_Limite = 0.6f;
    public float Velocidad = 20.0f;
    private Rigidbody rb;
    public LayerMask Etiqueta_Tope;
    //public Transform objetivo;
    // Start is called before the first frame update
    void Start()
    {
        //var velocidad_rotacion = 190.0f * Time.deltaTime;
        rb = GetComponent<Rigidbody>();
        //Quaternion nueva_rotacion = new Quaternion();
        //nueva_rotacion.Set(0f, -90f, 0f, 1f);
        //transform.rotation = nueva_rotacion;
        direccion = -transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direccion * Velocidad;
        if (Physics.Raycast(transform.position, transform.forward, Distancia_Limite, Etiqueta_Tope))
        {
            Velocidad = 0f;
        }
    }
}
