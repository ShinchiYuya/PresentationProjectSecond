using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField,Header("�G�l�~�[�v���n�u")] GameObject _enemyPrefab;
    [SerializeField,Header("���ɃL�[�������܂ł̃C���^�[�o��")] float _nextTapInterval = 5f;
    [SerializeField, Header("�X�|�[���G���A")] Collider2D _spawnArea;

    /// <summary>���ɃL�[�������鎞��</summary>
    private float _nextTapTime = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        _spawnArea = GetComponent<Collider2D>();
        _nextTapTime = Time.time;
    }

    // Update is called once per frame
     void Update()
    {
        //Spawn();    
    }

    public void Spawn()
    {
        if (Time.time >= _nextTapTime) //���̃^�b�v���Ԃ��߂��Ă���ꍇ
        {
            // �G���A���̃����_���Ȉʒu�ɓG�𐶐�
            Vector2 spawnPosition = GetRandomPositionInArea();

            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

            // ���̃^�b�v���Ԃ��X�V
            _nextTapTime = Time.time + _nextTapInterval;
        }
    }

    Vector2 GetRandomPositionInArea()
    {
        // �G���A�͈͓̔��Ń����_���Ȉʒu�𐶐�
        Vector2 min = _spawnArea.bounds.min;
        Vector2 max = _spawnArea.bounds.max;
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}
