using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    float speed = 5f;
    float angleX;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float h = Input.GetAxis("Horizontal");

        angleX += h * speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, angleX, 0);

    }
}
