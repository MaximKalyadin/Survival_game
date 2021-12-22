using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMechanism : MonoBehaviour
{
    private bool _keyPressed;
    private float _time;
    private bool _actionInProcess;

    private ZoneChanging _zoneScriptForCurrentMechanism;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > 0f)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            if (_keyPressed && _time <= 0)
            {
                _keyPressed = false;
                _actionInProcess = true;
                _time = 0.5f;
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Mechanism" && _actionInProcess)
        {
            if(_zoneScriptForCurrentMechanism == null) 
                _zoneScriptForCurrentMechanism = collider.gameObject.GetComponentInChildren<ZoneChanging>();

            _zoneScriptForCurrentMechanism.Increase();

            _actionInProcess = false;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Mechanism")
        {
            _actionInProcess = false;
            _zoneScriptForCurrentMechanism = null;
        }
    }

    public void SetKeyPressed() => _keyPressed = true;
}
