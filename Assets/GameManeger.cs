using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    //private List<GameObject> go;
    //private GameObject list = new List<GameObject>();
    private List<GameObject> go = new List<GameObject>();

    // Use this for initialization
    void Start () {
//        go = new List<GameObject>();
        hpGauge = GameObject.Find("hpGauge");
        player = GameObject.Find("player");
        message = GameObject.Find("Message");
        message.GetComponent<Text>().enabled = false;
    }


    void Update()
    {

        //player.GetComponent<ArrowProc>().SetCollisionCallBack(CollisionEnter2DCallback);

        //        MovePlayer();
        ArrowGeneration();
        //        Vector3 pos = go.transform.position;
        //矢が１つでも有ったら動く
        //foreachを学ぶ
        //findobjects

        foreach (GameObject s in go)
        {
            s.transform.Translate(0, -0.1f, 0);
            //       go.transform.position = new Vector3(pos.x, pos.y - 0.1f, pos.z);
            if (s.transform.position.y < -7.0f)
            {
                for (var num = go.Count - 1; 0 < go.Count; num--)
                {

                    Destroy(go[num]); //オブジェクトの削除
                    go.RemoveAt(num); //リストの削除
                }
            }

        }




    }

    private void ArrowGeneration()
    {
        delta = delta + 0.1f ;

        //矢が３つまでしか現れない。
        if (go.Count < 3)
        {
            if (delta > span)
            {
                delta = 0.0f;
                go.Add(Instantiate(ArrowPrefab) as GameObject);
                px = UnityEngine.Random.Range(-6, 7);
                go[go.Count - 1].transform.position = new Vector3(px, 7, 0);

            }

        }

        //List化する。
        //配列の宣言を覚える。






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

    private void DecreaseHp()
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
            DecreaseHp();
            //player.SetActive(false);
        }

    
    }



}





