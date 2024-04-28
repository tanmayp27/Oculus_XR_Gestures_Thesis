using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObj : MonoBehaviour
{
    [SerializeField] private Transform originalPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetObjPos()
    {
        float time = 2f;
        StartCoroutine(ResetObjPos(time));
    }

    private IEnumerator ResetObjPos(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.transform.position=originalPos.position;
        
    }
}
