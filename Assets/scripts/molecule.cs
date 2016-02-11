using UnityEngine;
using System.Collections;

public class molecule : MonoBehaviour {

    private Transform[] molecules;
    private GameObject target;
    public float speed = 1f;
    private Vector3 direc;

    void Start() {
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
        if(collision.gameObject.tag == "Feed")
            DestroyObject(collision.collider.gameObject);
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

    //private void think() {
    //    for (int i = 0; i < molecules.Length; i++)
    //        if (molecules[i] != null)
    //            if (target == null || (Vector3.Distance(molecules[i].transform.position, transform.position) < Vector3.Distance(target.transform.position, transform.position)))
    //                target = molecules[i];
    //    direc = (target.transform.position - transform.position).normalized * speed;
    //}
}
