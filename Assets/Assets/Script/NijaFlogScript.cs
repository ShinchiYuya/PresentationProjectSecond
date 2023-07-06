
using UnityEngine;

public class NijaFlogScript : AllyBasicMovement
{
    Animation _animation;

    void Start()
    {
        _speed = 5f;
        _stopDistance = 1;
        _damage = 10;
        _maxHealth = 50;
        Rigidbody2D _rb2d;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Enemy"))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        _animation = GetComponent<Animation>();
        _animation.Play("Attack");
    }
}
