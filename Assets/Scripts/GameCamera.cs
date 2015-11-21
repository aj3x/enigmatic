using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{
    private Transform target;
    private Vector3 cameraTarget;
    public float height;
    public float xOffset;
    public float zOffset;
    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTarget = new Vector3(target.position.x + xOffset, target.position.y+height, target.position.z + zOffset);
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime);

    }
}
