using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour {

    public void ClassicClick()
    {
        Application.LoadLevel(1);
        
    }

    public void QuitClick()
    {
        Application.Quit();
    }

}
