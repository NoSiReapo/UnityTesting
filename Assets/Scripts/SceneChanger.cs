using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Update()
    {
        ChangeScene();
    }

    public void ChangeScene()
	{
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (SceneManager.GetActiveScene().name == "MainScene")
            {
                SceneTransition.SwitchToScene("Shop");
            }
            else if (SceneManager.GetActiveScene().name == "Shop")
            {
                SceneTransition.SwitchToScene("MainScene");
            } 

        }		
	}

	public void Exit()
	{
		Application.Quit();
	}
}