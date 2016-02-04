using UnityEngine;
using System.Collections;

public class feed : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll) {
        DestroyObject(this.gameObject);
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
