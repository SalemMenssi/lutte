using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private PlayerControles playerController;

    private PlayerManager playerManager;

    [SerializeField]
    private float moveSpeed = 5.0f;

    private InputAction move;
    private InputAction attack;

    private Rigidbody2D rb;
    private Animator animator;

    Vector2 moveDirection = Vector2.zero;
    private void Awake()
    {
        playerController = new PlayerControles();
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }


    private void OnEnable()
    {
        move = playerController.Player.Move;
        move.Enable();

        attack = playerController.Player.Fire;
        attack.Enable();
        attack.performed += Attack;
    }

    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
    }

   
    
    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
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

    private void Attack(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Punch");
        playerManager.performAttack();
    }

}
