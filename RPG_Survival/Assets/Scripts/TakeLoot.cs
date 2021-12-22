using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLoot : MonoBehaviour
{
    public GameObject gameObject;
    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = gameObject.GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Loot")
        {
            inventoryManager.AddItem(collision.gameObject.GetComponent<ThisItem>().item, collision.gameObject.GetComponent<ThisItem>().amount);
            Destroy(collision.gameObject);
        }
    }
}
