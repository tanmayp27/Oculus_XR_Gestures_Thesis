using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AxisToRotate { Back, Down, Forward, Left, Right, Up, Zero };



public class OpeOpeController : MonoBehaviour
{
    //[SerializeField] OVRHand leftHand;
    //[SerializeField] OVRHand rightHand;
    [SerializeField] GameObject Obj1;
    [SerializeField] GameObject Obj2;

    [SerializeField] GameObject roomPrefab;
    [SerializeField] Transform spawnPos;


    [Range(1f, 10f)]
    [SerializeField] float forceMultiplier;

    private bool isRoomActive = false;

    //public AxisToRotate myAxis;
    /* static readonly Vector3[] vectorAxes = new Vector3[] {
        Vector3.back,
        Vector3.down,
        Vector3.forward,
        Vector3.left,
        Vector3.right,
        Vector3.up,
        Vector3.zero
    }; */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* public Vector3 GetAxis(AxisToRotate axis)
    {
        return vectorAxes[(int)axis];
    } */

    public void Room()
    {
        if (!isRoomActive)
        {
            isRoomActive = true;

            Instantiate(roomPrefab, spawnPos.position, spawnPos.rotation);
            
            roomPrefab.transform.localScale = Vector3.Lerp(roomPrefab.transform.localScale, roomPrefab.transform.localScale * 7.5f, Time.deltaTime);
        }
        else
        {

            Debug.Log("Room already open");
            
        }
    }

    /* private IEnumerator RoomOpen(float waitTime)
    {
        
    } */

    /* private IEnumerator RoomClose(float waitTime)
    {
        roomPrefab.transform.localScale = Vector3.Lerp(roomPrefab.transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), Time.deltaTime);
        
        yield return new WaitForSeconds(waitTime);
        roomPrefab.SetActive(false);
        isRoomActive = false;
    } */

    public void Shambles()
    {
        if (isRoomActive)
        {
            Transform t = Obj1.transform;
            Obj1.transform.position = Obj2.transform.position;
            Obj1.transform.rotation = Obj2.transform.rotation;

            Obj2.transform.position = t.position;
            Obj2.transform.rotation = t.rotation;
        }
        
    }

    

    public void TaktUp()
    {
        
        if (isRoomActive)
        {
            Rigidbody rb = Obj1.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
        }
        
    }
    public void TaktRight()
    {

        if (isRoomActive)
        {
            Rigidbody rb = Obj1.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.left * forceMultiplier, ForceMode.Impulse);
        }

    }
    public void TaktLeft()
    {

        if (isRoomActive)
        {
            Rigidbody rb = Obj1.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.right * forceMultiplier, ForceMode.Impulse);
        }

    }


}
