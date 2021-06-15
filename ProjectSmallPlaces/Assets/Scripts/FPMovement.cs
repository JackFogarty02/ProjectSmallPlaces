using UnityEngine;
//NOTE: parts of this code were taken from a handout project, all additions will be makred with a "//Added"
public class FPMovement : MonoBehaviour
{
    //Variables
    public UnityEngine.CharacterController m_charController;
    //Movement
    public float m_movementSpeed = 12f;
    public float m_runSpeed = 1.5f;

    //Gravity&physics
    public float m_gravity = -9.81f;
    public float m_jumpHeight = 3f;
    private Vector3 m_velocity;

    //Ground
    public Transform m_groundCheckPoint;
    public float m_groundDistance = 0.4f;
    public LayerMask m_groundMask;
    private bool m_isGrounded;

    //Inputs
    public KeyCode m_forward;
    public KeyCode m_back;
    public KeyCode m_left;
    public KeyCode m_right;
    public KeyCode m_sprint;
    public KeyCode m_jump;
    public KeyCode m_inteact;

    //final speed
    private float m_finalSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_finalSpeed = m_movementSpeed; //Resets the base movement speed
    }

    // Update is called once per frame
    void Update()
    {
        m_isGrounded = HitGroundCheck(); //Every frame the program will check if the player is on the ground
        if (Input.GetKeyDown(m_inteact))
        {

        }
        else
        MoveInputCheck();//Every frame the program will check if the player hsa pressed any of the assigned movement inputs
    }

    //Check if a button is pressed
    void MoveInputCheck()
    {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = Vector3.zero; //Set the vectors to 0

            if (Input.GetKey(m_forward) || Input.GetKey(m_back) || Input.GetKey(m_left) || Input.GetKey(m_right))
            {
                move = transform.right * x + transform.forward * z; //move in the direciton of x or z on a scale of -1 to 1
            }

            MovePlayer(move);
            RunCheck(); //checks of the player has inputted the assigned run key
            JumpCheck(); //checks if the player has inputted the assigned jump key
        
    }

    //MovePlayer
    void MovePlayer(Vector3 move)
    {
        m_charController.Move(move * m_finalSpeed * Time.deltaTime); //moves the Gameobject using the Character Controller

        m_velocity.y += m_gravity * Time.deltaTime; //Gravity affects the jump velocity
        m_charController.Move(m_velocity * Time.deltaTime); //Actually move the player up
    }

    //Player run
    void RunCheck()
    {
        if (Input.GetKeyDown(m_sprint)) // if the assigned key is held down, sprint
        {
            m_finalSpeed = m_movementSpeed * m_runSpeed;
        }
        else if (Input.GetKeyUp(m_sprint)) // IF the assigned key is not held down,  don't sprint
        {
            m_finalSpeed = m_movementSpeed;
        }
    }

    //Ground check
    bool HitGroundCheck()
    {
        bool isGrounded = Physics.CheckSphere(m_groundCheckPoint.position, m_groundDistance, m_groundMask); //Checks if the player is on objects assigned to the ground layer

        //Gravity
        if (isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }

        return isGrounded;
    }

    //Jump Check
    void JumpCheck()
    {
        if (Input.GetKeyDown(m_jump)) //If the jump key is pressed and the player is grounded
        {
            if (m_isGrounded == true)
            {
                m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity); //change object position
            }
        }
    }
}
