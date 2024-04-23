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

    
    //[SerializeField] private Color rayColor;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        originPos = origin.transform.position;
        corePos= core.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckRayHit();
        
    }

    private void CheckRayHit()
    {
        if(Physics.Raycast(originPos, -origin.forward, out RaycastHit hit, Mathf.Infinity, targetLayer))
        {
            //Debug.Log(hit.transform.gameObject);
            if (hit.point != null)
            {
                hitObjectPos = hit.point;

            }
            else
                hitObjectPos = corePos;
            
        }
        UpdateRayVisualization(originPos, hitObjectPos);
        
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

    private void ResetLine()
    {
        if(lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
        }
    }
}
