﻿using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private int amount = 10;
    private bool populateOnStart = true;
    private bool growOverAmount = true;

    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        if (populateOnStart && prefab != null && amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(prefab,transform);
                instance.SetActive(false);
                pool.Add(instance);
            }
        }
    }

    public GameObject UnitInstantiate(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].transform.position = position;
                pool[i].transform.rotation = rotation;
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        if (growOverAmount)
        {
            var instance = Instantiate(prefab, position, rotation,transform);
            pool.Add(instance);
            return instance;
        }

        return null;
    }
}
