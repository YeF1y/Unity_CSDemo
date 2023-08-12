using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    
    void Start()
    {
        //给子弹刚体一个速度
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
