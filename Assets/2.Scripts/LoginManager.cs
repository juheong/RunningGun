using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;


public class LoginManager : MonoBehaviour
{
    [SerializeField] TMP_InputField nickname = null;
    DataManager data;
    PanelController panel;

    private void Start()
    {
        var bro = Backend.Initialize(true);
        if (bro.IsSuccess())
        {
            Debug.Log("Backend �ʱ�ȭ ����");            
        }
        else
        {
            Debug.Log("Backend �ʱ�ȭ ����");
        }
        data = GetComponent<DataManager>();
        
        if (Backend.BMember.GetGuestID() != null)
        {            
            Backend.BMember.DeleteGuestInfo();
            Debug.Log("�Խ�Ʈ ���� ����(�׽�Ʈ��)");
        }       
    }

    public void BtnLogin()
    {
        panel = GameObject.Find("GameManager").GetComponent<PanelController>();
        if (Backend.BMember.GetGuestID() != "")
        {
            BackendReturnObject bro = Backend.BMember.GuestLogin("�Խ�Ʈ�� �α���");
            if (bro.IsSuccess())
            {
                Debug.Log("�Խ�Ʈ �α��ο� �����߽��ϴ�.");
                LoadingSceneController.LoadString("MainMenu");
                panel.OpenSwapPanel(3);
            }
            else
            {
                if (bro.GetStatusCode() =="401")
                {
                    Debug.Log("�������� �ʴ� ID�Դϴ�.");
                }
            }
        }
        else
        {
            Debug.Log("�Խ�Ʈ�� ȸ������");
            BackendReturnObject bro = Backend.BMember.GuestLogin("�Խ�Ʈ�� �α���");
            if (bro.IsSuccess())
            {
                Debug.Log("�Խ�Ʈ ȸ�����Կ� �����߽��ϴ�.");
                panel.OpenSwapPanel(2);
            }
            else
            {
                if (bro.GetStatusCode() == "401")
                {
                    Debug.Log("�������� �ʴ� ID�Դϴ�.");
                }
            }
        }
  
    }
    private bool CheckNickname()
    {
        return Regex.IsMatch(nickname.text, "^[0-9a-zA-Z��-�R]*$");
    }

    public void BtnName()
    {
        if (CheckNickname() == false)
        {
            Debug.Log("�г����� �ѱ�, ����, ���ڷθ� ���� �� �ֽ��ϴ�.");
            return;
        }

        BackendReturnObject BRO = Backend.BMember.CreateNickname(nickname.text);

        if (BRO.IsSuccess())
        {
            Debug.Log("�г��� ���� �Ϸ�");
            LoadingSceneController.LoadString("MainMenu");
            data.InsertData();
        }
        else
        {
            switch (BRO.GetStatusCode())
            {
                case "409":
                    Debug.Log("�̹� �ߺ��� �г����� �ִ� ���");
                    break;

                case "400":
                    if (BRO.GetMessage().Contains("too long")) Debug.Log("20�� �̻��� �г����� ���");
                    else if (BRO.GetMessage().Contains("blank")) Debug.Log("�г��ӿ� ��/�� ������ �ִ°��");
                    break;

                default:
                    Debug.Log("���� ���� ���� �߻�: " + BRO.GetErrorCode());
                    break;
            }
        }
    }
}
