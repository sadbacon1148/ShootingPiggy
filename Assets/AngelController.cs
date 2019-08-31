using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour {
    private Vector3 storePosition;
    public Transform cameraPos;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public float distance;

    void Start ()
    {
        cameraPos = Camera.main.transform;
        gameObject.transform.LookAt(cameraPos);
    }
	
	// Update is called once per frame
	void Update ()
    {
        bool isVisible = Camera.main.IsObjectVisible(gameObject.GetComponents<Renderer>());

        if (!isVisible)
        {
            storePosition = cameraPos.position + cameraPos.forward * distance;
            storePosition.y = Mathf.Clamp(storePosition.y, 0.1f, 50f);
        }

        MoveToPosition();
    }

    public void MoveToPosition()
    {
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, storePosition, ref velocity, smoothTime);
        //targetObject.transform.position = cameraPos.position + cameraPos.forward * distance;
        gameObject.transform.LookAt(cameraPos);
    }

}
