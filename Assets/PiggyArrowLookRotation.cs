using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyArrowLookRotation : MonoBehaviour {
    public GameObject pigToFollow;
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Quaternion rot = Quaternion.LookRotation(pigToFollow.transform.position - Camera.main.transform.position, Camera.main.transform.forward);
        transform.localEulerAngles = new Vector3(0, 0, rot.eulerAngles.z);
        
    }
}
