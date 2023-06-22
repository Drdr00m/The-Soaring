using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoetryControl : MonoBehaviour
{
    private GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        FollowCamera();
    }
    private void FollowCamera()
    {
        transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, 0);
        //����ֱ�ӵ������������,z����������һ������
    }
}
