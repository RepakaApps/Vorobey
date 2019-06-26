using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBack : MonoBehaviour {
    
    void OnMouseUpAsButton() {
        switch (gameObject.name) {
        case "Back":
            SceneManager.LoadScene(2);
            break;
        }
    }
}
