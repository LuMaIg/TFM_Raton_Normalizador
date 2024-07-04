using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_Opciones : MonoBehaviour
{
    public GameObject DosOpciones;
    public GameObject TresOpciones;
    public GameObject CuatroOpciones;
    // Start is called before the first frame update
    void Start()
    {
        int n_respuestas = Juego.Singleton.obtener_numero_de_opciones();

       switch (n_respuestas)
        {
            case 2: DosOpciones.SetActive(true); break;
            case 3: TresOpciones.SetActive(true); break;
            default: CuatroOpciones.SetActive(true); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
