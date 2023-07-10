using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    [SerializeField] int _damage;

    Rigidbody2D _rb2d;
    Animation _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Enemy")) 
        { 
            _animator = GetComponent<Animation>();
            StartCoroutine(SwordCoroutine(1f));
        }
    }

    IEnumerator SwordCoroutine(float duration)
    {
        _animator.Play("SwordAnimation");
        yield return new WaitForSeconds(duration); // Žw’è‚µ‚½ŽžŠÔ‚¾‚¯‘Ò‹@
        _animator.Play("SwordDef");
    }
}
