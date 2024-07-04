using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consejos : MonoBehaviour
{
    public Text consejo;

    // Start is called before the first frame update
    void Start()
    {
        int fallos = Juego.Singleton.obtener_numero_fallos();

        if (fallos == 0)
            consejo.text = "Lo has hecho perfecto.\n Enhorabuena";
        else
            consejo.text = "Has terminado pero has fallado en alguna ocasión. Recuerda:\n " +
                "- (1FN): Atributos atomicos, no exite variacion del numero de columnas, los campos no clave deben identificarse por la clave" +
                " y debe haber independencia del ordentanto de filas como de columnas\n" +
                "- (2FN): Si se encuentra en primera y los atributos que no forman parte de ninguna clave dependen de forma completa de la clave principal\n" +
                "- (3FN): Si se encuentra en segunda y no existe ninguna dependencia funcional transitiva entre los atributos que no son clave\n";
    }
}
