using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Walk_satate : StateMachineBehaviour
{
     Transform player;
     Rigidbody2D rb;
    Enemy enemy;
     public float speed = 5f;
     public float attackRange = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = animator.GetComponentInParent<Enemy>();
        rb = animator.GetComponentInParent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemy.lookAtPlayer();
        Vector2 Target = new Vector2(player.position.x,rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, Target, Time.fixedDeltaTime * speed );
        rb.MovePosition(newPos);

        if(player.GetComponent<PlayerManager>().player.Health > 0)
        {
            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                int attackType = Random.Range(0, 2);
                if (attackType == 0)
                {
                    animator.SetTrigger("Punch");
                }
                else
                {
                    animator.SetTrigger("Kick");
                }
            }
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Punch");
        animator.ResetTrigger("Kick");
    }

    
}
