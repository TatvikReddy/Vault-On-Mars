using System;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos;
    private float length;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, cam.transform.position.y + 15, transform.position.z);

        if (movement > startPos + length)
        {
            startPos += length;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y * -1, transform.rotation.z, transform.rotation.w);

        }
        else if (movement < startPos - length)
        {
            startPos -= length;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y * -1, transform.rotation.z, transform.rotation.w);

        }
    }
}
