using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ObjectiveTracker : MonoBehaviour
{
    public bool puzzleSolved;
    private int cluesFound;


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
