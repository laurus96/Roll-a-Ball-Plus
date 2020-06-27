using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offeset;
    // Start is called before the first frame update
    void Start()
    {
        offeset = gameObject.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = player.transform.position + offeset;
    }
}
