﻿using UnityEngine;

public class PrefabController : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
