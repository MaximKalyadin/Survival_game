using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SettingsManager : MonoBehaviour
{
    public GameObject UIPanel;
    public bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        UIPanel.SetActive(false);
    }

    public void Awake()
    {
        UIPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            OpenSettings();
        }
    }

    public void OpenSettings()
    {
        isOpened = !isOpened;
        if (isOpened)
        {
            UIPanel.SetActive(true);
        }
        else
        {
            UIPanel.SetActive(false);
        }
    }

    public void Active(bool open)
    {
        UIPanel.SetActive(open);
        isOpened = open;
    }
    
}
