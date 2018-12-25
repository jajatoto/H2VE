using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{

    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {

        mainCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float Distance;

        if (groundPlane.Raycast(ray, out Distance))
        {

            Vector3 point = ray.GetPoint(Distance);
            Vector3 realLookPos = new Vector3(point.x, transform.position.y, point.z);

            //Debug.DrawLine(ray.origin, point, Color.black);

            transform.LookAt(realLookPos);

        }
    }
}
