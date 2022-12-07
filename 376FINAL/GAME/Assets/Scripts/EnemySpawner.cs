using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float timer = 2.0f;
    private float x_pos;
    private float y_pos;
    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer();
        //enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Vector3 n_position = new Vector3(x_pos, y_pos, 15);
        if (timer <= 0.0f)
        {
            Instantiate(enemy, n_position, Quaternion.identity);
            ResetSpawnTimer();
        }
    }

    void ResetSpawnTimer()
    {
        timer = 2.0f;
        x_pos = Random.Range(-10.0f, 10.0f);
        y_pos = Random.Range(-4.0f, 7.0f);
    }
}
