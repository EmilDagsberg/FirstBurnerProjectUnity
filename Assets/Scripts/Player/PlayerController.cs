using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpHeight = 4f;
    [SerializeField] private float sprintSpeed = 20f;

    private Rigidbody rb;
    private bool isGrounded = false;

    private PlayerInputActions inputActions;


    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    // Update is called once per frame
    void Update()
    {

        Debug.Log($"Player is grounded : {isGrounded}");

        bool isSprinting = inputActions.Player.Sprint.IsPressed();
        float currentSpeed = isSprinting ? sprintSpeed : movementSpeed;

        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3 (input.x, 0 , input.y);

        rb.linearVelocity = new Vector3(moveDirection.x * currentSpeed, rb.linearVelocity.y, moveDirection.z * currentSpeed);

        if (inputActions.Player.Jump.WasPerformedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        isGrounded = false;
    }

}
