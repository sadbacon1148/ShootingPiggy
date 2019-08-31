using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DragonBullet : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float lifetime;
    public GameObject instanceDragonArrowToFollow;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
      
    }

    // Update is called once per frame
    void Update () {
        //bool isVisible = Camera.main.IsObjectVisible(gameObject.GetComponents<Renderer>());

        //if (isVisible)
        //{
        //    Debug.Log("Bullet is visible");
        //    if (instanceDragonArrowToFollow != null)
        //    {
        //        Debug.Log("change to RED");
        //        instanceDragonArrowToFollow.GetComponentInChildren<Image>().color = Color.red;

        //    }


        //}


    }
    
}
