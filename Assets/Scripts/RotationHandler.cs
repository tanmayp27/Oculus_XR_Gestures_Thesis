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

        //float randomAngle= Random.Range(-180, 0);
        //target.transform.rotation = Quaternion.Euler(target.transform.rotation.x, randomAngle, target.transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            postAngle= transform.rotation.eulerAngles.y;

            deltaAngle = postAngle-preAngle;
            //Debug.Log("Change in angle = " + deltaAngle);
            if (deltaAngle > 0.5)
            {
                //Debug.Log("Rotating Forward");
                target.transform.Rotate(Vector3.forward, -(target.transform.rotation.y + rotationAngle) * rotationSpeed * Mathf.Abs(deltaAngle));
            }
            
            else if (deltaAngle < 0.5)
            {
                //Debug.Log("Rotating Backward");
                target.transform.Rotate(Vector3.forward, (target.transform.rotation.y +rotationAngle) * rotationSpeed * Mathf.Abs(deltaAngle));
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
