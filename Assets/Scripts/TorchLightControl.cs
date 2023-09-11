using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightControl : MonoBehaviour
{
    private Light torchLight;
    private bool prevIsNight = false;

    private void Start()
    {
        torchLight = GetComponent<Light>();
        torchLight.enabled = false;
    }

    private void Update()
    {
        if (prevIsNight != DayNightCycle.esDeNoche)
        {
            prevIsNight = DayNightCycle.esDeNoche;

            if (DayNightCycle.esDeNoche)
            {
                torchLight.enabled = true;
            }
        }
        else if (!DayNightCycle.esDeNoche && torchLight.enabled)
        {
            torchLight.enabled = false;
        }
    }
}