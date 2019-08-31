using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiggyController : MonoBehaviour {

    public Transform player;
    public float attackRange;
    private float distance;
    public Animator anim;
    public float countDown;
    private float timer;
    [HideInInspector] public Spawner spawner;
    [HideInInspector] public GameObject instancePiggyArrowToFollow;
    

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        timer = countDown;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player);
        distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackRange)
        {
            instancePiggyArrowToFollow.GetComponentInChildren<Image>().color = Color.red;
            anim.SetBool("Walk", false);
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                anim.SetTrigger("Attack");
                timer = countDown;
            }
     
        }
        else
        {
            anim.SetBool("Walk",true);
        }

        bool isVisible = Camera.main.IsObjectVisible(gameObject.GetComponents<Renderer>());
       
            if (!isVisible)
            {
                if (instancePiggyArrowToFollow != null)
                {
                    instancePiggyArrowToFollow.SetActive(true);
                }
            }
            else
            {
                if (instancePiggyArrowToFollow != null)
                {
                    instancePiggyArrowToFollow.SetActive(false); //the arrow is gone when the pig is destroyed cos this script will no longer work
                }

            }

    }

    private void OnDestroy()
    {
        //spawner.pigCount++;
       
       
    }

}

    



