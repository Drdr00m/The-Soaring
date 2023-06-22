using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject Player;
    private Fish FishSceneNum;
    private Bird BirdSceneNum;
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");//��ȡ�������
        FishSceneNum = Player.GetComponent<Fish>();//���ڻ�ȡ�������
        
    }

    void LateUpdate()
    {
        
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");//��ȡ�������
            BirdSceneNum = Player.GetComponent<Bird>();//���ڻ�ȡ�������
            FishSceneNum = null;
        }
        if (FishSceneNum != null)//������
        {
            switch (FishSceneNum.SceneNum)
            {
                case 0:
                case 1:
                    transform.position = new Vector3(Player.transform.position.x + 3, -4.06f, -10);//�����x���������x�����Ӧ
                    break;
                case 2:
                    transform.position = new Vector3(Player.transform.position.x + 3, -4.06f, -10);
                    break;
                case 3:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break; 
            }
        }
        else if (FishSceneNum == null)//�㲻����
        {
        

        switch (BirdSceneNum.SceneNum)
            {
                case 3:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 4:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 5:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 6:
                    transform.position = new Vector3(Player.transform.position.x + 3, 184.43f, -10);
                    break;
                case 7:
                    transform.position = new Vector3(Player.transform.position.x + 3, 184.43f, -10);
                    break;
                case 8:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;
                case 9:
                    transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, -10);
                    break;



        }
        }


    }
}
