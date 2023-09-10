using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 60.0f;
    private Light sun;
    public static bool esDeNoche = false;

    private void Start()
    {
        sun = GetComponent<Light>();
    }

    private void Update()
    {
        float angle = (Time.time / dayDuration) * 360.0f;
        sun.transform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
        esDeNoche = (angle > 180.0f);
    }
}