using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 1.1f;
    public LayerMask groundLayer;

    [Header("Mouse Look Settings")]
    public Transform cameraTransform;      
    public float mouseSensitivity = 100f;
    public float maxLookAngle = 90f;
    //public Animator CamAnim;

    private float xRotation = 0f;


    private Rigidbody rb;
    private Vector3 inputDirection;
    private bool isInit;

    public void Init()

    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //CamAnim.SetTrigger("Fly");
        isInit = true;
    }

    void Update()
    {
        if (isInit == false)
            return;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        inputDirection = move.normalized;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        if (isInit == false)
            return;
        Vector3 velocity = inputDirection * moveSpeed;
        Vector3 targetVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        rb.linearVelocity = targetVelocity;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}
