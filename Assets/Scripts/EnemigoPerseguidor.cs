using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPerseguidor : MonoBehaviour
{
    public Transform jugador;
    public float distanciaPerseguir = 10.0f;
    public float velocidad = 5.0f;
    private bool estaPersiguiendo = false;

    void Update()
    {
        if (jugador != null)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
            if (distanciaAlJugador <= distanciaPerseguir && EsVisible())
            {
                estaPersiguiendo = true;
                Vector3 direccion = jugador.position - transform.position;
                direccion.Normalize();
                transform.Translate(direccion * velocidad * Time.deltaTime);
            }
            else
            {
                estaPersiguiendo = false;
            }
        }
    }

    bool EsVisible()
    {
        RaycastHit hit;
        Vector3 direccion = jugador.position - transform.position;
        if (Physics.Raycast(transform.position, direccion, out hit))
        {
            if (hit.transform == jugador)
            {
                return true;
            }
        }
        return false;
    }
}