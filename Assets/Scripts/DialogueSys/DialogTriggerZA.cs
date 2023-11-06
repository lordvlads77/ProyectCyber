using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerZA : MonoBehaviour
{
    [SerializeField] public Dialogue dialogue;

    [Header("Animation")]
    public Animator _anim;
    private readonly int _isClicked = Animator.StringToHash("isClicked");


    public void StartDiag()
    {
        FindObjectOfType<DialogManagerZA>().StartCoto(dialogue);
        _anim.SetBool(_isClicked, true);
    }

    public void PickUpDialog()
    {
        FindObjectOfType<DialogManagerZA>().StartCoto(dialogue);
        _anim.SetBool(_isClicked, true);
    }

    public void ExitDiag()
    {
        FindObjectOfType<DialogManagerZA>().StartCoto(dialogue);
        _anim.SetBool(_isClicked, true);
    }

    public void NoExiting()
    {
        FindObjectOfType<DialogManagerZA>().StartCoto(dialogue);
        _anim.SetBool(_isClicked, true);
    }
}
