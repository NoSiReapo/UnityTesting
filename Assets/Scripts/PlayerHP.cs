using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float HpNumber;
    [SerializeField] private FountainTrigger fountainTrigger;
    private GameObject Player;
    private bool HpWarn;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        HpNumber = 100f;
        fountainTrigger.FountainEnterFlag = false;
        fountainTrigger.FountainExitFlag = false;
        HpWarn = true;
    }

    private void Update()
    {
        //FountainMessage();
        //HpLoose();
        //HpGain();
        //HpWarning();
        //PlayerDestroy();
    }

    private void FountainMessage() //��������� ��� ����������� � �������
    {
        if (fountainTrigger.FountainEnterFlag)
        {
            Debug.Log("You're near the Fountain!");
            fountainTrigger.FountainEnterFlag = false;
        }
    }

    private void HpGain() //��������� �� ��� ������ �� ������� �������
    {
        if (fountainTrigger.FountainExitFlag & HpNumber < 100f)
        {
            HpNumber += 10;
            fountainTrigger.FountainExitFlag = false;
        }
        else
        {
            if(fountainTrigger.FountainExitFlag & HpNumber == 100f)
                {
                Debug.Log("You have MAXIMUM HP!");
                fountainTrigger.FountainExitFlag = false;
            }
        }
    }

    private void HpLoose() //������ �� ��� �������� ������� � ������� 
    {
        if (!fountainTrigger.FountainExitFlag & Input.GetKeyDown(KeyCode.LeftControl))
        {
            HpNumber -= 10f;
        }
    }

    private void HpWarning() //��������������� ��������� � �������� ��������
    {
        if (HpNumber == 50f & HpWarn)
        {
            Debug.Log("Warning! Player HP is 50%");
            HpWarn = false;
        }
        else { 
            if(HpNumber > 50f || HpNumber < 50f)
            {
                HpWarn = true;
            }
        }
    }

    private void PlayerDestroy() //����������� ������ ��� ������ ��������
    {
       if (HpNumber == 0)
        {
            Object.Destroy(Player);
            Debug.Log("LOL YOU DIED!");
        }
    }
}
