using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("Transition-1");
    }
    
    public void OnClickQuitButton()
    {
        Application.Quit(); //Solo funciona en version ejecutable
    }
    
    
    
}
