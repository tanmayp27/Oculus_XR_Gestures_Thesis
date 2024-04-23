using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float rotationSpeed=1f;
    [SerializeField] private float rotationAngle=1f;

    bool isGrabbed = false;

    private float preAngle=0f;
    private float postAngle=0f;
    private float deltaAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        preAngle=transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            postAngle= transform.rotation.eulerAngles.y;

            deltaAngle = Mathf.DeltaAngle(preAngle, postAngle);
            if (deltaAngle > 0)
            {
                target.transform.Rotate(Vector3.forward, -(target.transform.rotation.y + rotationAngle) * rotationSpeed * deltaAngle);
            }
            
            else if (deltaAngle < 0)
            {
                target.transform.Rotate(Vector3.forward, (target.transform.rotation.y +rotationAngle) * rotationSpeed *deltaAngle);
            }


        }
        
        preAngle= transform.rotation.eulerAngles.y;
        //target.transform.eulerAngles.y = transform.rotation.y;
    }

    public void IsGrabbed(bool grabbed)
    {
        isGrabbed=grabbed;
    }

    
}
