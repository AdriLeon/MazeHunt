using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour {
    
    //Variable para asociar el objeto Texto Tiempo
    public Text textoTiempo;

    private GameManager gameManager;


    void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
    }
	
    void Update () {

        //Escribo tiempo transcurrido (si no se ha acabado el juego)
        if (gameManager.tiempo > 0) {
            gameManager.tiempo -= Time.deltaTime;
        } else {
            gameManager.tiempo = 0;
            gameManager.isJuego = false;
        }

        DisplayTiempo(gameManager.tiempo);
		
    }

    //Formatear tiempo (público porque la necesitaremos más adelante)
    void DisplayTiempo(float timeToDisplay) {
        if(timeToDisplay < 0) {
            timeToDisplay = 0;
        }
    
        //Formateo minutos y segundos a dos dígitos
        float minutos = Mathf.FloorToInt(timeToDisplay / 60);
        float segundos = Mathf.FloorToInt(timeToDisplay % 60);
    
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);

    }
}