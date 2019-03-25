using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour {


    GameObject player;
    GameObject message;
    private GameObject hpGauge;
    new Rigidbody2D rigidbody2D;
    public GameObject ArrowPrefab;
    float span = 1.0f;
    float delta = 0.0f;
    int px;
    int Life = 10;

    // Use this for initialization
    void Start () {
        hpGauge = GameObject.Find("hpGauge");
        player = GameObject.Find("player");
        message = GameObject.Find("Message");
        message.GetComponent<Text>().enabled = false;
    }


    void Update()
    {
        
        player.GetComponent<ArrowProc>().SetCollisionCallBack(CollisionEnter2DCallback);
//        MovePlayer();
        ArrowGeneration();
    }

    public void ArrowGeneration()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            this.delta = 0.0f;
            GameObject go = Instantiate(ArrowPrefab) as GameObject;
            px = UnityEngine.Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);

            if (go.transform.position.y < -5.0f)
            {
                Destroy(go.gameObject);
            }
        }
    }


//    public void MovePlayer()

    public void LButtonDown()
    {
        if (player.transform.position.x <= -6)
        {
            player.transform.Translate(0, 0, 0);
        }
        else
        {
            player.transform.Translate(-3, 0, 0);
        }
    }

    public void RButtonDown()
    {
        if (player.transform.position.x >= 6)
        {
            player.transform.Translate(0, 0, 0);
        }
        else
        {
            player.transform.Translate(+3, 0, 0);
        }
    }






    /*
                if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (player.transform.position.x <= -6)
                {
                    player.transform.Translate(0, 0, 0);
                }
                else
                {
                    player.transform.Translate(-3, 0, 0);
                }
            }
    */
    /*
if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        if (player.transform.position.x >= 6)
        {
            player.transform.Translate(0, 0, 0);
        }
        else
        {
            player.transform.Translate(+3, 0, 0);
        }
    }

}
    */

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
        Life = Life - 1;
        Debug.Log("Life:" + Life);
        if (Life <= 0)
        {
            message.GetComponent<Text>().enabled = true;
        }
    }

    public void CollisionEnter2DCallback(Collision2D c)
    {
        rigidbody2D = player.GetComponent<Rigidbody2D>();

        string tag = c.gameObject.tag;

        if (tag == "arrow")
        {
            player.SetActive(false);
        }

    
    }



}





