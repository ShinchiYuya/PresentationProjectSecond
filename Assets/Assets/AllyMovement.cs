using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float attackRange = 1.5f;
    [SerializeField] float attackSpeed = 1.5f;
    [SerializeField] Animator _animator = null;
    [SerializeField] Transform _muzzle = null;

    private Rigidbody2D rb2d;
    private bool _isWalking = true;
    private bool _isAttacking = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_isWalking)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    }
}
