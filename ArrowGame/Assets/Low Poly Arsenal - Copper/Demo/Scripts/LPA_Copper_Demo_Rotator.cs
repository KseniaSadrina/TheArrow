using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPA_Copper_Demo_Rotator : MonoBehaviour {

    private Vector3 rotateBy;

    // Use this for initialization
    void Start()
    {
        rotateBy.y = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotateBy * Time.deltaTime);
    }
}
