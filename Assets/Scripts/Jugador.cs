using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f;

    private GameManager gameManager;
    
    public Text textoMonedas;
    public Text textoMensaje;



    void Start()
    {
        gameManager = (GameManager)FindObjectOfType<GameManager>();
        textoMensaje.text = "";
        textoMonedas.text = "Monedas: "+ gameManager.monedas;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.tiempo > 0 && gameManager.monedas > 0) {
            moverJugador();
        } else if (gameManager.tiempo == 0) {
            textoMensaje.text = "Juego Terminado";
            gameManager.isJuego = false;
        }else if (gameManager.monedas == 0) {
            textoMensaje.text = "¡Has recolectado todas las monedas!";
            textoMensaje.color = new Color(0, 255, 0);
       } 

    }

    void moverJugador() {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        movementDirection.Normalize();

        transform.position = transform.position + movementDirection * speed * Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movementDirection),rotationSpeed * Time.deltaTime);

        
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag ("Moneda")){

            //Desactivo el objeto
            other.gameObject.SetActive (false);
            
            //Decremento el contador de monedas en uno (también se puede hacer como monedas = monedas -1)
            gameManager.monedas--;
            
            //Actualizo el texto del contador de monedas
            textoMonedas.text = "Monedas: " + gameManager.monedas;

        }

    }
}
