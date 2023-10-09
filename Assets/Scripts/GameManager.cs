using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //TODO: Mandar llamar _thirdpersoncamera para que se active el canvas
    //TODO: Mandar llamar StartDialogue para que se active el textbox en el script de pickup
    [FormerlySerializedAs("camaraControl")] public CamaraControl _camaraControl = default;
    [SerializeField] private PersonajeMov3D _personajeMov;

    private void Awake()
    {
        _personajeMov.enabled = false;
    }

    void Start()
    {
        _camaraControl._dialogCanvas.enabled = true;
    }
}
