using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //刚体
    private Rigidbody rBody;
    //音频组件
    private AudioSource footPlayer;
    //是否在地面上
    private bool isGround;

    void Start()
    {
        //获取刚体组件
        rBody = GetComponent<Rigidbody>();
        //获取音频组件
        footPlayer = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        //如果按下空格键，并且角色在地面上
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            //跳跃：给刚体一个向上的力
            rBody.AddForce(Vector3.up * 200);
        }
        //是否按下移动键
        float horizontal = Input.GetAxis("Horizontal");//a d分别返回-1和1
        float vertical = Input.GetAxis("Vertical");//s w分别返回-1和1
        if((horizontal != 0 || vertical != 0) && isGround == true)
        {
            //都不为零说明在移动并且不在跳跃状态，播放脚步声
            if (footPlayer.isPlaying == false)
            {
                //先判断播放状态，防止持续播放
                footPlayer.Play();
            }
        }
        else
        {
            footPlayer.Stop();
        }
    }

    //产生碰撞
    private void OnCollisionEnter(Collision collision)
    {
       //判断是不是地面
       if(collision.collider.tag == "Ground")
        {
            //踩在地面上了
            isGround = true;
        }
    }

    //结束碰撞
    private void OnCollisionExit(Collision collision)
    {
        //判断是不是地面
        if (collision.collider.tag == "Ground")
        {
            //离开地面上了
            isGround = false;
        }
    }
}
