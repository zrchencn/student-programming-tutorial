using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyJoint : MonoBehaviour
{
    
    // [SerializeField] private Joint child;
    public MyJoint child;
    
    public MyJoint getChild()
    {
        return child;
    }
    
    public void Rotate(float angle) {
        transform.Rotate(new Vector3(0, 0, 1) * angle);
    }

}
