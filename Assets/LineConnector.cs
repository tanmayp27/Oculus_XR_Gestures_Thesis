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
        if (other.tag == gameObject.tag)
        {
            Debug.Log("--------Collision Detected!!!---------");
            Debug.Log(other.gameObject);



            GameObject parent = other.transform.root.gameObject;
            Debug.Log(parent.gameObject);
            GameObject sibling = parent.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
            Debug.Log(sibling.gameObject);
            
            raycast.UpdateRayVisualization(raycast.baseObj.transform.position, sibling.transform.position, raycast.lineColor);
        }
        else{
            Debug.Log("Wrong node!");
        }

    }
}
