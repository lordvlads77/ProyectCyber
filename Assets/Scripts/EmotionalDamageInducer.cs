using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmotionalDamageInducer : MonoBehaviour
{
    // Start is called before the first frame update
    private void LateUpdate()
    {
        StartCoroutine(EmotionalDamage());
    }
    
    IEnumerator EmotionalDamage()
    {
        yield return new WaitForSeconds(30);
        Debug.Log("EnterFirstClip");
        AudioController.Instance.EmotionalDMGSFX();
        yield break;
        
    }
}
