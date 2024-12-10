using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private Transform player;
    private bool isFlipped = false;
    public string Name;
    public float Health;
    public float Strength;
    public float Agility;
    public float Stamina;
    public float Defense;

    
    private HealthBar healthBar;
    private Animator animator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        healthBar = GameObject.Find("Enemy Score").GetComponentInChildren<HealthBar>();
    }

    
    public void InitializeEnemy(string name)
    {
        Name = name;
        Health = Random.Range(50f, 150f);
        Strength = Random.Range(5f, 15f);
        Agility = Random.Range(5f, 15f);
        Stamina = Random.Range(5f, 15f);
        Defense = Random.Range(5f, 15f);

        gameObject.name = Name;
        healthBar.SetMaxHealth(Health);
    }

    public void lookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped) 
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void DisplayEnemyInfo()
    {
        Debug.Log($"Enemy Name: {Name}, Health: {Health}, Strength: {Strength}, Agility: {Agility}, Defense: {Defense}");
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        healthBar.SetHealth(Health);
        

        if (Health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Hitplayer());
        }
    }

    private IEnumerator Hitplayer()
    {
        Debug.Log("hit " + Name);
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(0.2f);

    }
    private void Die()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            StartCoroutine(DieEnemie());
        }
    }

    private IEnumerator DieEnemie()
    {
        Debug.Log("Die " + Name);
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(1.1f);
        
    }
}
