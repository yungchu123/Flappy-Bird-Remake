using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    private float deadZone = -10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Shift pipe to left as games goes on.
        // Time.deltaTime is used to prevent fps from affecting moveSpeed
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);

        // Delete gameObject when no longer needed to free memory
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
