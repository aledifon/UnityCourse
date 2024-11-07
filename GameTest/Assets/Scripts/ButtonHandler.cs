using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject menuCanvas;    

    public void StartGame() 
    {
        //Debug.Log("boton pulsado");
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
        }
        SceneManager.LoadScene("Level");  // Cambia "GameScene" por el nombre de tu escena de juego
    }
}
