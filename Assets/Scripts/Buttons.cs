using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    void OnMouseUpAsButton() {
        switch (gameObject.name) {
        case "Play":
            SceneManager.LoadScene(1); 
            break;
       }
   }
}
