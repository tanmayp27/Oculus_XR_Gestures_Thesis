using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPointer : MonoBehaviour
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
    void Update() => CheckHandPointer(rightHand);

    void CheckHandPointer(OVRHand hand)
    {
        
        if(Physics.Raycast(hand.PointerPose.position, hand.PointerPose.forward, out RaycastHit hit, Mathf.Infinity, targetLayer))
        {
            if (CurrentTarget != hit.collider.transform.gameObject)
            {
                CurrentTarget = hit.collider.transform.gameObject;
                //Debug.Log(CurrentTarget);
                _currentRenderer = CurrentTarget.GetComponent<Renderer>();
                _originalColor=_currentRenderer.material.color;
                _highlightColor = (_originalColor + Color.grey) / 4;
                _currentRenderer.material.color = _highlightColor;

            }
            while (pinch._hasPinched)
            {
                UpdateRayVisualization(CurrentTarget.transform.position, hand.PointerPose.position, true);
            }
            


        }
        else
        {
            if (CurrentTarget != null)
            {
                _currentRenderer.material.color = _originalColor;
                CurrentTarget = null;

            }
            UpdateRayVisualization(hand.PointerPose.position,hand.PointerPose.position+hand.PointerPose.forward*1000, false);
        }
    }

    private void UpdateRayVisualization(Vector3 startPosition, Vector3 endPosition, bool hitSomething)
    {
        if(showRaycast && lineRenderer !=null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            lineRenderer.material.color=hitSomething ? Color.green : Color.red;
        }
        else if (lineRenderer !=null)
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
