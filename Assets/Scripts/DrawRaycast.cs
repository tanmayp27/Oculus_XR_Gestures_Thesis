using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawRaycast : MonoBehaviour
{
    [SerializeField] public GameObject baseObj;
    [SerializeField] private GameObject heldObj;

    [SerializeField] public Color lineColor;

    private LineRenderer lineRenderer;

     [HideInInspector] public MeshRenderer renderer;


    private bool isGrabbed=false;
    //private Renderer _currentRenderer;
    //[SerializeField] private LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        //renderer= heldObj.GetComponent<MeshRenderer>();
    }

    void Update() => CreateLine();


    private void CreateLine()
    {
        if(isGrabbed)
        {
           
        UpdateRayVisualization(baseObj.transform.position, heldObj.transform.position, heldObj.GetComponent<MeshRenderer>().material.color);

            heldObj.GetComponent<MeshRenderer>().enabled = false;     
        }
        else 
            heldObj.GetComponent<MeshRenderer>().enabled = true;
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

    public void UpdateRayVisualization(Vector3 startPosition, Vector3 endPosition, Color lineColor)
    {
        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            lineRenderer.material.color = lineColor;
        }
        
    }

   
}
