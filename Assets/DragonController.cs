using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DragonController : MonoBehaviour {
    private Transform cameraPos;
    public float accelerationTime;
    private Vector3 movement;
    public Vector3 oriPosition;
    private float timeLeft;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    private float distance;
    public float attackRange;
    public GameObject bullet;
    public float countDown;
    private float timer;
    [HideInInspector] public GameObject instanceDragonArrowToFollow;
    public Renderer dradonRenderer;

    public GameObject instanceDragonBullet;



    void Start () {
        cameraPos = Camera.main.transform;
        oriPosition=gameObject.transform.position; //create oriPosition so that the SmoothDamp will not keep on moving in Update function, oriPosition will be a fixed position 
        timer = countDown;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(cameraPos);
        #region wrongclamp
        //movement.y = Mathf.Clamp(movement.y, 1f, 2f); not working cos it's not for circle but sqaure kind of shape instead
        //movement.x = Mathf.Clamp(movement.x, 1f, 2f);
        //movement.z = Mathf.Clamp(movement.z, 0f, .5f);
        #endregion

        Vector3 v = gameObject.transform.position - cameraPos.position; // Vector3 v = newLocation - circleCenter;
        v = Vector3.ClampMagnitude(v, 1.6f); // v = Vector3.ClampMagnitude(v, circleRadius); 1.5 = distance btw camera and dragon
        gameObject.transform.position = cameraPos.position + v; //newLocation = circleCenter + v;


        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector3(Random.Range(-0.6f, 0.06f), Random.Range(0.5f, 1.2f), Random.Range(1.2f, 1.25f)); //1.5 dee gwa 1.25 dk why
            timeLeft += accelerationTime;
        }
        
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position,oriPosition+movement, ref velocity, smoothTime);

        distance = Vector3.Distance(Camera.main.transform.position, gameObject.transform.position);
    
        if (distance <= attackRange)
        {
            //Debug.Log("inside distance<= attackRange");
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                instanceDragonBullet = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
                DragonBullet dragonBullet = instanceDragonBullet.GetComponent<DragonBullet>();
                dragonBullet.instanceDragonArrowToFollow = instanceDragonArrowToFollow;
                timer = countDown;
            }
           
        }

        bool isVisible = Camera.main.IsObjectVisible(dradonRenderer);
        if (isVisible)
        {
            Debug.Log("is visiblw");
            if (instanceDragonArrowToFollow != null)
            {
                Debug.Log("dragon is visible");
                instanceDragonArrowToFollow.SetActive(false); //the arrow is gone when the pig is destroyed cos this script will no longer work
            }
        }
        if (!isVisible)
        {

            if (instanceDragonArrowToFollow != null)
            {
                instanceDragonArrowToFollow.SetActive(true);
                instanceDragonArrowToFollow.GetComponentInChildren<Image>().color = Color.green;
            }
        }

        if (instanceDragonBullet != null)
        {
            Debug.Log(" turn RED");
            instanceDragonArrowToFollow.GetComponentInChildren<Image>().color = Color.red;
        }
        else
        {

        }






    }


}
