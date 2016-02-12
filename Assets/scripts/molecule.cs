using UnityEngine;
using System.Collections;

public class molecule : MonoBehaviour {

    private Transform[] molecules;
    public float speed = 1f;
    private Vector3 direc;
    public float nutrient;
    private Transform target;

    void Start() {
        nutrient = transform.localScale.x;

        GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
        molecules = new Transform[objs.Length-1];
        for (int i = 0; i < molecules.Length; i++)
            if (objs[i].transform != transform && objs[i].transform.gameObject.tag != "MainCamera")
                molecules[i] = objs[i].transform;

    }

    void Update() {
        target = findClosest(molecules);
        direc = (target.position - transform.position).normalized * speed;
        if (target.gameObject.tag == "Molecule")
            if (target.GetComponent<molecule>().nutrient > transform.GetComponent<molecule>().nutrient)
                direc = -direc;
        transform.Translate(direc * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (transform.localScale.x > collision.transform.localScale.x) {
            if(collision.gameObject.tag == "Feed")
                nutrient += collision.transform.GetComponent<feed>().nutrient;
            else
                nutrient += collision.transform.GetComponent<molecule>().nutrient;
            transform.GetComponent<molecule>().speed -= 0.1f;
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
