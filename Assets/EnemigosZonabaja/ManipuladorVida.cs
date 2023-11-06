using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipuladorVida : MonoBehaviour
{
    VidaPlayer playervida;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    void Start()
    {
        playervida = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Payer")
        {
            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime)
            {
                playervida.vida -= cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}
