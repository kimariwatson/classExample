using UnityEngine;
using UnityEngine.InputSystem;

public class ClassBirdScript : MonoBehaviour
{

    public SpriteRenderer sprite;
    public Rigidbody2D myRigidbody;
    public float flapping;

    private InputSystem_Actions controls;

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        //whenvere the Jump action is performed (when the spacebar button is pressed), the OnJump function is called. 
        //since the .performed is a event not a value, that's why the OnJump function isn't assigned, instead it is 
        controls.Player.Enable();
        controls.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        controls.Player.Jump.performed -= OnJump;
        controls.Player.Disable();
    }

    private void Start()
    {
        myRigidbody.simulated = false;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        //

        if (myRigidbody.simulated == false)
        {
            myRigidbody.simulated = true;
        }

        Debug.Log("Button is pressed!");
        myRigidbody.linearVelocity = Vector2.up * flapping;

        if (sprite.color == Color.blue)
        {
            sprite.color = Color.cyan;
        }
        else
        {
            sprite.color = Color.blue;
        }
    }
}
