using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAnswer : MonoBehaviour
{
    int i = 0;
    int[] _input = new int[5];

    public bool _nearPC = false;
    public ObjectiveTracker oT;

    public GameObject _pcScreen;
    public GameObject _centrePoint;
    public GameObject mouseLook;

    public Button _red;
    public Button _blue;
    public Button _green;
    public Button _orange;
    public Button _yellow;
    public Text _info;

    GameObject _placement;
    public GameObject _input1;
    public GameObject _input2;
    public GameObject _input3;
    public GameObject _input4;
    public GameObject _input5;

    public void AddInput1()
    {
        _input1.gameObject.SetActive(true);
        _input[i] = 1;
        i++;
        Debug.Log("input");
    }
    public void AddInput2()
    {
        _input2.gameObject.SetActive(true);
        _input[i] = 2;
        i++;
        Debug.Log("input");
    }
    public void AddInput3()
    {
        _input3.gameObject.SetActive(true);
        _input[i] = 3;
        i++;
        Debug.Log("input");
    }
    public void AddInput4()
    {
        _input4.gameObject.SetActive(true);
        _input[i] = 4;
        i++;
        Debug.Log("input");
    }
    public void AddInput5()
    {
        _input5.gameObject.SetActive(true);
        _input[i] = 5;
        i++;
        Debug.Log("input");
    }



    public void Update()
    {
        if (_nearPC == true)
        {
            SetUp();
            PuzzleTime();
        }
        else
        {
            ShutDown();
            _input1.gameObject.SetActive(false);
            _input2.gameObject.SetActive(false);
            _input3.gameObject.SetActive(false);
            _input4.gameObject.SetActive(false);
            _input5.gameObject.SetActive(false);
            int[] _input = new int[5];
        }
    }

    public void SetUp()
    {
        _pcScreen.gameObject.SetActive(true);
        _centrePoint.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        mouseLook.GetComponent<MouseLook>().enabled = false;
        _red.interactable = true;
        _blue.interactable = true;
        _green.interactable = true;
        _orange.interactable = true;
        _yellow.interactable = true;
        _info.text = "Enter the correct code below.";
    }

    public void ShutDown()
    {
        _pcScreen.gameObject.SetActive(false);
        _centrePoint.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.GetComponent<MouseLook>().enabled = true;
        i = 0;
    }

    public void PuzzleTime()
    {
        if (i == 5)
        {
            if (_input[0] == 1 && _input[1] == 2 && _input[2] == 3 && _input[3] == 4 && _input[4] == 5)
            {
                _info.text = "Well done, check the door.";
                oT.puzzleSolved = true;
                _red.interactable = false;
                _blue.interactable = false;
                _green.interactable = false;
                _orange.interactable = false;
                _yellow.interactable = false;
            }
            else if (_input[0] != 1 || _input[1] != 2 || _input[2] != 3 || _input[3] != 4 || _input[4] != 5)
            {
                _info.text = "Incorrect, step away to reset.";
                _red.interactable = false;
                _blue.interactable = false;
                _green.interactable = false;
                _orange.interactable = false;
                _yellow.interactable = false;
            }
        }
    }
}
