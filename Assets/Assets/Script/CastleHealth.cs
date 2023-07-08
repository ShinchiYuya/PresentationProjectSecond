using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    [SerializeField] float _maxHealth;
    [SerializeField] float _currentHealth;
    [SerializeField] int _damage;
    [SerializeField] AudioClip _clip;

    private Rigidbody2D _rb2d;
    

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        Slider healthSlider = GetComponent<Slider>();
        _clip = GetComponent<AudioClip>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
            if (_currentHealth <= 0)
            {
                Debug.Log("‚¨‘O‚Ì•‰‚¯`");
                Die();
            }
        }
    }

    void TakeDamage()
    {
        _currentHealth -= _damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
