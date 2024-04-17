using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRaycast : MonoBehaviour
{
    [SerializeField] private GameObject baseObj;
    [SerializeField] private GameObject heldObj;
    [SerializeField] Color lineColor;

    [SerializeField] private LineRenderer lineRenderer;

    private bool isGrabbed=false;
    //[SerializeField] private LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() => CreateLine();


    private void CreateLine()
    {
        if(isGrabbed)
        {
        lineRenderer.enabled=true;
        lineRenderer.SetPosition(0, baseObj.transform.position);
        lineRenderer.SetPosition(1, heldObj.transform.position);

        heldObj.GetComponent<MeshRenderer>().enabled=false;

        lineRenderer.material.color= lineColor;
        }
        else
            heldObj.GetComponent<MeshRenderer>().enabled=true;
    }
    

    public void ObjectGrabbed(){
        
        if(!isGrabbed){
            isGrabbed=true;
        }
    }

    public void ObjectReleased(){

        if(isGrabbed){
            isGrabbed=false;
        }
    }

}
