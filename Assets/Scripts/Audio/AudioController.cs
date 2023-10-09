using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    [FormerlySerializedAs("_emotionalDamageSource")] [SerializeField] AudioSource _emotionalDmgSource;
    [FormerlySerializedAs("_emotionalDamageClips")] [SerializeField] List<AudioClip> _emotionalDmgClips = new List<AudioClip>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (Instance != this)
        {
            Destroy(gameObject); 
        }
    }
        
    public void EmotionalDMGSFX()
    {
        AudioClip clip = _emotionalDmgClips[Random.Range(0, _emotionalDmgClips.Count)];
            
        _emotionalDmgSource.PlayOneShot(clip);
    }
}
