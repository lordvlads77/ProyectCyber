using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a la que se teletransportará

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "player"
        if (other.CompareTag("Player"))
        {
            // Cargar la escena especificada en sceneToLoad
            SceneManager.LoadScene("InteriorDC");
        }
    }
}