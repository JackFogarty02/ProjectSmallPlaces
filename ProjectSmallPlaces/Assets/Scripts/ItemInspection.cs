using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInspection : MonoBehaviour
{
    public float vertical;
    public float horrizontal;
    public float rotateSpeed = 100; //How fast the player can rotate the item
    public Transform _oldPos; //Used to store the original position of an inspectable onject
    private Vector2 _mousePos;

    public UnityEvent _onClueFound;

    //Items, the display models
    public Transform clue1;
    public Transform clue2;
    public Transform clue3;
    public Transform clue4;
    public Transform clue5;

    //Item duplicates, for the player to inspect
    public Transform dup1;
    public Transform dup2;
    public Transform dup3;
    public Transform dup4;
    public Transform dup5;

    public GameObject _camera;
    public KeyCode _interaction;
    public Transform _InspectPos; //This will controll how far away the item will be from the player camrea

    //Statements for Raycast
    public float _rayLength = 10f;
    private bool _isHit = false; //checks if an object has been hit by the ray
    private Ray _ray = new Ray(); //This will create the raycast
    private RaycastHit _hitObject; // Use the RaycastHit type to get an object hit
    public LayerMask _layerTo1; //These will help the raycast target only objects that are within the assigned layer
    public LayerMask _layerTo2;
    public LayerMask _layerTo3;
    public LayerMask _layerTo4;
    public LayerMask _layerTo5;

    //Seperate raycast for finding clues
    public float _smolRayLength = 2.5f;
    private Ray _smallRay = new Ray();
    public LayerMask _imp1;
    public LayerMask _imp2;
    public LayerMask _imp3;
    public LayerMask _imp4;
    public LayerMask _imp5;
    public bool _1isFound = false;
    public bool _2found = false;
    public bool _3found = false;
    public bool _4found = false;
    public bool _5found = false;
    public LayerMask _buttonLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _smallRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_smallRay, out _hitObject, _smolRayLength, _imp1))
        {
            if (_1isFound == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);

                _1isFound = true;
            }
        }
        if (Physics.Raycast(_smallRay, out _hitObject, _smolRayLength, _imp2))
        {
            if (_2found == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);

                _2found = true;
            }
        }
        if (Physics.Raycast(_smallRay, out _hitObject, _smolRayLength, _imp3))
        {
            if (_3found == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);

                _3found = true;
            }
        }
        if (Physics.Raycast(_smallRay, out _hitObject, _smolRayLength, _imp4))
        {
            if (_4found == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);

                _4found = true;
            }
        }
        if (Physics.Raycast(_smallRay, out _hitObject, _smolRayLength, _imp5))
        {
            if (_5found == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);

                _5found = true;
            }
        }

        vertical = Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * rotateSpeed;
        horrizontal = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * rotateSpeed;


        dup1.transform.Rotate(new Vector3(vertical, -horrizontal, 0));
        dup2.transform.Rotate(new Vector3(vertical, 0, -horrizontal));
        dup3.transform.Rotate(new Vector3(vertical, 0, -horrizontal));
        dup4.transform.Rotate(new Vector3(vertical, -horrizontal, 0));
        dup5.transform.Rotate(new Vector3(vertical, -horrizontal, 0));
        
        


        if (Input.GetKeyDown(_interaction))
        {
            _oldPos.position = dup1.position; //Stores the duplicate's original position and rotation temporarily
            _oldPos.rotation = dup1.rotation;

            _oldPos.position = dup2.position;
            _oldPos.rotation = dup2.rotation;

            _oldPos.position = dup3.position;
            _oldPos.rotation = dup3.rotation;

            _oldPos.position = dup4.position;
            _oldPos.rotation = dup4.rotation;

            _oldPos.position = dup5.position;
            _oldPos.rotation = dup5.rotation;
            Inspection();
        } 
        else if (Input.GetKeyUp(_interaction))
        {
            dup1.position = _oldPos.position; //Returns the duplicate to the original position and rotaiotn
            dup1.rotation = _oldPos.rotation;

            dup2.position = _oldPos.position;
            dup2.rotation = _oldPos.rotation;

            dup3.position = _oldPos.position;
            dup3.rotation = _oldPos.rotation;

            dup4.position = _oldPos.position;
            dup4.rotation = _oldPos.rotation;

            dup5.position = _oldPos.position;
            dup5.rotation = _oldPos.rotation;
            GetComponent<FPMovement>().enabled = true; //allos player to move again
            _isHit = false;
            Cursor.lockState = CursorLockMode.Locked; //keeps the mouse locked in the centre of screen
        }

    }

    public void Inspection()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hitObject, _rayLength, _layerTo1))
        {
            if (_isHit == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);
                GetComponent<FPMovement>().enabled = false;

                dup1.position = _InspectPos.position; //move the item closer to the camera 
                dup1.localRotation = _InspectPos.localRotation; //rotates the item to face the player
                Cursor.lockState = CursorLockMode.Locked;

                _isHit = true;
            }
        }


        if (Physics.Raycast(_ray, out _hitObject, _rayLength, _layerTo2))
        {
            if (_isHit == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);
                GetComponent<FPMovement>().enabled = false;

                dup2.position = _InspectPos.position; //move the item closer to the camera 
                dup2.localRotation = _InspectPos.localRotation; //rotates the item to face the player
                Cursor.lockState = CursorLockMode.Locked;


                _isHit = true;
            }
        }
        if (Physics.Raycast(_ray, out _hitObject, _rayLength, _layerTo3))
        {
            if (_isHit == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);
                GetComponent<FPMovement>().enabled = false;

                dup3.position = _InspectPos.position; //move the item closer to the camera 
                dup3.localRotation = _InspectPos.localRotation; //rotates the item to face the player
                Cursor.lockState = CursorLockMode.Locked;


                _isHit = true;
            }
        }
        if (Physics.Raycast(_ray, out _hitObject, _rayLength, _layerTo4))
        {
            if (_isHit == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);
                GetComponent<FPMovement>().enabled = false;

                dup4.position = _InspectPos.position; //move the item closer to the camera 
                dup4.localRotation = _InspectPos.localRotation; //rotates the item to face the player
                Cursor.lockState = CursorLockMode.Locked;


                _isHit = true;
            }
        }
        if (Physics.Raycast(_ray, out _hitObject, _rayLength, _layerTo5))
        {
            if (_isHit == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);
                GetComponent<FPMovement>().enabled = false;

                dup5.position = _InspectPos.position; //move the item closer to the camera 
                dup5.localRotation = _InspectPos.localRotation; //rotates the item to face the player
                Cursor.lockState = CursorLockMode.Locked;

                _isHit = true;
            }
        }

    }
}
