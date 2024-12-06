using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string Name;
    public float Health;
    public float Strength;
    public float Agility;
    public float Stamina;
    public float Defense;

    public void InitializeEnemy(string name)
    {
        Name = name;
        Health = Random.Range(50f, 150f);
        Strength = Random.Range(5f, 15f);
        Agility = Random.Range(5f, 15f);
        Stamina = Random.Range(5f, 15f);
        Defense = Random.Range(5f, 15f);

        gameObject.name = Name;
    }

    public void DisplayEnemyInfo()
    {
        Debug.Log($"Enemy Name: {Name}, Health: {Health}, Strength: {Strength}, Agility: {Agility}, Defense: {Defense}");
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log($"{Name} took {damage} damage. Remaining health: {Health}");

        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{Name} has been defeated.");
    }
}
