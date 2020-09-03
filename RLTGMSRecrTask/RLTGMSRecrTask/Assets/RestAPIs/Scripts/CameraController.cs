using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject defaultLocation;
    public GameObject car;
    Vector3 FirstTouchPosition;
    Vector3 SecondTouchPosition;
    float xAngle;
    float yAngle;
    float xAngleTemporary;
    float yAngleTemporary;

    public void ParentToDefaultLocation()
    {
        gameObject.transform.position = defaultLocation.transform.position;
        gameObject.transform.rotation = defaultLocation.transform.rotation;
        this.transform.parent = defaultLocation.transform;
    }
    public void ParentToCar()
    {
        gameObject.transform.position = car.transform.position;
        gameObject.transform.rotation = car.transform.rotation;
        this.transform.parent = car.transform;
    }
    void Start()
    {
        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FirstTouchPosition = Input.GetTouch(0).position;
                xAngleTemporary = xAngle;
                yAngleTemporary = yAngle;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                SecondTouchPosition = Input.GetTouch(0).position;
                xAngle = xAngleTemporary + (SecondTouchPosition.x - FirstTouchPosition.x) * 90 / Screen.width;
                yAngle = yAngleTemporary + (SecondTouchPosition.y - FirstTouchPosition.y) * 45 / Screen.height;
                this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
            }
        }
    }
}
