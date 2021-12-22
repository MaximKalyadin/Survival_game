using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIBG;
    public Transform inventoryPanel;
    public Transform quickPanel;
    public List<InventorySlot> quickSlots = new List<InventorySlot>();
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;

    private bool isArmor;
    private bool isHelmet;
    private bool isWeapon;
    private HealthPointsManager _healthPointsManager;

    public void Awake()
    {
        UIBG.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        for (int i = 0; i < quickPanel.childCount; i++)
        {
            if (quickPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                quickSlots.Add(quickPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIBG.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);
        _healthPointsManager = GetComponent<HealthPointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
        ChangeItem();
    }

    public void ChangeItem()
    {
        // если я все правильно понимаю как делать надо
        if (quickSlots[0] != null && !isArmor)
        {
            isArmor = true;
            // какая-то переменная для уменьшения уровня дмага по челу *= ((100 - quickSlots[0].item.armor) / 100);
        }
        else
        {
            isArmor = false;
        }
        if (quickSlots[1] != null &&  !isHelmet)
        {
            isHelmet = true;
            // какая-то переменная для уменьшения уровня дмага по челу *= ((100 - quickSlots[1].item.armor) / 100);
        }
        else
        {
            isHelmet = false;
        }
        if (quickSlots[2] != null && !isWeapon)
        {
            isWeapon = true;
            // переменная для увеличения дамага по деревьям *= ((100 - quickSlots[2].item.Damage) / 100);
        }
        else
        {
            isWeapon = false;
        }
    }

    public void OpenInventory()
    {
        isOpened = !isOpened;
        if (isOpened)
        {
            UIBG.SetActive(true);
            inventoryPanel.gameObject.SetActive(true);
        }
        else
        {
            inventoryPanel.gameObject.SetActive(false);
            UIBG.SetActive(false);
        }
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }

    public void UseItemHeel()
    {
        if (quickSlots[3] != null)
        {
            _healthPointsManager.AddHealthPoints((quickSlots[3].item as FoodItem).healAmounth); // переменная для увеличения жизни += quickSlots[3].item.healAmounth;
            quickSlots[3].item = null;
            quickSlots[3].amount = 0;
            quickSlots[3].isEmpty = true;
            quickSlots[3].iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            quickSlots[3].iconGO.GetComponent<Image>().sprite = null;
            quickSlots[3].itemAmountText.text = "";
        }
    }
}
