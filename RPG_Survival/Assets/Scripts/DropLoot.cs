using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        for (var i = 0; i < _random.Next(1, 4); i++)
        {
            try
            {
                int type = _random.Next(1, 5);
                if (type == 1)
                {
                    var item = Instantiate(lootGameObject, _currentGameObjectTransform.position + CalculateLootOffset(), _currentGameObjectTransform.rotation);
                    var thisItem = item.GetComponent<ThisItem>();
                    thisItem.item = (FoodItem)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Apple.asset", typeof(FoodItem));
                    thisItem.amount = 1;
                }
                if (type == 2)
                {
                    var item = Instantiate(lootGameObject, _currentGameObjectTransform.position + CalculateLootOffset(), _currentGameObjectTransform.rotation);
                    var thisItem = item.GetComponent<ThisItem>();
                    thisItem.item = (PlantItem)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Plant_Item.asset", typeof(PlantItem));
                    thisItem.amount = 1;
                }
                if (type == 3)
                {
                    var item = Instantiate(lootGameObject, _currentGameObjectTransform.position + CalculateLootOffset(), _currentGameObjectTransform.rotation);
                    var thisItem = item.GetComponent<ThisItem>();
                    thisItem.item = (WeaponItem)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Weapon_Item.asset", typeof(WeaponItem));
                    thisItem.amount = 1;
                }
                if (type == 4)
                {
                    var item = Instantiate(lootGameObject, _currentGameObjectTransform.position + CalculateLootOffset(), _currentGameObjectTransform.rotation);
                    var thisItem = item.GetComponent<ThisItem>();
                    thisItem.item = (ArmorItem)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Sheet.asset", typeof(ArmorItem));
                    thisItem.amount = 1;
                }
            } catch (Exception ex) { }
        }
    }

    Vector3 CalculateLootOffset() => new Vector3(_random.Next(-20, 21) / 6, 0, _random.Next(-20, 21) / 6);
}
