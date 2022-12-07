using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public GameObject Coin;

    public GameObject Bird1;

    public GameObject Bird2;

    public GameObject Bird3;

    public Image menu;
    private RectTransform rectTransform;

    public int spawnMax = 10;

    public int spawned = 0;

    //Enemy Spawn Logic
    public float lastSpawnTime = 0;

    public float SpawnInterval = 5;

    //Item Spawn Logic

    public float lastItemSpawnTime = 0;

    public float ItemSpawnInterval = 2;

    private List<GameObject> spawnList = new List<GameObject>();

    public float FreeRadius = 10;

    void Start()
    {
        rectTransform = menu.GetComponent<RectTransform>();
    }

    void Update()
    {
        //Enemy Spawning
        if (LevelManager.CurrentLevel == 1)
        {
            spawnList.Add(Bird1);
        }
        else if (LevelManager.CurrentLevel == 2)
        {
            spawnList.Add(Bird2);
        }
        else if (LevelManager.CurrentLevel == 3)
        {
            spawnList.Add(Bird3);
        }


        if (spawned < spawnMax)
        {
            if (Time.time > lastSpawnTime)
            {
                Instantiate(spawnList[Random.Range(0, spawnList.Count)], SpawnUtilities.RandomFreePoint(FreeRadius), Quaternion.identity);

                lastSpawnTime += SpawnInterval;

                spawned += 1;
            }
        }
        else
        {
            Time.timeScale = 0.0f;
            rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
            LevelManager.NextLevel();
            spawned = 0;
            spawnMax += 10;
        }

        //Power Up Spawning

        if (Time.time > lastItemSpawnTime)
        {
            Instantiate(Coin, SpawnUtilities.RandomFreePoint(FreeRadius), Quaternion.identity);

            lastItemSpawnTime += ItemSpawnInterval;
        }
    }
}
