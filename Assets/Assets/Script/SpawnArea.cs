using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject enemyPrefab; // �G�̃v���n�u
    public float spawnInterval = 2f; // �G�̐����Ԋu
    private Collider2D spawnArea; // �G�����G���A�̃R���C�_�[
    // Start is called before the first frame update
    void Start()
    {
        spawnArea = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // �L�[�{�[�h��1�������ꂽ�ꍇ
        {
            // �G���A���̃����_���Ȉʒu�ɓG�𐶐�
            Vector2 spawnPosition = GetRandomPositionInArea();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector2 GetRandomPositionInArea()
    {
        // �G���A�͈͓̔��Ń����_���Ȉʒu�𐶐�
        Vector2 min = spawnArea.bounds.min;
        Vector2 max = spawnArea.bounds.max;
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        return new Vector2(randomX, randomY);
    }
}
