using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LineConnector : MonoBehaviour
{
    [SerializeField] private DrawRaycast raycast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Red")
        {
            GameObject parent = other.transform.root.gameObject;
            GameObject sibling = parent.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
            Debug.Log("--------Collision Detected!!!---------");
            raycast.UpdateRayVisualization(raycast.baseObj.transform.position, sibling.transform.position, raycast.lineColor);
        }

    }
}
