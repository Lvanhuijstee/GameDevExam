using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUIManager : MonoBehaviour
{
    private void Awake()
    {
        
    }

    public void Starting()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();// exits game
        UnityEditor.EditorApplication.isPlaying = false; //exit editor
    }

}
