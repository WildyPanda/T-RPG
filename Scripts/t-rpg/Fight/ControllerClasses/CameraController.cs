using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private float size = 5f;

    private Vector3 dragOrigin;
    private Vector3 dragDiference;
    private bool drag = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        size = size + size * -Input.GetAxis("Mouse ScrollWheel");
        if(size > 40)
        {
            size = 40;
        }
        if(size < 5)
        {
            size = 5;
        }
        cam.orthographicSize = size;

        if (Input.GetMouseButton(2))
        {
            dragDiference = cam.ScreenToWorldPoint(Input.mousePosition) - cam.transform.position;
            if (!drag)
            {
                drag = true;
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if(drag)
        {
            cam.transform.position = dragOrigin - dragDiference;
        }
    }
}
