using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArrowProc : MonoBehaviour {

    Action<Collision2D> callBackCollisionFunction;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCollisionCallBack(Action<Collision2D> func)
    {
        callBackCollisionFunction += func;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        callBackCollisionFunction(c);
    }

}
