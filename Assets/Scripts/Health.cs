using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    private void Update()
    {
        Debug.Log(health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null )
        {
            takeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void takeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
