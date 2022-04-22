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

    public void ChangeScene(int sceneIndex)
	{
        if (Input.GetKeyDown(KeyCode.C))
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

            SceneManager.LoadScene(sceneIndex);
        }		
	}

	public void Exit()
	{
		Application.Quit();
	}
}