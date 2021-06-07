using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspection : MonoBehaviour
{
    public float vertical;
    public float horrizontal;
    public float _itemDistance = 10; //This will controll how far away the item will be from teh player camrea
    public float rotateSpeed = 100; //How fast the playre can rotate the item
    public GameObject _camera;
    public GameObject item; //For testing purposes there will only be one item that can be inspected

    // Start is called before the first frame update
    void Start()
    {
        vertical = Input.GetAxis("Mouse Y");
        horrizontal = Input.GetAxis("Mouse X");
    }

    // Update is called once per frame
    void Update()
    {
        if ()
        {
            Inspection();
        }
    }

    private void Inspection()
    {

    }
}
