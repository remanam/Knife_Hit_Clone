using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleBonus : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;

    [SerializeField] Transform parent;

    [SerializeField] int appleScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Knife") {
            ps.transform.SetParent(null);
            ps.Play();

            // Добавление очков внутри игры
            int add;
            add = Convert.ToInt32(GameController.Instance.Score.text) + appleScore;
            GameController.Instance.Score.text = add.ToString();
            
            Destroy(gameObject);
            
        }
    }
}
