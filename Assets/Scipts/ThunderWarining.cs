using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderWarining : MonoBehaviour
{
    private GameObject MainCamera;
    public GameObject Thunder;
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //�������;�޸������ô��жϽ�ɫ�������
    }

    // Update is called once per frame
    void Update()
    {
        if(MainCamera.transform.position.x-transform.position.x>-20)
        {
            Thunder=Instantiate(Thunder,transform.position,Quaternion.Euler(0,0,-41));
            Destroy(gameObject);
        }
    }
}
