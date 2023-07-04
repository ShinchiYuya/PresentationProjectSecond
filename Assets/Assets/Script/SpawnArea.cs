using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵のプレハブ
    public float spawnInterval = 2f; // 敵の生成間隔
    private Collider2D spawnArea; // 敵生成エリアのコライダー
    // Start is called before the first frame update
    void Start()
    {
        spawnArea = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // キーボードの1が押された場合
        {
            // エリア内のランダムな位置に敵を生成
            Vector2 spawnPosition = GetRandomPositionInArea();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector2 GetRandomPositionInArea()
    {
        // エリアの範囲内でランダムな位置を生成
        Vector2 min = spawnArea.bounds.min;
        Vector2 max = spawnArea.bounds.max;
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}
