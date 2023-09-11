using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //TODO: Mandar llamar _thirdpersoncamera para que se active el canvas
    //TODO: Mandar llamar JumpStartDialogue para que se active el textbox en el script de pickup
    [FormerlySerializedAs("camaraControl")] public CamaraControl _camaraControl = default;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        _camaraControl._dialogCanvas.enabled = true;
    }
}
