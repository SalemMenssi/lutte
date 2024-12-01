using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Player player;
    [SerializeField]
    private GameObject hitbox;




    void Start()
    {
        player = new Player("Slimre");
        player.DisplayPlayerInfo();
    }

    public void performAttack()
    {
        StartCoroutine(EnableHitbox());
    }

    private IEnumerator EnableHitbox()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        hitbox.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hurtbox")) 
        {
            PlayerManager enemy = other.GetComponent<PlayerManager>();
            if (enemy != null)
            {
                enemy.player.TakeDamege(player.Strength);
            }
        }
    }
}
