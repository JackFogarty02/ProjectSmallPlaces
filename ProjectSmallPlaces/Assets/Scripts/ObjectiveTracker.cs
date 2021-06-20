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

    public UnityEvent _onEnterHouse;

    public Button _objective0;
    public Text _text0;
    public Button _obj1;


    // Start is called before the first frame update
    void Start()
    {
        inHouse = false;
        puzzleSolved = false;
        cluesFound = 0;

        _objective0.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inHouse == false)
        {
            _objective0.interactable = false;
        }
    }
}
