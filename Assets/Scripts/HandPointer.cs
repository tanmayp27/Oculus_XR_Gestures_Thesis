using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HandPointer : MonoBehaviour
{
    public OVRHand rightHand;
    public GameObject CurrentTarget { get; private set; }
    public GameObject SecondTarget { get; private set; }

    [SerializeField] public bool showRaycast = false;
    
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LineRenderer lineRenderer;
    //[SerializeField] private HandFinger starPosJoint;

    private Color _originalColor;
    private Color _highlightColor;
    private Renderer _currentRenderer;

    public bool checkHeld = false;
    //private CheckPinch pinch;

    //private float amount=1f;


    // Start is called before the first frame update
    void Start()
    {
        //pinch = GetComponent<CheckPinch>();
    }

    // Update is called once per frame
    void Update() => CheckHandPointer(rightHand);

    void CheckHandPointer(OVRHand hand)
    {
        
        if(Physics.Raycast(hand.PointerPose.position, hand.PointerPose.forward, out RaycastHit hit, Mathf.Infinity, targetLayer))
        {
            if (CurrentTarget != hit.transform.gameObject)
            {
                CurrentTarget = hit.transform.gameObject;
                //Debug.Log(CurrentTarget);
                _currentRenderer = CurrentTarget.GetComponent<Renderer>();
                _originalColor=_currentRenderer.material.color;
                Color newColor = (_originalColor-Color.gray);
                _highlightColor = newColor;
                _currentRenderer.material.color = _highlightColor;

            }

            UpdateRayVisualization_Puzzle(CurrentTarget.transform.position, hand.PointerPose.position, true);


        }
        else
        {
            if (CurrentTarget != null && !checkHeld)
            {
                _currentRenderer.material.color = _originalColor;
                CurrentTarget = null;

            }
            UpdateRayVisualization_Puzzle(hand.PointerPose.position,hand.PointerPose.position+hand.PointerPose.forward*1000, false);
        }
    }

    private void UpdateRayVisualization_Puzzle(Vector3 startPosition, Vector3 endPosition, bool hitSomething)
    {
        if(showRaycast && lineRenderer !=null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            lineRenderer.material.color=hitSomething ? Color.green : Color.red;
        }
        else if (lineRenderer!=null)
        {
            lineRenderer.enabled = false;
        }
    }

   /* private IEnumerator DrawLine(OVRHand hand)
    {
        while (checkHeld)
        {
            UpdateRayVisualization_Puzzle(CurrentTarget.transform.position, hand.PointerPose.position, true);
        }
        yield return null;
    } */
    
    

    
    
}
