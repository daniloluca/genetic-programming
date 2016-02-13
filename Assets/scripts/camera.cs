using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public GameObject molecule;
    public GameObject feed;
    public int amountMolecule = 5;
    public int amountFeed = 100;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < amountFeed; i++)
            spawnFeed();
        for (int i = 0; i < amountMolecule; i++)
            spawnMolecule();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnFeed() {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Instantiate(feed, screenPosition, Quaternion.identity);
    }

    public void spawnMolecule() {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        Instantiate(molecule, screenPosition, Quaternion.identity);
    }
}
