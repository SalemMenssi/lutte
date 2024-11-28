using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private InputAction playerController;
    [SerializeField]
    private InputAction Attack;

    [SerializeField]
    private float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Animator animator;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    
    private void Update()
    {
        moveDirection = playerController.ReadValue<Vector2>();
        if (moveDirection.x > 0.1f)
        {
            animator.SetBool("IsRunning", true);
            transform.localScale = new Vector2(1, 1);
        }
        else if (moveDirection.x < -0.1f)
        {
            animator.SetBool("IsRunning", true);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

}
