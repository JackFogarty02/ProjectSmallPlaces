using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float m_sensitivity = 100f; //Mpouse senitivity
    public float m_clampAngle = 90f; //This limits the camera's vertical rotation
    public Transform m_playerObject; //Store the player controller
    public Transform m_camera; //Store the player camera
    public KeyCode _interaction;

    private Vector2 m_mousePos; //Store mouse position
    private float m_xRotation = 0f; //final loop up rotation value

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Lock the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_interaction))
        {
            
        }
        else
        {
            
            GetMousePos(); //Get the moues position
            ClampUpRotation(); //Clamp the loop up
            LookAt(); //look at mouse position
        }
    }

    //Get the moues position
    private void GetMousePos() //Get the mouses current posiiton on the x and y axis
    {
        m_mousePos.x = Input.GetAxis("Mouse X") * m_sensitivity * Time.deltaTime;
        m_mousePos.y = Input.GetAxis("Mouse Y") * m_sensitivity * Time.deltaTime;
    }

    //FixRotation
    private void ClampUpRotation()
    {
        m_xRotation -= m_mousePos.y; //value of xRotation is subtracted by the value in the mouse input of the y axis
        m_xRotation = Mathf.Clamp(m_xRotation, -m_clampAngle, m_clampAngle);
    }

    //Look at the mouse position
    private void LookAt()
    {
        m_camera.transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);//move the z axis to match the mouse's position
        m_playerObject.Rotate(Vector3.up * m_mousePos.x); //multiply the vector by the x axis value of the mouse inputGet
    }
}
