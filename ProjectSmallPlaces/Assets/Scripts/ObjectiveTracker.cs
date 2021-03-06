using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    public GameObject triggerDoor;
    public Transform door;
    public Transform doorShut;
    public Transform openPos;

    public GameObject Street;
    public GameObject Field;
    public GameObject Dupes;

    public bool puzzleSolved;
    public int cluesFound;
    public bool inHouse;

    public GameObject _obj0;
    public GameObject _obj1;
    public GameObject _obj2;

    // Start is called before the first frame update
    void Start() //sets up necesary variables 
    {
        inHouse = false;
        puzzleSolved = false;
        cluesFound = 0;
        _obj1.gameObject.SetActive(false);
        _obj2.gameObject.SetActive(false);
        Field.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inHouse == false)
        {
            _obj0.gameObject.SetActive(true);
        }
        else if (inHouse ==  true && puzzleSolved == false) //once the player enters the house the original objective is cleared
        {

            door.position = doorShut.position;
            door.rotation = doorShut.rotation;
            _obj0.gameObject.SetActive(false);
            _obj1.gameObject.SetActive(true);

            if (cluesFound != 5) //if all the clues are found clear the objective
            {
                _obj2.gameObject.SetActive(true);
            }
            else
                _obj2.gameObject.SetActive(false);
        }

        if (puzzleSolved == true)
        {
            _obj1.gameObject.SetActive(false); //clears the objectives
            _obj2.gameObject.SetActive(false);
            door.position = openPos.position; //opens the door
            door.rotation = openPos.rotation;

            Destroy(Street);
            Field.SetActive(true);
            Dupes.SetActive(false);
        }
    }
}
