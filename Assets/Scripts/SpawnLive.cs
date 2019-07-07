using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLive : MonoBehaviour {
    public GameObject[] live;

    public static WaitForSeconds waitForSeconds = new WaitForSeconds(4f);
    private float[] positions = {-2f, -1f, 0f, 1f, 2f};

    void Start() {
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
        while (true) {
            Instantiate(
                live[Random.Range(0, live.Length)],
                new Vector3(positions[Random.Range(0, 5)], 7f, -1),
                Quaternion.Euler(new Vector3(0, 0, 0))
            );
            GameObject.Find("Live(Clone)").name = "Live";
            yield return waitForSeconds;
        }
    }
}
