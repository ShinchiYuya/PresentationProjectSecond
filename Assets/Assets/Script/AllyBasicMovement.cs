using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AllyBasicMovement : MonoBehaviour
{
    [SerializeField, Header("�ړ��X�s�[�h")] protected float _speed = 3f;
    [SerializeField, Header("����Ƃ̋���")] protected float _stopDistance = 1.0f;
    [SerializeField, Header("�A�j���[�^�[")] Animator _animator;
    [SerializeField, Header("�ő�̗�")] protected int _maxHealth;
    [SerializeField, Header("���݂̗̑�")] protected int _currentHealth;
    [SerializeField, Header("�^����_���[�W")] protected int _damage;

    private Rigidbody2D _rb2d;
    private bool _isWalking = true;
    private GameObject _enemyCastle;
    private GameObject _enemyCharacter;
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("FlogDef", true);

        FindEnemyCastle();
        FindEnemyCharacter();
    }
    protected void Update()
    {
        if (_isWalking)
        {
            if (_enemyCastle != null)
            {
                float distanceToCastle = Vector2.Distance(transform.position, _enemyCastle.transform.position);
                if (distanceToCastle > _stopDistance)
                {
                    _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
                    _animator.Play("FlogDef");
                }
                else
                {
                    _rb2d.velocity = Vector2.zero;
                    _animator.Play("Attack");
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
    protected void FindEnemyCastle()
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
            // �^�O "EnemyCastle" �����I�u�W�F�N�g��������Ȃ������ꍇ�̏������L�q����i�Ⴆ�΃G���[���b�Z�[�W�̕\���Ȃ�)
            Debug.Log("EnemyCastle�̃^�O�������Ă�����񂼂�");
        }
    }
    protected void FindEnemyCharacter()
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
            Debug.Log("�G�����Ȃ���[��");
        }
    }
    public abstract void Attack();

    protected void TakeDamage()
    {
        _maxHealth -= _damage;
        StartCoroutine(DamageCoroutine(1f));

        if (_currentHealth > 0)
        {
            Die();
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(DamageCoroutine(1f));
            TakeDamage();
        }
    }

    protected IEnumerator DamageCoroutine(float duration)
    {
        _animator.Play("DamageRed");
        yield return new WaitForSeconds(duration); // �w�肵�����Ԃ����ҋ@
        _animator.Play("FlogAnimation");
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
