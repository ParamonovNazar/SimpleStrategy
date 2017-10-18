using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    [SerializeField]
    private float Sensitivity=1f;
    [SerializeField]
    private Vector3 CameraRotate = Vector3.zero;
    [SerializeField]
    private Vector3 center = Vector3.zero;
    [SerializeField]
    private float border=10f;
    [SerializeField]
    private float minHeight = 10f;
    [SerializeField]
    private float maxHeight = 20f;

    private Vector3 lastMousePosition;
    
    private float distance;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1) {
            Swipe();
        }

        if (Input.touchCount == 2) {
            Zoom();
        } else if (distance!=0) {
            distance = 0;
        }

        ClampPosition();
    }

    void Zoom() {
        Vector2 finger1 = Input.GetTouch(0).position;
        Vector2 finger2 = Input.GetTouch(1).position;

        if (distance == 0) {
            distance = Vector2.Distance(finger1,finger2);
        }

        if (distance == 0) {
            distance = Vector2.Distance(finger1, finger2);
        }

        float delta = Vector2.Distance(finger1, finger2) - distance;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + Quaternion.Euler(CameraRotate) * transform.forward,delta*Time.deltaTime);

        distance = Vector2.Distance(finger1, finger2);
    }

    void ClampPosition() {
        float x = Mathf.Clamp(transform.position.x, center.x - border, center.x + border);
        float y = Mathf.Clamp(transform.position.y, center.x + minHeight, center.y + maxHeight);
        float z = Mathf.Clamp(transform.position.z, center.z - border, center.z + border);

        transform.position = new Vector3(x, y, z);
    }
   
     
    void Swipe() {
        Vector2 delta = Input.GetTouch(0).deltaPosition;

        transform.position += Quaternion.Euler(new Vector3(0,CameraRotate.y,0)) * (transform.forward * delta.x + transform.right*delta.y)*  Sensitivity  ;

    }
}
