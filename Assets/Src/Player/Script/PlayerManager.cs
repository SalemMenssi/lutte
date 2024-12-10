using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Player player;

    [SerializeField]
    private HealthBar healthBar;
    private Animator animator;

    void Start()
    {
        player = new Player("Slimre");
        player.DisplayPlayerInfo();
        animator = GetComponentInChildren<Animator>();

        healthBar.SetMaxHealth(player.Health);
    }

    private IEnumerator Hitplayer()
    {
        Debug.Log("hit Player " + player.Name);
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(0.2f);
        
    }

    public void TakeDamage(float damage)
    {
        
        player.Health -= damage;
        healthBar.SetHealth(player.Health);
        
        if (player.Health <= 0)
        {
            Die();
        }
        else
        {
           StartCoroutine(Hitplayer()); 
        }
    }

    private void Die()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Die")) 
        {
            StartCoroutine(DiePlayer());
        }
    }

    private IEnumerator DiePlayer()
    {
        Debug.Log("Die " + player.Name);
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(1.1f);
        animator.SetBool("isDie", true);
    }
}
   

