using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBasicMovement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _stopDistance = 1.0f;
    [SerializeField] Animator _animator;
    [SerializeField, Tooltip("���u�̍ő�̗͐ݒ�")] int _maxHealth = 100;
    [SerializeField, Tooltip("���݂̗̑�")] int _currentHealth;

    private Rigidbody2D _rb2d;
    private bool _isWalking = true;
    private GameObject _enemyCastle;
    private GameObject _enemyCharacter;
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("Walking", true);

        FindEnemyCastle();
        FindEnemyCharacter();
    }
    void Update()
    {
        if (_isWalking)
        {
            if (_enemyCastle != null)
            {
                float distanceToCastle = Vector2.Distance(transform.position, _enemyCastle.transform.position);
                if (distanceToCastle > _stopDistance)
                {
                    _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
                    _animator.SetBool("IsWalking", true);
                }
                else
                {
                    _rb2d.velocity = Vector2.zero;
                    _animator.SetBool("IsWalking", false);
                    Attack();
                }
            }
            if (_enemyCharacter != null)
            {
                float distanceToCharacter = Vector2.Distance(transform.position, _enemyCharacter.transform.position);
                if (distanceToCharacter > _stopDistance)
                {
                    _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
                    _animator.SetBool("IsWalking", true);
                }
                else
                {
                    _rb2d.velocity = Vector2.zero;
                    _animator.SetBool("IsWalking", false);
                    Attack();
                }
            }
        }
    }
    void FindEnemyCastle()
    {
        GameObject[] enemyCastles = GameObject.FindGameObjectsWithTag("EnemyCastle");
        if (enemyCastles.Length > 0)
        {
            float closestDistance = Mathf.Infinity;
            foreach (GameObject castle in enemyCastles)
            {
                float distance = Vector2.Distance(transform.position, castle.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _enemyCastle = castle;
                }
            }
        }
        else
        {
            // �^�O "EnemyCastle" �����I�u�W�F�N�g��������Ȃ������ꍇ�̏������L�q����i�Ⴆ�΃G���[���b�Z�[�W�̕\���Ȃǁj
        }
    }
    void FindEnemyCharacter()
    {
        GameObject[] enemyCharacters = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyCharacters.Length > 0)
        {
            float closestDistance = Mathf.Infinity;
            foreach (GameObject character in enemyCharacters)
            {
                float distance = Vector2.Distance(transform.position, character.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _enemyCharacter = character;
                }
            }
        }
        else
        {
            // �^�O "Enemy" �����I�u�W�F�N�g��������Ȃ������ꍇ�̏������L�q����i�Ⴆ�΃G���[���b�Z�[�W�̕\���Ȃǁj
        }
    }
    void Attack()
    {
        // �U���̏������L�q����

    }

    void TakeDamage()
    {
        _maxHealth -= damage;
        if (_currentHealth > 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
