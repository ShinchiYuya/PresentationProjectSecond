using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    /// <summary>敵のプレハブ</summary>
    [SerializeField] GameObject _enemyPrefab;
    /// <summary>キーを押すことのできる間隔</summary>
    [SerializeField]  float _nextTapInterval = 5;//
    /// <summary>敵生成エリアのコライダー</summary>
    [SerializeField] Collider2D _spawnArea;
    // Start is called before the first frame update
    void Start()
    {
        _spawnArea = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // キーボードの1が押された場合
        {
            // エリア内のランダムな位置に敵を生成
            Vector2 spawnPosition = GetRandomPositionInArea();
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            Time.timeScale = _nextTapInterval;
        }
    }

    Vector2 GetRandomPositionInArea()
    {
        // エリアの範囲内でランダムな位置を生成
        Vector2 min = _spawnArea.bounds.min;
        Vector2 max = _spawnArea.bounds.max;
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}
