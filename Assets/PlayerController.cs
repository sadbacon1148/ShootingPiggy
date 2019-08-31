using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float fireRate;
    private float nextFire;
    public GameObject shot;
    public GameController gameController;
    // Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetMouseButtonDown(0) && Time.time > nextFire) || (Input.touchCount > 0 && Time.time > nextFire))
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, Camera.main.transform.position, Camera.main.transform.rotation);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            Debug.Log("you got attacked by piggy monster");
            if (gameController.hp != 0)
            {
                gameController.HpReduce();
            }
            else { }

        }

        if(other.tag == "DragonBullet")
        {
            if (gameController.hp != 0)
            {
                gameController.HpReduce();
            }

        }
               
    }
}
