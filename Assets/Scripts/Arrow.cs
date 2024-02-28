using System;
using System.Collections;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Enemy target;
    public float speed = 10;
    private Vector3 startPos;

    public void Shoot(Enemy target_)
    {
        target = target_;
        startPos = transform.position;
        StartCoroutine(StartFly());
    }

    private IEnumerator StartFly()
    {
        while (true)
        {
            var dist = target.transform.position.x - startPos.x;
            var nextX = Mathf.MoveTowards(transform.position.x, target.transform.position.x, speed * Time.deltaTime);
            var baseY = Mathf.Lerp(startPos.y, target.transform.position.y, (nextX - startPos.x) / dist);
            var height = 2f * (nextX - startPos.x) * (nextX - target.transform.position.x) /
                         (-0.25f * Mathf.Pow(dist, 2));
            
            Vector3 movePos = new Vector3(nextX, baseY + height, transform.position.z);
            transform.rotation = LookAtTarget(movePos - transform.position);
            transform.position = movePos;

            yield return null;
        }
    }

    private Quaternion LookAtTarget(Vector2 direction)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}