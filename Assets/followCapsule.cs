using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCapsule : MonoBehaviour
{

    public GameObject capsule;
    public Vector3 startPos;
        
        void Start()
    {
        startPos = capsule.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = capsule.transform.position - startPos;
        transform.position = new Vector3(transform.position.x, transform.position.y + diff.y, transform.position.z + diff.z);
        
    }
}
