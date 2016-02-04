using UnityEngine;
using System.Collections;

public class molecule : MonoBehaviour {

    private GameObject[] molecules;
    private GameObject target;
    public float speed = 1f;
    private Vector3 direc;
    private Vector3 closest;

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(closest);
        think();
    }

    private void think() {
       // molecules = GameObject.FindGameObjectsWithTag("Feed");
        for (int i = 0; i < molecules.Length; i++) {
            Debug.Log(molecules[i]);
            if (molecules[i] != null) {
                target = molecules[i];
                if (Vector3.Distance(transform.position, target.transform.position) <= Vector3.Distance(transform.position, closest)) {
                    direc = (target.transform.position - this.transform.position).normalized * speed;
                    closest = direc;
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
        //molecules = UnityEngine.Object.FindObjectsOfType<GameObject>();
        molecules = GameObject.FindGameObjectsWithTag("Feed");
        closest = (molecules[0].transform.position - this.transform.position).normalized * speed;

        think();
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(closest * Time.deltaTime);
    }
}
