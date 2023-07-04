using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    /// <summary>�G�̃v���n�u</summary>
    [SerializeField] GameObject _enemyPrefab;
    /// <summary>�L�[���������Ƃ̂ł���Ԋu</summary>
    [SerializeField]  float _nextTapInterval = 5;//
    /// <summary>�G�����G���A�̃R���C�_�[</summary>
    [SerializeField] Collider2D _spawnArea;
    // Start is called before the first frame update
    void Start()
    {
        _spawnArea = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // �L�[�{�[�h��1�������ꂽ�ꍇ
        {
            // �G���A���̃����_���Ȉʒu�ɓG�𐶐�
            Vector2 spawnPosition = GetRandomPositionInArea();
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            Time.timeScale = _nextTapInterval;
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
