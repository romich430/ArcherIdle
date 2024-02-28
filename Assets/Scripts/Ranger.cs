using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    public Arrow arrow;
    public Animator animator;
    public Transform firepoint;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
            InitiateShooting(other.gameObject.GetComponent<Enemy>());
    }

    private void InitiateShooting(Enemy target)
    {
        StartCoroutine(Shoot(target));
    }

    private IEnumerator Shoot(Enemy target)
    {
        animator.SetTrigger("Attack"); 
        yield return new WaitForSeconds(0.45f); //костиль, щоб не витрачати час
        Arrow instance = Instantiate(arrow, firepoint.position, Quaternion.identity);
        instance.Shoot(target);
    }
}
