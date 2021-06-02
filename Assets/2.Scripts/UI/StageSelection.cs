using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{
	public GameObject[] stage;
	public static int selectedStage = 0; 

	public void NextStage()
	{
		stage[selectedStage].SetActive(false);
		selectedStage = (selectedStage + 1) % stage.Length;
		stage[selectedStage].SetActive(true);
	}

	public void PreviousStage()
	{
		stage[selectedStage].SetActive(false);
		selectedStage--;
		if (selectedStage < 0)
		{
			selectedStage += stage.Length;
		}
		stage[selectedStage].SetActive(true);
	}

	public static void StartGame(string sceneName) // �������� �ǳڿ��� ȣ�� ����
	{
		LoadingSceneController.LoadSceneString(sceneName);        
        
		//SceneManager.LoadScene(selectedStage+1, LoadSceneMode.Single);
		//Debug.Log((otherScript.selectedStage + 1) + "��° ĳ������ " + (selectedStage + 1) + "�ܰ� ����");
	}
}
