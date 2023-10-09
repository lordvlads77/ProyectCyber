using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerZA : MonoBehaviour
{
    [SerializeField] public Dialogue dialogue;
    [SerializeField] private PersonajeMov3D _personajeMov;
    
    [Header("Animation")]
    public Animator _anim;
    private readonly int _isClicked = Animator.StringToHash("isClicked");


    public void StartDiag()
    {
        FindObjectOfType<DialogManagerZA>().StartCoto(dialogue);
        _personajeMov.enabled = true;
        _anim.SetBool(_isClicked, true);
    }

    public void PickUpDialog()
    {
        FindObjectOfType<DialogManagerZA>().StartCoto(dialogue);
    }

    public void ExitDiag()
    {
        Debug.Log("Tiggered");
        FindObjectOfType<DialogManagerZA>().StartCoto(dialogue);
    }
}
