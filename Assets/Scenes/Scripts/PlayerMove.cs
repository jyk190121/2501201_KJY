using System;
using UnityEngine;
/// <summary>
/// 1. 플레이어 이동하기
/// 2. 점프하기
/// </summary>
public class PlayerMove : MonoBehaviour
{
    float speed = 5f;           //이동 속도
    CharacterController cc;     //캐릭터 컨트롤러 컴포넌트
    float gravity = -10f;       //중력
    float velocityY;            //낙하속도
    float jumpPower = 2f;       //점프파워
    int jumpCount = 0;          //점프카운트
    int jumpMaxCount = 2;       //최대점프횟수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //캐릭터 컨트롤러 컴포넌트 가져오기
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 이동
        Move();
    }

    private void Move()
    {
        //플레이어 이동
        float h = Input.GetAxis("Horizontal");      //좌우이동
        float v = Input.GetAxis("Vertical");        //앞뒤이동
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        //카메라가 보는 방향으로 이동
        dir = Camera.main.transform.TransformDirection(dir);

        //transform.Translate(dir * speed * Time.deltaTime);
        //cc.Move(dir * speed * Time.deltaTime);

        //문제점 :공중부양

        //중력적용
        //velocityY += gravity * Time.deltaTime;
        //dir.y = velocityY;
        //cc.Move(dir * speed * Time.deltaTime);

        //땅에 닿아있는 상태라면 수직속도를 0으로 초기화
        //if (cc.isGrounded) 
        //{
        //    velocityY = 0f;
        //}

        if(cc.collisionFlags == CollisionFlags.Below)
        {
            velocityY = 0;
            jumpCount = 0;
        }
        else
        {
            velocityY += gravity * Time.deltaTime;
            dir.y = velocityY;
        }

        //if(cc.collisionFlags == CollisionFlags.Above) 캡슐의 머리
        //if(cc.collisionFlags == CollisionFlags.Sides) 캡슐의 몸통
        //if(cc.collisionFlags == CollisionFlags.Below) 캡슐의 하단

        //점프 및 2단 점프
        if(Input.GetButtonDown("Jump") && jumpCount < jumpMaxCount)
        {
            jumpCount++;
            velocityY = jumpPower;
        }

        cc.Move(dir * speed * Time.deltaTime);
    }
}
