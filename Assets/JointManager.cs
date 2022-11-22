using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MyJoint root;
    [SerializeField] private MyJoint end;
    [SerializeField] private GameObject target;
    [SerializeField] private float threshold = 0.05f;
    [SerializeField] private float rate = 5f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 20; ++i)
        {
            if (getEndDistance() > threshold)
            {
                MyJoint curr = root;
                while (curr != null)
                {
                    float slope = calculateSlope(curr);
                    curr.Rotate(-slope * rate);
                    curr = curr.getChild();
                }
            }
        }
    }
    
    float calculateSlope(MyJoint joint)
    {
        float deltaTheta = 0.01f;
        float d1 = getEndDistance();
        joint.Rotate(deltaTheta);
        float d2 = getEndDistance();
        joint.Rotate(-deltaTheta);
        return (d2 - d1) / deltaTheta;
    }

    float getEndDistance()
    {
        return Vector2.Distance(end.transform.position, target.transform.position);
    }
}