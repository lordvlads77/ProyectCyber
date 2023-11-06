using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator _animator;
    int horizontal;
    int vertical;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting)
    {
        /*Animation Snapping in case the anims dont go that well with each other or, if they look
         weird when they are blending */
        float snappedHorizontal;
        float snappedVertical;

        #region HorizontalSnapping

            if (horizontalMovement > 0 && horizontalMovement < 0.55f)
            {
                snappedHorizontal = 0.5f;
            }
            else if (horizontalMovement > 0.55f)
            {
                snappedHorizontal = 1;
            }
            else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
            {
                snappedHorizontal = -0.55f;
            }
            else if (horizontalMovement < -0.55f)
            {
                snappedHorizontal = -1;
            }
            else
            {
                snappedHorizontal = 0;
            }

        #endregion
        #region VerticalSnapping

            if (verticalMovement > 0 && verticalMovement < 0.55f)
            {
                snappedVertical = 0.5f;
            }
            else if (verticalMovement > 0.55f)
            {
                snappedVertical = 1;
            }
            else if (verticalMovement < 0 && verticalMovement > -0.55f)
            {
                snappedVertical = -0.55f;
            }
            else if (verticalMovement < -0.55f)
            {
                snappedVertical = -1;
            }
            else
            {
                snappedVertical = 0;
            }
        #endregion

        if (isSprinting)
        {
            snappedHorizontal = horizontalMovement;
            snappedVertical = 2;
        }
        _animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        _animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }
}
