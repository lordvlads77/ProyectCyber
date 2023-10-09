using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaAltaController : MonoBehaviour
{
    public DialogTriggerZA _DialogTriggerZa;
    void Start()
    {
        _DialogTriggerZa.StartDiag();
    }
}
