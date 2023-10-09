using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmotionalDamageInducer : MonoBehaviour
{
    private void LateUpdate()
    {
        StartCoroutine(EmotionalDamage());
    }
    
    IEnumerator EmotionalDamage()
    {
        yield return new WaitForSeconds(30);
        AudioController.Instance.EmotionalDMGSFX();
        yield break;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioController.Instance.EmotionalDmgShotSFX();
    }
}
