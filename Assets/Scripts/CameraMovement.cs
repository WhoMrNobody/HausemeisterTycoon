using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.8f;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;

    void Update()
    {
        if(Input.touchCount > 0){

            if(Input.GetTouch(0).phase == TouchPhase.Moved){

                Vector2 touchDeltaPos = Input.GetTouch(0).deltaPosition;
                Vector3 newPos = transform.position + new Vector3(0, 0, -touchDeltaPos.x * Time.deltaTime * speed);

                Clamp(ref newPos);
                transform.position = newPos;
            }
        }
        
    }

    public void Clamp(ref Vector3 value){

        value.x = Mathf.Clamp(value.x, leftLimit.position.x, rightLimit.position.x);
        value.y = Mathf.Clamp(value.y, leftLimit.position.y, rightLimit.position.y);
        value.z = Mathf.Clamp(value.z, leftLimit.position.z, rightLimit.position.z);
    }
}
