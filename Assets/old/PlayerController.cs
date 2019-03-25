using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //こちらは、未実装

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            this.transform.Translate(-3, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            //this.transform.Translate(+3, 0, 0);
            //            Vector3 pos = this.gameObject.transform.position;
            Vector3 pos = this.gameObject.GetComponent<Transform>().position;
            this.gameObject.transform.position = new Vector3(pos.x + 3.0f, pos.y, pos.z);
        }
        
    }

}
