using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector3[] checkPoints;
    public float speed = 30f;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkPoints.Length == 0) 
        {
            Debug.LogError("Mảng checkPoints trống, vui lòng gán giá trị trong Unity.");
            return;  // Dừng lại nếu mảng checkPoints trống
        }

        Vector3 targetPosition = checkPoints[index];
        targetPosition.y = transform.position.y; 

        Vector3 direction = checkPoints[index] - transform.position;
        direction.y = 0;
        
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, checkPoints[index], speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, checkPoints[index]) == 0)
        {
            index = (index + 1) % checkPoints.Length;
        }
    }
}
