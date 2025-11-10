using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(int sceneIndx)
    {
        SceneManager.LoadScene(sceneIndx);
    }
}