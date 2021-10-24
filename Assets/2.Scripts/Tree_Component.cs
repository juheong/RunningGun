using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Component : MonoBehaviour
{
    [SerializeField]
    private int speed;  // ��ü���� ������ �پ��ִ� ĸ�� �ݶ��̴�. ������ �������� �̰� ��Ȱ��ȭ ���־�� ��.



    private void Start()
    {

        //SoundManager.instance.PlaySE(falldown_sound);
    }

    private void Update()
    {
        Rotate();
        
    }

    private void Rotate()
    {
        if(transform.position.x == -3f)
        {   
            if (transform.rotation.eulerAngles.z <= 90)
            {
                transform.Rotate(0f, 0f, 10.0f * speed * Time.deltaTime);
            }

        }
        else if (transform.position.x == 3f)
        {
            if (transform.rotation.eulerAngles.z >= 270 || transform.rotation.eulerAngles.z == 0)
            {
                transform.Rotate(0f, 0f, -10.0f * speed * Time.deltaTime);
            }

        }

    }
}