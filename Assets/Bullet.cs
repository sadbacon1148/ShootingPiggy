using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float lifetime;
    public int scoreValue;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Bullet Hit: "+other.name + " "+other.tag);
        if (other.tag == "Monster") //piggy monster
        {
           // Debug.Log("Bullet tag: " + other.name);
            if (other.transform.root.gameObject != null)
            {
                GameObject.Destroy(other.transform.root.gameObject);
            }
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);
            Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            spawner.destroyPig++;
            //Debug.Log(spawner.destroyPig);
            GameController gameController = GameObject.Find("GameContoller").GetComponent<GameController>();
            gameController.AddScore(scoreValue);
        }

        if (other.tag == "Dragon") 
        {
            // Debug.Log("Bullet tag: " + other.name);
            if (other.transform.root.gameObject != null)
            {
                GameObject.Destroy(other.transform.root.gameObject);
            }
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);
            Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            spawner.destroyDragon++;
            GameController gameController = GameObject.Find("GameContoller").GetComponent<GameController>();
            gameController.AddScore(scoreValue);
        }


        if (other.tag == "DragonBullet")
        {

            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);
        }

    }
}
