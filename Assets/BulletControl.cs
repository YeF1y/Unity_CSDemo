using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    
    void Start()
    {
        //���ӵ�����һ���ٶ�
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
