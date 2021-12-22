using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    private static System.Random _random = new System.Random();
    private Transform _currentGameObjectTransform;

    public GameObject lootGameObject;
    
    void Start()
    {
        _currentGameObjectTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        for (var i = 0; i < _random.Next(0, 4); i++)
            Instantiate(lootGameObject, _currentGameObjectTransform.position + CalculateLootOffset(), _currentGameObjectTransform.rotation);
    }

    Vector3 CalculateLootOffset() => new Vector3(_random.Next(-20, 21) / 6, 0, _random.Next(-20, 21) / 6);
}
