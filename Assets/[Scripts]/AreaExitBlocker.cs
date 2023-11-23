using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaExitBlocker : MonoBehaviour
{
    public List<CollectibleItem> requiredItems = new List<CollectibleItem>();
    public DialogueTriggerZonaB _dialogueTrigger;
    public DialogueTriggerZonaB _dialogueTrigger2;
    public CameraManager _cameraManager;
    public ZoneChanger _zoneChanger;
    public PlayerMoveManager _playerMoveManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CheckRequiredItemsCollected())
            {
                // The player has collected all required items, allow them to leave
                Debug.Log("You can leave the area.");
                // You can put code to enable leaving the area here (e.g., load a new scene, open a door, etc.)
                StartCoroutine(leaveArea());
            }
            else
            {
                // The player hasn't collected all required items, block them from leaving
                Debug.Log("You must collect all required items before leaving.");
                // You can put code to prevent leaving here (e.g., display a message, play a sound, etc.)
                _cameraManager._canvasDialog.enabled = true;
                _dialogueTrigger2.NoExit();
                _playerMoveManager._diagCanvas.enabled = true;
            }
        }
    }

    private bool CheckRequiredItemsCollected()
    {
        foreach (CollectibleItem requiredItem in requiredItems)
        {
            if (!requiredItem.IsCollected)
            {
                return false; // If any required item is not collected, return false
            }
        }
        return true; // All required items have been collected
    }
    
    public IEnumerator leaveArea()
    {
        _cameraManager._canvasDialog.enabled = true;
        _dialogueTrigger.LeavingOkey();
        _playerMoveManager._diagCanvas.enabled = true;
        yield return new WaitForSeconds(4f);
        _zoneChanger.ReturnZonaAlta();
        yield break;
    }
}

