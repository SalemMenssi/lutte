using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerControles playerController;

    [SerializeField]
    private Transform AttackPoint;
    

    [SerializeField]
    private float attackRangeX = 2f;
    [SerializeField]
    private float attackRangeY = 0.7f;

    public LayerMask enemyLayer ;

    private PlayerManager playerManager;

    [SerializeField]
    private float moveSpeed = 5.0f;

    private InputAction move;
    private InputAction punch;
    private InputAction kick;

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

        punch = playerController.Player.Punch;
        punch.Enable();
        punch.performed += Punch;

        kick = playerController.Player.Kick;
        kick.Enable();
        kick.performed += Kick;

    }

    private void OnDisable()
    {
        move.Disable();
        punch.Disable();
        kick.Disable();
    }



    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if (moveDirection.x > 0.1f)
        {
            animator.SetBool("isWalk", true);
            transform.localScale = new Vector2(1, 1);
        }
        else if (moveDirection.x < -0.1f)
        {
            animator.SetBool("isWalk", true);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    private void Punch(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Punch");


        Collider2D hitEnemy = Physics2D.OverlapBox(AttackPoint.position, new Vector2(attackRangeX, attackRangeY), enemyLayer);

        if (hitEnemy != null)
        {
           
            GameObject Target = GameObject.Find(hitEnemy.name);
            Enemy enemy = Target.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(playerManager.player.Strength);
                Debug.Log("We hit " + enemy.name + ". Remaining health: " + enemy.Health);
            }
            else
            {
                Debug.LogWarning("Hit object does not have an Enemy component.");
            }
        }
        else
        {
            Debug.Log("No enemy hit.");
        }
    }

    private void Kick(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Kick");


        Collider2D hitEnemy = Physics2D.OverlapBox(AttackPoint.position, new Vector2(attackRangeX, attackRangeY), enemyLayer);

        if (hitEnemy != null)
        {
            Debug.Log(hitEnemy.name);
            GameObject Target = GameObject.Find(hitEnemy.name);
            Enemy enemy = Target.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(playerManager.player.Strength);
                Debug.Log("We hit " + enemy.name + ". Remaining health: " + enemy.Health);
            }
            else
            {
                Debug.LogWarning("Hit object does not have an Enemy component.");
            }
        }
        else
        {
            Debug.Log("No enemy hit.");
        }
    }
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;  
        Gizmos.DrawWireCube(AttackPoint.position, new Vector2(attackRangeX, attackRangeY)); 
    }
    

    

}