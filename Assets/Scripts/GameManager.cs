using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //1. Declaro la variable para el objeto Game Manager
    private GameObject gameManager;

    /* Añadir en la declaración de variables de GameManager */

    //Variables compartidas en todas las escenas
    public float tiempo = 120;
    public bool isJuego = true; //Para saber si estoy jugando y que se incremente el tiempo cuando entre en la escena de Juego
    public int monedas = 14; //para contabilizar las monedas restantes
    
    void Start()
    {
        //2. Busco el objeto GameManager en la escena y lo asocio a la variable
        gameManager = GameObject.Find("GameManager");
        
        //3. Le indico que no se destruya entre escenas
        DontDestroyOnLoad(gameManager);
        
        //4. Cargo la siguiente escena (la de Inicio)
        cambiarEscena("Inicio");

    }

    //Cambia a la escena seleccionada
    //Es public para poder llamarlo desde otro script (el de Botones)
    //Recibe un string que corresponde al nombre de la escena al que quiero cambiar
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}