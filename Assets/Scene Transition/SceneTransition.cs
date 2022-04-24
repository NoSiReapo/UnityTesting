using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{
    public TMP_Text LoadingPercentage;
    public Image LoadingProgressBar;

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator animator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        instance.animator.SetTrigger("sceneClosing");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        // ����� ����� �� ������ ������������� ���� ������ �������� closing:
        instance.loadingSceneOperation.allowSceneActivation = false;

        instance.LoadingProgressBar.fillAmount = 0;
    }

    private void Start()
    {
        instance = this;

        animator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            animator.SetTrigger("sceneOpening");
            instance.LoadingProgressBar.fillAmount = 1;

            // ����� ���� ��������� ������� ����� ������� SceneManager.LoadScene, �� ����������� �������� opening:
            shouldPlayOpeningAnimation = false;
        }
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";

            // ������ ��������� ��������:
            //LoadingProgressBar.fillAmount = loadingSceneOperation.progress; 

            // ��������� �������� � ������� ���������, ����� ��������� �������:
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress,
                Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()
    {
        // ����� ��� �������� �����, ���� �� �������������, ����������� �������� opening:
        shouldPlayOpeningAnimation = true;

        loadingSceneOperation.allowSceneActivation = true;
    }
}