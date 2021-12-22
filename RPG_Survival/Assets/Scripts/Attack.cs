using System.Collections;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _keyPressed;
    private bool _actionInProcess;
    private float _time; //delay 

    // Start is called before the first frame update
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

        if (_keyPressed && _time <= 0)
        {
            _keyPressed = false;
            _actionInProcess = true;
            _time = 1f;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if ((collider.tag == "Tree" || collider.tag == "Box") && _actionInProcess)
        {
            collider.gameObject.GetComponent<ThisDestructibleItem>().ReduceHealthPoints(10);
            _actionInProcess = false;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        _actionInProcess = false;
    }

    public void SetKeyPressed() => _keyPressed = true;
}
