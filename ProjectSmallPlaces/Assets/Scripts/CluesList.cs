using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesList : MonoBehaviour
{
    public GameObject clue1;
    public GameObject clue2;
    public GameObject clue3;
    public GameObject clue4;
    public GameObject clue5;

    private void Start()
    {
        Camera.main.GetComponent<ItemInspection>()._onClueFound.AddListener(AddClue);
    }

    private void AddClue()
    {
        Debug.Log("Found a clue");

    }
}
