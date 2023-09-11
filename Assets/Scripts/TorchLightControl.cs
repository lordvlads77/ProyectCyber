using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightControl : MonoBehaviour
{
    private Light torchLight;

    private void Start()
    {
        torchLight = GetComponent<Light>();
        torchLight.enabled = false;
    }

    private void Update()
    {
        if (DayNightCycle.esDeNoche)
        {
            torchLight.enabled = true;
            //Debug.Log("Es de noche: " + DayNightCycle.esDeNoche);
        }
        else
        {
            torchLight.enabled = false;
        }
    }
}