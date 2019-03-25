using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour {

    public GameObject ArrowPrefab;
    float span = 1.0f;
    float delta = 0.0f;

	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0.0f;
            GameObject go = Instantiate(ArrowPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);

            if (go.transform.position.y < -5.0f)
            {
                Destroy(go.gameObject);
            }
        }
    }



}
