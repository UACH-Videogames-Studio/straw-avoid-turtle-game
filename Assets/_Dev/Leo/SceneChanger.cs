using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] string NameScene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(NameScene);
    }
}
