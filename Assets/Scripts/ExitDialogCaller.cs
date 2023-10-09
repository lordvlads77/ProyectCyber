using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ExitDialogCaller : MonoBehaviour
{
    public DialogTriggerZA _DialogTriggerZa;
    [FormerlySerializedAs("_CamaraControl")] public CamaraControl _camaraControl;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExitDiag"))
        {
            _camaraControl._dialogCanvas.enabled = true;
            _DialogTriggerZa.ExitDiag();
            Cursor.lockState = CursorLockMode.None;
            _camaraControl.mouseSensibilidadY = 0;
        }
    }
}
