using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspection : MonoBehaviour
{
    public float vertical;
    public float horrizontal;
    public float _itemDistance = 10; //This will controll how far away the item will be from the player camrea
    public float rotateSpeed = 100; //How fast the player can rotate the item
    public Transform _oldPos;

    //Items
    public Transform clue1;
    public Transform clue2;
    public Transform clue3;
    //public Transform clue4;
    // public Transform clue5;


    public GameObject _camera;
    public KeyCode _interaction;
    public Transform _InspectPos; //This will controll how far away the item will be from the player camrea

    //Statements for Raycast
    public float _rayLength = 10f;
    private bool _isHit = false;
    private Ray _ray = new Ray(); //This will create the raycast
    private RaycastHit _hitObject;
    public LayerMask _layerToHit; //This will help the raycast target only objects in the assigned layer

    // Start is called before the first frame update
    void Start()
    {
        vertical = Input.GetAxis("Mouse Y");
        horrizontal = Input.GetAxis("Mouse X");
    }

    // Update is called once per frame
    void Update()
    {
        //_InspectPos = _camera.transform;
        if (Input.GetKeyDown(_interaction))
        {
            _oldPos.position = clue1.position;
            Inspection();
        }
        else if (Input.GetKeyUp(_interaction))
        {
            clue1.position = _oldPos.position;
            _isHit = false;
        }

    }

    private void Inspection()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hitObject, _rayLength, _layerToHit))
        {
            if (_isHit == false)
            {
                Debug.Log(_hitObject.transform.gameObject.name);

                clue1.position = _InspectPos.position;

                _isHit = true;
            }
        }
    }
}
