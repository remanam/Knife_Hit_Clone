using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogProperties : MonoBehaviour
{
    public static LogProperties Instance { get; private set; }

    private AudioSource audioHit;
    [SerializeField] private ParticleSystem ps;


    void Start()
    {
        audioHit = GetComponent<AudioSource>();

        Instance = this;

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered collision");
        audioHit.Play();

    }

    public void destroyLog()
    {
        StartCoroutine(destroyLogCouroutine());
    }

    public IEnumerator destroyLogCouroutine()
    {
        ps.Play();
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
