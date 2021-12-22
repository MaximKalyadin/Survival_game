using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

public class Definition
{
    // A Test behaves as an ordinary method
    [Test]
    public void AddInInventory()
    {
        GameObject gameObject = new GameObject();
        var script = gameObject.AddComponent<InventoryManager>();

        Assert.AreEqual(0, script.slots.Count());

        var item = ScriptableObject.CreateInstance("ItemScriptableObject") as ItemScriptableObject;
        item.itemName = "ffff";
        item.maximumAmount = 5;

        script.slots.Add(new InventorySlot());
        script.slots.Add(new InventorySlot());
        script.slots.Add(new InventorySlot());
        script.slots.Add(new InventorySlot());

        script.AddItem(item, 2);
        Assert.AreEqual(script.slots[0].item, item);

    }
}
