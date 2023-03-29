using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSceneManage : MonoBehaviour
{
    private Scene scene;

    private void Start()
    {
        scene = gameObject.scene;
    }
    public void restart()
    {
        SceneManager.LoadScene(scene.buildIndex);
    }
    public void quit()
    {
        Application.Quit();
    }
}
