using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement : MonoBehaviour
{
    [SerializeField, Header("�ړ��X�s�[�h")] float speed = 3f;
    [SerializeField, Header("����Ƃ̋���")] float stopDistance = 1.0f;
    [SerializeField, Header("�A�j���[�^�[")] Animator animator;
    [SerializeField, Header("�ő�̗�")] int _maxHealth = 100;
    [SerializeField, Header("���݂̗̑�")] int _currentHealth;
    [SerializeField, Header("�^����_���[�W")] int _damage;

    private Rigidbody2D rb2d;
    private bool isWalking = true;
    private GameObject allyCastle;
    private GameObject allyCharacter;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Walking", true);

        FindAllyCastle();
        FindAllyCharacter();
    }

    void Update()
    {
        if (isWalking)
        {
            if (allyCastle != null)
            {
                float distanceToCastle = Vector2.Distance(transform.position, allyCastle.transform.position);
                if (distanceToCastle > stopDistance)
                {
                    rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                    animator.SetBool("IsWalking", true);
                }
                else
                {
                    rb2d.velocity = Vector2.zero;
                    animator.SetBool("IsWalking", false);
                    Attack();
                }
            }

            if (allyCharacter != null)
            {
                float distanceToCharacter = Vector2.Distance(transform.position, allyCharacter.transform.position);
                if (distanceToCharacter > stopDistance)
                {
                    rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                    animator.SetBool("IsWalking", true);
                }
                else
                {
                    rb2d.velocity = Vector2.zero;
                    animator.SetBool("IsWalking", false);
                    Attack();
                }
            }
        }
    }

    void FindAllyCastle()
    {
        GameObject[] allyCastles = GameObject.FindGameObjectsWithTag("AllyCastle");
        if (allyCastles.Length > 0)
        {
            float closestDistance = Mathf.Infinity;
            foreach (GameObject castle in allyCastles)
            {
                float distance = Vector2.Distance(transform.position, castle.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    allyCastle = castle;
                }
            }
        }
        else
        {
            // �^�O "AllyCastle" �����I�u�W�F�N�g��������Ȃ������ꍇ�̏������L�q����i�Ⴆ�΃G���[���b�Z�[�W�̕\���Ȃǁj
        }
    }

    void FindAllyCharacter()
    {
        GameObject[] allyCharacters = GameObject.FindGameObjectsWithTag("Ally");
        if (allyCharacters.Length > 0)
        {
            float closestDistance = Mathf.Infinity;
            foreach (GameObject character in allyCharacters)
            {
                float distance = Vector2.Distance(transform.position, character.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    allyCharacter = character;
                }
            }
        }
        else
        {
            // �^�O "Ally" �����I�u�W�F�N�g��������Ȃ������ꍇ�̏������L�q����i�Ⴆ�΃G���[���b�Z�[�W�̕\���Ȃǁj
        }
    }

    void Attack()
    {
        // �U���̏������L�q����
    }

    public void TakeDamage()
    {
        _maxHealth -= _damage;
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
