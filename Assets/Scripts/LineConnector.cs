using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

enum nodeColor
{
    Red,
    Blue,
    Yellow
}

public class LineConnector : MonoBehaviour
{
    [SerializeField] private DrawRaycast raycast;

    //[SerializeField] private nodeColor color;

    private int colorNodeConnected=0;

    private GameLogic gameLogic;

    private GameObject parent;
    private GameObject sibling;

    private bool lineConnected = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.Find("GameManager");
        if (manager != null)
        {
            gameLogic = manager.GetComponent<GameLogic>();
        }
        else
        {
            Debug.LogWarning("Manager NOT Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lineConnected && parent!=null && sibling!=null) 
        {
            raycast.UpdateRayVisualization(sibling.transform.position, raycast.baseObj.transform.position, raycast.lineColor);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        lineConnected = false;
        if (other.tag == gameObject.tag)
        {
            Debug.Log("--------Collision Detected!!!---------");
            //Debug.Log(other.gameObject);



            parent = FindParentWithTag(other.gameObject, other.tag);
            //Debug.Log(parent.gameObject);
            sibling = parent.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
            //Debug.Log(sibling.gameObject);
            
            //raycast.UpdateRayVisualization(sibling.transform.position, raycast.baseObj.transform.position, raycast.lineColor); Called in update now

            lineConnected = true;
            colorNodeConnected++;

            if(colorNodeConnected == 2)
            {
                gameLogic.CircuitConnected(true);
                colorNodeConnected = 0;
            }
            
        }
        else{
            gameLogic.CircuitConnected(false);
        }

    }

    public static GameObject FindParentWithTag(GameObject childObject, string tag)
    {
        Transform t = childObject.transform;
        while (t.parent != null || t.parent.name=="Nodes")
        {
            if (t.parent.tag == tag)
            {
                Debug.Log(t.parent.gameObject + "Found");
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }
        Debug.Log("No Parent with same tag found!");
        return null; // Could not find a parent with given tag.
    }
}
