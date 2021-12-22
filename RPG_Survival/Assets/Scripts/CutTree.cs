using System.Collections;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{
    private bool _isPressedActionButton;

    public string ActionButton = "Submit";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _isPressedActionButton = Input.GetButton(ActionButton);
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Tree" && _isPressedActionButton)
        {
            Destroy(collider.gameObject);
        }
    }
}
