using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        // si clic en R => reinicia la escena actual
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    // Reinicia la escena
    private void RestartScene()
    {
        // obtiene el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // carga la escena actual
        SceneManager.LoadScene(currentSceneIndex);
    }
}
