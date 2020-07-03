using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform followTarget;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y + 2, followTarget.position.z - distance);
    }
}
