using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField,Header("エネミープレハブ")] GameObject _enemyPrefab;
    [SerializeField,Header("次にキーを押すまでのインターバル")] float _nextTapInterval = 5f;
    [SerializeField, Header("スポーンエリア")] Collider2D _spawnArea;

    /// <summary>次にキーが押せる時間</summary>
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
        if (Time.time >= _nextTapTime) //次のタップ時間を過ぎている場合
        {
            // エリア内のランダムな位置に敵を生成
            Vector2 spawnPosition = GetRandomPositionInArea();

            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

            // 次のタップ時間を更新
            _nextTapTime = Time.time + _nextTapInterval;
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
