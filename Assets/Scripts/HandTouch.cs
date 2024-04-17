using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTouch : MonoBehaviour
{
    public OVRHand rightHand;
    public GameObject CurrentTarget { get; private set; }

    [SerializeField] public bool showRaycast = false;

    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LineRenderer lineRenderer;
    //[SerializeField] private HandFinger starPosJoint;

    private Color _originalColor;
    private Color _highlightColor;
    private Renderer _currentRenderer;
    private CheckPinch pinch;



    // Update is called once per frame
    public void HandTouched(GameObject obj)
    {
        while (pinch._hasPinched)
        {
            CurrentTarget = obj;
            UpdateRayVisualization(obj.transform.position, rightHand.PointerPose.position, true);
        }

        Debug.Log("Object selected", obj);
        
    }

    public void HandReleased()
    {
        if (!pinch._hasPinched){
            UpdateRayVisualization(rightHand.PointerPose.position, rightHand.PointerPose.position + rightHand.PointerPose.forward * 1000, false);
            Debug.Log("Object released");
        }
        
    }

    private void UpdateRayVisualization(Vector3 startPosition, Vector3 endPosition, bool hitSomething)
    {
        if (showRaycast && lineRenderer != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            lineRenderer.material.color = hitSomething ? Color.green : Color.red;
        }
        else if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        pinch = GetComponent<CheckPinch>();
    }
}
