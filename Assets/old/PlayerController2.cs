using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
    //こちらを実装中
   // public Vector3 Position = gameObject.GetComponent<Transform>().position;


    // Use this for initialization
    void Start () {
		
	}
	
	public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);

        //       gameObject.GetComponent<Transform>().position;
        //        this.gameObject.transform.position = new Vector3(Position.x - 3.0f, Position.y, Position.z);
    }
    public void RButtonDown()
    {
        transform.Translate(3,0,0);
        //        this.gameObject.transform.position = new Vector3(Position.x + 3.0f, Position.y, Position.z);
    }
}
