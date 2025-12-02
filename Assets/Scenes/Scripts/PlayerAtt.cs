using System.Collections;
using UnityEngine;
/// <summary>
/// 1. 총알발사 (파편)
/// 2. 슈류탄 투척
/// </summary>
public class PlayerAtt : MonoBehaviour
{
    public Transform playerPos;         //총알 발사 위치
    public GameObject bullet;           //총알 프리팹
    public GameObject grenade;          //슈류탄 프리팹

    bool isShooting = false;


    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 버튼 (누르는 동안 총알발사)
        if(Input.GetMouseButton(0) && !isShooting)
        {
            //Debug.Log("총알발사");
            StartCoroutine(ShootGun());
        }
        if(Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }
        if (isShooting)
        {
            bullet.transform.position += Vector3.forward * Time.deltaTime;
        }
        else
        {
            bullet.transform.position = playerPos.position;
        }
        //마우스 오른쪽 버튼 (슈류탄 투척)
        //눌럿을 때 손에 들고 땟을 때 던지자
        if (Input.GetMouseButtonDown(1))
        {
            print("슈류탄 던질 준비");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            print("슈류탄 던져");
        }
    }


    IEnumerator ShootGun()
    {
        isShooting = true;

        while (Input.GetMouseButton(0))
        {
            Instantiate(bullet, playerPos);
            yield return new WaitForSeconds(0.15f);
        }
      

    }
}
