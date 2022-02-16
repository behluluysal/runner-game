using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Vector3 firstPos, endPos;
    [SerializeField] private float PlayerSpeed = 3;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;

            float farkX = endPos.x - firstPos.x;

            //var desiredPosX = farkX * Time.deltaTime * PlayerSpeed;
            //desiredPosX = Mathf.Clamp(transform.position.x + desiredPosX, -1.5f, 1.5f);
            //transform.Translate(desiredPosX, 0, 0);

            var pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -1.5f, 1.5f);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, 1f * Time.deltaTime * 15f);
        }
        if(Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }
}
