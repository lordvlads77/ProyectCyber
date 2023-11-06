using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TODO: Mandar llamar _thirdpersoncamera para que se active el canvas
    //TODO: Mandar llamar StartDialogue para que se active el textbox en el script de pickup
    [SerializeField] private PlayerLocomotion _playerLocomotion = default;
    [SerializeField] private CameraManager _cameraManager = default;

    private void Awake()
    {
        //_playerLocomotion.enabled = false;
    }

    void Start()
    {
        _cameraManager._canvasDialog.enabled = true;
    }
}
