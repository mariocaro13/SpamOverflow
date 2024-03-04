using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoader : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
