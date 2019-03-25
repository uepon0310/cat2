using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowController : MonoBehaviour {


    public GameObject player;
    public GameObject gameManeger;


    // Use this for initialization
    void Start () {
               this.player = GameObject.Find("player");
               gameManeger = GameObject.Find("GameManeger");
        //
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, pos.y - 0.1f, pos.z);
        if (transform.position.y < -5.0f)
        {
            Destroy(this.gameObject);
        }
        //当たり判定
        Vector2 p1 = transform.position;//矢の中心座標
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 0.7f;

        if (d < r1 + r2)
        {
            gameManeger.GetComponent<GameManeger>().DecreaseHp();
            Destroy(this.gameObject);
        }


    }
    
}
