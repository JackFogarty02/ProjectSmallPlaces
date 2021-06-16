using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ObjectiveTracker : MonoBehaviour
{
    public GameObject triggerDoor;
    public Transform door;

    public bool puzzleSolved;
    private int cluesFound;
    private bool inHouse;


    // Start is called before the first frame update
    void Start()
    {
        inHouse = false;
        puzzleSolved = false;
        cluesFound = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
