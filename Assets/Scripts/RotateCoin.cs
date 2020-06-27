using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{

    public float rotateY = 30f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, rotateY, 0f) * Time.deltaTime);
    }
}
