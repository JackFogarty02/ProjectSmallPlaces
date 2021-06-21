using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject triggerDoor;
    public GameObject doorFrame;
    public ObjectiveTracker OT;

    public void OnTriggerExit(Collider doorFrame)
    {
        OT.inHouse = true;
    }
}
