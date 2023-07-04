using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NijaFlogScript : MonoBehaviour
{
    [SerializeField, Tooltip("ƒ‚ƒu‚ÌÅ‘å‘Ì—Íİ’è")] int _maxHealth = 100;
    [SerializeField, Tooltip("Œ»İ‚Ì‘Ì—Í")] int _currentHealth;
    [SerializeField] int _damage = 10;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            FirstEnemyScript enemy = collision.GetComponent<FirstEnemyScript>();

            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
        }
    }

    public void TakeDamage()
    {
        _maxHealth -= _damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
