using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesList : MonoBehaviour
{
    public GameObject clue1;
    public GameObject clue2;
    public GameObject clue3;
    public GameObject clue4;
    public GameObject clue5;

    public ItemInspection _itIn;
    public ObjectiveTracker _ot;

    public List<CluesList> Clues = new List<CluesList>();

    private void Start()
    {
        clue1.gameObject.SetActive(false);
        clue2.gameObject.SetActive(false);
        clue3.gameObject.SetActive(false);
        clue4.gameObject.SetActive(false);
        clue5.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (_itIn._1isFound == true)
        {
            clue1.gameObject.SetActive(true);

        }
        if (_itIn._2found == true)
        {
            clue2.gameObject.SetActive(true);

        }
        if (_itIn._3found == true)
        {
            clue3.gameObject.SetActive(true);

        }
        if (_itIn._4found == true)
        {
            clue4.gameObject.SetActive(true);

        }
        if (_itIn._5found == true)
        {
            clue5.gameObject.SetActive(true);

        }
        if (_itIn._1isFound == true && _itIn._2found == true && _itIn._3found == true && _itIn._4found == true && _itIn._5found == true)
        {
            _ot.cluesFound = 5;
        }
    }

    private void AddClue(CluesList item)
    {
        Clues.Add(item);
        Debug.Log("Found a clue");

    }
}
