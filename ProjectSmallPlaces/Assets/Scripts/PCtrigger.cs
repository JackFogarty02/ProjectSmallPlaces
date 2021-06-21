using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCtrigger : MonoBehaviour
{
    public GameObject triggerArea;
    public InputAnswer _IA;

    public void OnTriggerEnter(Collider other)
    {
        _IA._nearPC = true;
    }

    public void OnTriggerExit(Collider other)
    {
        _IA._nearPC = false;
    }
}
