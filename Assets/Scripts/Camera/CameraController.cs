using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject follow;
    public Vector2 minimumBoundary;
    public Vector2 maximumBoundary;

    public float speed = 2f;

    private void Update()
    {
        float interperlation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, follow.transform.position.y, interperlation);
        position.x = Mathf.Lerp(this.transform.position.x, follow.transform.position.x, interperlation);

        this.transform.position = position;

    }
}
