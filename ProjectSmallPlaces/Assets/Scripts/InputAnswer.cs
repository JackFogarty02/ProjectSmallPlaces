using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAnswer : MonoBehaviour
{
    int[] _input = new int[5];

    public bool _nearPC = false;
    public Canvas _canvas;

    public GameObject _pcScreen;
    public GameObject _centrePoint;
    public GameObject mouseLook;

    public InputAnswer(InputAnswer input)
    {
        Debug.Log(_input);
    }

    private void Update()
    {
        if (_nearPC == true)
        {
            SetUp();
        }
        else
        {
            ShutDown();
        }
    }

    public void SetUp()
    {
        _pcScreen.gameObject.SetActive(true);
        _centrePoint.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        mouseLook.GetComponent<MouseLook>().enabled = false;
    }

    public void ShutDown()
    {
        _pcScreen.gameObject.SetActive(false);
        _centrePoint.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.GetComponent<MouseLook>().enabled = true;
    }
}
