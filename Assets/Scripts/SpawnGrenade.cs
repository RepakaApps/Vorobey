using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrenade : MonoBehaviour {
    public GameObject[] grenades;

    public static WaitForSeconds waitForSeconds = new WaitForSeconds(4f);
    private float[] positions = {-2f, -1f, 0f, 1f, 2f};

    void Start() {
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
        while (true) {
            Instantiate(
                grenades[Random.Range(0, grenades.Length)],
                new Vector3(positions[Random.Range(0, 5)], 7f, -1),
                Quaternion.Euler(new Vector3(0, 0, 0))
            );
            yield return waitForSeconds;
        }
    }
}
