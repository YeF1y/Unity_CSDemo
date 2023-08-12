using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon : MonoBehaviour
{
    private int hp = 5;
    private float moveSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(54, 0, 70);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 55)
        {
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(54, 0, 70);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
            {
                transform.position = new Vector3(54, 0, 70);
                hp = 5;
            }
        }
    }
}
