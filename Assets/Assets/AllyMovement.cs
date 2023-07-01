using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _distanceToCastle = 3f;
    [SerializeField] Animator _animator = null;

    private Rigidbody2D _rb2d;
    private bool _isWalking = true;
    private GameObject _enemyCastle;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

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
    }
    void Update()
    {
        if (_isWalking && _enemyCastle != null)
        {
            float distanceToCastle = Vector2.Distance(transform.position, _enemyCastle.transform.position);

            if (distanceToCastle <= _distanceToCastle)
            {
                _rb2d.velocity = Vector2.zero;
                _isWalking = false;
            }
            else
            {
                _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
            }
        }

        _animator.SetBool("IsWalking", _isWalking);

    }
}
