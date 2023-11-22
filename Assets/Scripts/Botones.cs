using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    //1. Declaración de variables
    private GameManager gameManager;
    //Referencias a los botones (public para poder asignarlas en la Inspector window)
    public Button botonJuego, botonSalir;
    // Start is called before the first frame update
    void Start()
    {
        //2. Busco y asocio mi script de GameManager
        gameManager = FindObjectOfType<GameManager>();
        
        //3. Acciones de cada botón
        
        //Botón jugar (si existe)
        if (botonJuego)
        {
            //Le añado la acción a ejecutar (cambiar a la escena de Juego)
            botonJuego.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Juego"));
        }
        
        
        //Botón salir (si existe)
        if (botonSalir)
        {
            //Le añado la acción a ejecutar (salir del juego)
            //Este botón no funcionará en el Editor de Unity, pero sí al hacer la Build
            botonSalir.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
        }
    }

}