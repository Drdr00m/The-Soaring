using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(new Vector2(0, -1) * 20 * Time.deltaTime);//����ʱת�����������ƶ�
        Destroy(gameObject,2f);
    }
}
