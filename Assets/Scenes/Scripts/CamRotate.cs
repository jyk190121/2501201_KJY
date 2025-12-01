using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 카메라를 마우스 움직이는 방향으로 회전하기
/// </summary>
public class CamRotate : MonoBehaviour
{
    float speed = 200f;     //회전 속도 (Time.deltaTime 곱해서 1초당 200도 회전)
    float angleX, angleY;   //직접 제어할 회전 각도
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //카메라 회전
        Rotate();
    }

    void Rotate()
    {
        float h = Input.GetAxis("Mouse X");      //가로방향
        float v = Input.GetAxis("Mouse Y");      //세로방향
        //Vector3 dir = new Vector3(v, h, 0);     //회전 방향 백터

        //회전은 각각의 축을 기준으로 회전을 한다
        //transform.Rotate(dir * speed * Time.deltaTime);

        //유니티엔진 내부적으로 각도는 360도를 더한 값으로 변환해서 처리
        //따라서 우리가 직접 각도를 제어해서 사용해야 회전처리가 편함

        angleX += v * speed * Time.deltaTime;    //y축 회전 각도 변경
        angleY += h * speed * Time.deltaTime;    //x축 회전 각도 변경

        angleX = Mathf.Clamp(angleX, -40f, 40f);                    //Y축 회전 각도 제한
        transform.eulerAngles = new Vector3 (angleX, angleY, 0);    //회전 각도 설정
    }
}
