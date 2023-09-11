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
        Debug.Log("Es de noche: " + DayNightCycle.esDeNoche);

        if (DayNightCycle.esDeNoche)
        {
            torchLight.enabled = true;
        }
        else
        {
            torchLight.enabled = false;
        }
    }
}