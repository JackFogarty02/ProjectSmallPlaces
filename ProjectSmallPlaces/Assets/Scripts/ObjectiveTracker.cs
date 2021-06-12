using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ObjectiveTracker : MonoBehaviour
{
    public bool puzzleSolved;
    private int cluesFound;

    public GameObject clue1;
    public GameObject clue2;
    public GameObject clue3;
    public GameObject clue4;
    public GameObject clue5;

    // Start is called before the first frame update
    void Start()
    {
        puzzleSolved = false;
        cluesFound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while (puzzleSolved == false)
        {

        }
    }
}
