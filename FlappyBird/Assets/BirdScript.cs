using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    //public GameObject spawner;
    public Rigidbody2D myRigidbody;
    public InputSystem_Actions controls;
    public float flappingValue;
    public int playerNumber;
    public LogicScript logic;
    public bool stillAlive;

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player2.Enable();

        if (playerNumber == 0)
        {
            controls.Player.Jump.performed += OnJump;
        }
        else if (playerNumber == 1) 
        {
            controls.Player2.Jump.performed += OnJump;
        }
    }
        

    private void OnDisable()
    {
        if (playerNumber == 0)
        {
            controls.Player.Jump.performed -= OnJump;
        }
        else if (playerNumber == 1)
        {
            controls.Player2.Jump.performed -= OnJump;
        }
        
        controls.Player.Disable();
        controls.Player2.Disable();
       
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        //if (!spawner.activeSelf)
        //{
        //    spawner.SetActive(true);
        //}
        if (myRigidbody.simulated==false) 
            {
                myRigidbody.simulated = true;
            }
        myRigidbody.linearVelocity = Vector2.up*flappingValue;
    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody.simulated = false;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //spawner.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 3)
        {
            stillAlive = false;
            OnDisable();

            logic.playerDied(playerNumber);
        }
    }
}
