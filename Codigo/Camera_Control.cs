using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public GameObject raton;
    private Vector3 distancia_con_respecto_al_jugador;
    // Start is called before the first frame update
    void Start()
    {
        distancia_con_respecto_al_jugador = transform.position - raton.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = raton.transform.position + distancia_con_respecto_al_jugador;
    }
}
