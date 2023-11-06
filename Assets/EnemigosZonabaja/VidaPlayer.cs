using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 100;

    public Image barraDeVida;

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);
        barraDeVida.fillAmount = vida / 100;

        if(vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
