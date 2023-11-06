using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;

    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool("Run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("Injured Run", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("Injured Run", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("Injured Run", false);

                ani.SetBool("Run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                ani.SetBool("Punching", false);
            }
            else
            {
                ani.SetBool("Injured Run", false);
                ani.SetBool("Run", false);

                ani.SetBool("Punching", true);
                atacando = true;
            }
        }
    }
    public void Final_Ani()
    {
        ani.SetBool("Punching", false);
        atacando = false;
    }

    private void Update()
    {
        Comportamiento_Enemigo();
    }
}