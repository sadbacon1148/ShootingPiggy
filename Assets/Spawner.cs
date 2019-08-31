using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject pigModel;
    public int pigCount;
    public int pigPerWave;
    private float nextSpawn;
    public float spawnRate;
    public Vector3 spawnValues;
    public Vector3 dragonSpawnValues;
    public int destroyPig;
    public float countDown;
    private float timer;
    public GameObject dragonModel;
    public int dragonCount;
    public int dragonPerWave;
    public int destroyDragon;

    private float distance;
    public float attackRange;
   [HideInInspector] public GameObject instancePig; //for using in other class 
    public GameObject canvas;
    public GameObject piggyArrow;
    public GameObject dragonArrow;
   [HideInInspector] public GameObject instancePiggyArrow; //for using in other class 
   [HideInInspector] public GameObject instanceDragonArrow; //for using in other class
   [HideInInspector] public GameObject instanceDragon; //for using in other class 


    // Use this for initialization
    void Start()
    {
        pigCount = pigPerWave;
        dragonCount = dragonPerWave;
        timer = countDown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pigSpawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Vector3 dragonSpawnPosition = new Vector3(Random.Range(-dragonSpawnValues.x, dragonSpawnValues.x), dragonSpawnValues.y, dragonSpawnValues.z);
        Quaternion spawnRotation = Quaternion.identity; //This Quaternion means no rotation

        if (pigCount > 0 && Time.time > nextSpawn)
        {
   
            nextSpawn = Time.time + spawnRate;
            instancePig = Instantiate(pigModel, pigSpawnPosition, spawnRotation);

            instancePiggyArrow = Instantiate(piggyArrow, canvas.transform.position, spawnRotation) as GameObject;
            instancePiggyArrow.transform.SetParent(canvas.transform, true);
            PiggyArrowLookRotation piggyArrowLookRotation = instancePiggyArrow.GetComponent<PiggyArrowLookRotation>();
            piggyArrowLookRotation.pigToFollow = instancePig;

            PiggyController piggyController = instancePig.GetComponent<PiggyController>();
            piggyController.spawner = this;
            piggyController.instancePiggyArrowToFollow = instancePiggyArrow;
            pigCount--;
        }
    
        if (dragonCount > 0 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            instanceDragon = Instantiate(dragonModel, dragonSpawnPosition, spawnRotation);

            instanceDragonArrow = Instantiate(dragonArrow, canvas.transform.position, spawnRotation) as GameObject;
            instanceDragonArrow.transform.SetParent(canvas.transform, true);
            DragonArrowLookRotation dragonArrowLookRotation = instanceDragonArrow.GetComponent<DragonArrowLookRotation>();
            dragonArrowLookRotation.dragonToFollow = instanceDragon;

            DragonController dragonController = instanceDragon.GetComponent<DragonController>();
            dragonController.instanceDragonArrowToFollow = instanceDragonArrow;

            dragonCount--;
           
        }


        //PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if (destroyPig == pigPerWave)
        {
            timer = timer - Time.deltaTime;
            //Debug.Log(timer);
            if (timer <= 0)
            {

                pigCount = pigPerWave;
                destroyPig = 0;
                timer = countDown;
            }
            
        }

        if (destroyDragon == dragonPerWave)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                dragonCount = dragonPerWave;
                destroyDragon = 0;
                timer = countDown;
            }
        }

    
    }
}
