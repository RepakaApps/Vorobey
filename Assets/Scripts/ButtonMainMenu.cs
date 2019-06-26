using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour {
    void OnMouseUpAsButton() {
        switch (gameObject.name) {
        case "MainMenu":
            SceneManager.LoadScene(0);
            break;
        }
        SpawnSeed.waitForSeconds = new WaitForSeconds(3f);
        SpawnGrenade.waitForSeconds = new WaitForSeconds(4f);
        MoveObjectSeed.speed = 2f;
        MoveObjectGrenade.speed = 2.5f;
    }
}
