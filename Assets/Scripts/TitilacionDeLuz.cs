using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitilacionDeLuz : MonoBehaviour
{
    public Light pointLight;
    public float tiempoEntreTitilaciones = 1.0f;

    private float tiempoPasado;

    void Start()
    {
        tiempoPasado = 0f;
    }

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= tiempoEntreTitilaciones)
        {
            tiempoPasado = 0f;
            pointLight.enabled = !pointLight.enabled;
        }
    }
}