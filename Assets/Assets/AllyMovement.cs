using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float attackRange = 5f;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform muzzle = null;
    [SerializeField] Animator animator = null;

    Rigidbody2D _rb2d;
    bool isAttacking = false;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        _rb2d.velocity = movement * moveSpeed;

        if (movement.magnitude > 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        while (isAttacking)
        {
            // ìGÇÃåüèo
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    // ìGÇ™îÕàÕì‡Ç…Ç¢ÇÈèÍçáÇÕçUåÇÇ∑ÇÈ
                    GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
                    Destroy(bullet, 3f);
                }
            }

            yield return new WaitForSeconds(1f); // 1ïbÇ≤Ç∆Ç…çUåÇÇåJÇËï‘Ç∑
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
