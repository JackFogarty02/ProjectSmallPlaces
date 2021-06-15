using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspection : MonoBehaviour
{
    public float vertical;
    public float horrizontal;
    public float rotateSpeed = 100; //How fast the player can rotate the item
    public Transform _oldPos; //Used to store the original position of an inspectable onject
    private Vector2 _mousePos;

    //Items
    public Transform clue1;
    public GameObject rotPos1;
    public Transform clue2;
    public Transform clue3;
    //public Transform clue4;
    // public Transform clue5;


    public GameObject _camera;
    public KeyCode _interaction;
    public Transform _InspectPos; //This will controll how far away the item will be from the player camrea
    public bool _rotaiton = false;

    //Statements for Raycast
    public float _rayLength = 10f;
    private bool _isHit = false; //checks if an object has been hit by the ray
    private Ray _ray = new Ray(); //This will create the raycast
    private RaycastHit _hitObject;
    public LayerMask _layerToHit; //This will help the raycast target only objects in the assigned layer

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * rotateSpeed;
        horrizontal = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * rotateSpeed;

        clue1.transform.Rotate(new Vector3(vertical, -horrizontal, 0));


        if (Input.GetKeyDown(_interaction))
        {

            _rotaiton = true;

            _oldPos.position = clue1.position; //Stores the item's original position and rotation temporarily
            _oldPos.rotation = clue1.rotation;
            Inspection();
        } 
        else if (Input.GetKeyUp(_interaction))
        {
            clue1.position = _oldPos.position; //Returns the item to the original position and rotaiotn
            clue1.rotation = _oldPos.rotation;
            GetComponent<FPMovement>().enabled = true;
            _isHit = false;
            _rotaiton = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void Inspection()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hitObject, _rayLength, _layerToHit))
        {
            if (_isHit == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);
                GetComponent<FPMovement>().enabled = false;

                clue1.position = _InspectPos.position; //move the item closer to the camera 
                clue1.localRotation = _InspectPos.localRotation; //rotates the item to face the player
                Cursor.lockState = CursorLockMode.Confined;


                _isHit = true;
            }


            if (_rotaiton == true)
            {
                Rotation();
            }    
        }
    }

    public void Rotation()
    {

    }
}
