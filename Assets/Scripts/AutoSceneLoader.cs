using UnityEngine;
using UnityEngine.SceneManagement;
public class AutoSceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
    private void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
