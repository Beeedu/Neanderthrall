using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    private static Director instance;

    [SerializeField]
    private GameObject pfEnemy;

    private float spawnInterval = 1f;

    private int entityCount = 0;

    private readonly Queue<Action> spawnQueue = new Queue<Action>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        ActionTimer.Create(() =>
        {
            if (spawnQueue.Count > 0)
            {
                spawnQueue.Dequeue()();
            }
        }, spawnInterval);
    }

    private void Update()
    {
        if (!IsQuotaMet())
        {
            spawnQueue.Enqueue(InstantiateEnemy);
        }
    }

    private bool IsQuotaMet()
    {
        return (this.entityCount + spawnQueue.Count >= CalculateQuota());
    }

    private int CalculateQuota()
    {
        float time = GameManager.instance.GetClockTime();
        Debug.Log("Power: " + Mathf.Pow(time, 1.5f));
        float quota = (1f / 50f) * Mathf.Pow(time, 1.5f) + 5;
        Debug.Log("Quota: " + quota);
        return Mathf.RoundToInt(quota);
    }

    private void InstantiateEnemy()
    {
        Vector3 GenerateSpawnLocation()
        {
            float cameraSize = 10f + 2.5f; // TODO: Use camera reference + buffer
            float spawnRadius = Mathf.Sqrt(Mathf.Pow(cameraSize, 2) + Mathf.Pow((16 / 9) * cameraSize, 2));

            float randomDegree = UnityEngine.Random.value * 360;

            Vector3 playerPosition = GameManager.instance.GetPlayer().transform.position;

            float x = Mathf.Cos(randomDegree) * spawnRadius + playerPosition.x;
            float y = Mathf.Sin(randomDegree) * spawnRadius + playerPosition.y;

            return new Vector3(x, y);
        }

        DirectorEntity newEnemy = Instantiate(this.pfEnemy, GenerateSpawnLocation(), Quaternion.identity).AddComponent<DirectorEntity>();
        newEnemy.transform.parent = this.transform;
    }

    private void IncrementEntityCount()
    {
        this.entityCount++;
    }

    private void DecrementEntityCount()
    {
        this.entityCount--;
    }

    class DirectorEntity : MonoBehaviour
    {
        private void Awake()
        {
            Director.instance.IncrementEntityCount();
        }

        private void OnDestroy()
        {
            Director.instance.DecrementEntityCount();
        }
    }
}
