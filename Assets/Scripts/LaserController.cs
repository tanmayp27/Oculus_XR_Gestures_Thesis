using Meta.XR.Editor.Tags;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

/* enum Axes
{
    Right,
    Up,
    Forward
} */

[RequireComponent(typeof(LineRenderer))]
public class LaserController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform origin;
    [SerializeField] private Transform core;
    [SerializeField] private LayerMask targetLayer;
    
    //[SerializeField] private Axes axis;

    private Vector3 originPos;
    private Vector3 hitObjectPos;
    private Vector3 corePos;

    int LayerIgnoreRaycast;
    int OriginalLayer;


    int i=0;

    private GameObject HolePassed;
    //private GameObject previousCollision=null;
    // Wizard of OZ lol


    //[SerializeField] private GameObject Mantle;
    //[SerializeField] private GameObject OuterCore;
    // [SerializeField] private GameObject Core;

    //[SerializeField] private Color rayColor;
    // Start is called before the first frame update
    void Start()
    {
        LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        OriginalLayer = LayerMask.NameToLayer("Interactable");
        lineRenderer = GetComponent<LineRenderer>();
        originPos = origin.transform.position;
        corePos= core.transform.position;

        //Debug.Log(corePos);
    }

    // Update is called once per frame
    void Update()
    {
        CheckRayHit();
        //UpdateRayVisualization(originPos, corePos);


    }


    private void CheckRayHit()
    {
        Ray ray = new Ray(originPos, corePos - originPos);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, targetLayer))
        {

            //Debug.Log(hit.transform.gameObject);
            if (hit.point != null && hit.collider.transform.gameObject.tag == "Gear")
            {
                //Debug.Log("Ray is blocked");
                hitObjectPos = hit.point;
                if(HolePassed!= null)
                {
                    HolePassed.layer = OriginalLayer;
                }
                


            }
            else if (CheckMultipleCollisions(hit.collider.gameObject, "Hole", 3))
            {
                hitObjectPos = corePos;

                //Debug.Log(hitObjectPos);
            }

            /* if (hitObjectPos == null)
            {
                hitObjectPos=corePos;
            } */
            
        }
        UpdateRayVisualization(originPos, hitObjectPos);
        
    }

    private bool CheckMultipleCollisions(GameObject hitObject, Tag targetTag, int noOfCollisions)
    {
        
        while (i < noOfCollisions)
        {
            
            if (hitObject.tag == targetTag)
            {
                i++;
                
            }
            else
            {
                return false;
            }
            hitObject.layer = LayerIgnoreRaycast;
            HolePassed = hitObject;
        }
        i = 0;
        return true;
    }


    private void UpdateRayVisualization(Vector3 startPosition, Vector3 endPosition)
    {
        
        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            //lineRenderer.material.color = hitSomething ? Color.green : Color.red;
        }
        else if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
        }
    }

    


}
