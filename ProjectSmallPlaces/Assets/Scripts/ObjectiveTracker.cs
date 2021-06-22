using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveTracker : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject triggerDoor;
    public Transform door;
    public Transform doorShut;
    public Transform openPos;

    public bool puzzleSolved;
    public int cluesFound;
    public bool inHouse;

    public UnityEvent _onEnterHouse;

    public GameObject _objective0;
    public GameObject _obj1;
    public GameObject _obj2;

    // Start is called before the first frame update
    void Start()
    {
        inHouse = false;
        puzzleSolved = false;
        cluesFound = 0;
        _obj1.gameObject.SetActive(false);
        _obj2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inHouse == false)
        {
            _objective0.gameObject.SetActive(true);
        }
        else if (inHouse ==  true && puzzleSolved == false)
        {

            door.position = doorShut.position;
            door.rotation = doorShut.rotation;
            _objective0.gameObject.SetActive(false);
            _obj1.gameObject.SetActive(true);

            if (cluesFound != 5)
            {
                _obj2.gameObject.SetActive(true);
            }
            else
                _obj2.gameObject.SetActive(false);
        }

        if (puzzleSolved == true)
        {
            _obj1.gameObject.SetActive(false);
            _obj2.gameObject.SetActive(false);
            door.position = openPos.position;
            door.rotation = openPos.rotation;
        }
    }
}
