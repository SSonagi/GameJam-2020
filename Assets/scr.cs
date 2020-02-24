using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    public Transform targetTransform;
    public float y;
    Vector3 tempVec3 = new Vector3();

    void LateUpdate()
    {
        tempVec3.x = targetTransform.position.x;
        tempVec3.y = y;
        tempVec3.z = 10;
        this.transform.position = tempVec3;
    }
}
