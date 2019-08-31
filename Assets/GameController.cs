using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    private int score;
    //public GameObject targetObject;
    public Text scoreText;
    public Text hpText;
    public int hp=100;
    public Text gameOverText;
    

    //public int rotationSpeed;
    //public int moveSpeed;

    void Start () {
        
    }

    // Update is called once per frame
    void Update () {

        #region inefficientWayOfDoing
        //if (GameObject.FindGameObjectsWithTag("Monster").Length == 0)
        //{
        //    Debug.Log("inside");
        //    Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        //    spawner.pigCount = spawner.pigPerWave;
        //} inefficient way of doing
        #endregion
        #region learnFromMistake
        //if (false)
        //{
        //    // FullyVisible();
        //    return; ai sus cos of u the whole code fuck uppp
        //}
        //else
        //{
        #endregion
        #region trialAndErrorButMostlyError
        //    //targetObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        //    //distance = Vector3.Distance(player.position, targetObject.transform.position);
        //    // targetObject.transform.position += Vector3.right * Time.deltaTime;

        //    //targetObject.transform.rotation = Quaternion.Slerp(targetObject.transform.rotation, Quaternion.LookRotation(player.position - targetObject.transform.position), rotationSpeed * Time.deltaTime);
        //    //move towards the player
        //    //targetObject.transform.position += targetObject.transform.forward * moveSpeed * Time.deltaTime;


        //    //Vector3 viewPos = camera.WorldToViewportPoint(targetObject.transform.position);
        //    //if (viewPos.x > 0.5F)
        //    //    print("target is on the right side!");
        //    //else
        //    //    print("target is on the left side!");

        //    //targetObject.transform.position = cameraPos.position + cameraPos.forward * distance;
        //    //targetObject.transform.rotation = new Quaternion(0.0f, player.rotation.y, 0.0f, player.transform.rotation.w);
        #endregion

        if (hp == 0)
        {
            Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            spawner.pigPerWave = 0;
            scoreText.text = "";
            hpText.text = "";
            gameOverText.text = "GAME OVER";
        }

    }
    
    //public void FullyVisible() NOT USING JA
    //{
    //    if (!isFullyVisible)
    //    {
    //        if (cameraPos.position.x > targetObject.transform.position.x)
    //        {
    //            targetObject.transform.position = cameraPos.position + Vector3.left;
    //            isFullyVisible = true;
    //        }
    //        else
    //        {
    //            targetObject.transform.position = cameraPos.position + Vector3.right;
    //            isFullyVisible = true;
    //        }
    //    }
    //    else { isFullyVisible = true; }

    //}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        scoreText.text = "Score: " + score;
        //Debug.Log("score:" + score);
    }

    public void HpReduce()
    {

        hp -= 10;
        hpText.text = "HP: " + hp;
        Debug.Log("score:" + score);
    }

}
