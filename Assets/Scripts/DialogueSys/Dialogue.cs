using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Dialogue
{
    [FormerlySerializedAs("_nameOfTheSpeaker")] [FormerlySerializedAs("_nameoftheSpeaker")] [SerializeField]
    public string _speakerName;
    [TextArea(3, 5)]
    [SerializeField]
    public string[] sentences;

}
