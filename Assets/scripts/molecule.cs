using UnityEngine;
using System.Collections;

public class molecule : MonoBehaviour {

    private Transform[] molecules;
    private GameObject target;
    public float speed = 1f;
    private Vector3 direc;
    public float nutrient;

    void Start() {
        nutrient += transform.localScale.x;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Feed");
        molecules = new Transform[objs.Length];
        for (int i = 0; i < objs.Length; i++)
            molecules[i] = objs[i].transform;
    }

    void Update() {
        direc = (findClosest(molecules).position - transform.position).normalized * speed;
        transform.Translate(direc * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (transform.localScale.x > collision.transform.localScale.x) {
            if(collision.gameObject.tag == "Feed")
                nutrient += collision.transform.GetComponent<feed>().nutrient;
            else
                nutrient += collision.transform.GetComponent<molecule>().nutrient;
            DestroyObject(collision.collider.gameObject);
            transform.localScale = new Vector3(nutrient, nutrient, nutrient);
        }
    }

    private Transform findClosest(Transform[] objs) {
        float closest = -1;
        float objDistance;
        Transform result = transform;
        for (int i = 0; i < objs.Length; i++) {
            if (objs[i] != null) {
                objDistance = (objs[i].position - transform.position).sqrMagnitude;
                if (closest < 0) {
                    closest = objDistance;
                }
                if (objDistance <= closest) {
                    closest = objDistance;
                    result = objs[i];
                }
            }
        }
        return result;
    }
}
