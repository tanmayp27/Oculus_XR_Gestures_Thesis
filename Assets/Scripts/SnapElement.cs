using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapElement : MonoBehaviour
{
    //private Collider _entry;
    //private Collider _exit;
    // Start is called before the first frame update

    Renderer _renderer;
    void Start()
    {
        //_entry= transform.GetChild(1).GetComponent<Collider>();
        //_exit=transform.GetChild(2).GetComponent<Collider>();
        _renderer=GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==this.gameObject.tag)
        {
            other.transform.position=gameObject.transform.position;
            if (_renderer != null)
            {
                _renderer.enabled = false;
            }
        }
    }

    /* private void OnTriggerExit(Collider other)
    {
        if (_renderer != null)
        {
            _renderer.enabled = true;
        }
    } */
}
