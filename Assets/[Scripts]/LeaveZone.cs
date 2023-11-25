using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveZone : MonoBehaviour
{
    [SerializeField] private ZoneChanger zoneChanger;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        zoneChanger.ChangeZonee();
    }
}
