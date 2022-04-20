using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	private bool firstScene;
    private int sceneIndex;
    private void Start()
    {
        firstScene = true;
    }

    private void SelectName()
    {
       if (!firstScene)
        {
            sceneIndex = 0;
            firstScene = true;
        }
        else
        {
            sceneIndex = 1;
            firstScene = false;
        }
    }
    public void ChangeScene(int sceneIndex)
	{
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(sceneIndex);
        }		
	}

	public void Exit()
	{
		Application.Quit();
	}
}