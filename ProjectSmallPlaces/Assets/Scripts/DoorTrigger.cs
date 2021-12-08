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
        if (OT.puzzleSolved == true)
        {
            Debug.Log("The trigger worked");
        }
        else
            OT.inHouse = true;
    }
}
