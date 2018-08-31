using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * SceneSwitcher
 * A scene manager
 */

public class SceneSwitcher : MonoBehaviour {

    // Load the next scene
	public void SwitchScene()
    {
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }
}
