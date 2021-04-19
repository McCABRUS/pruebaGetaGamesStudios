using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour
{
    public int escena;
    public Animator animator;
    public float tiempoDeEspera = 1f;

    public void cargarNivel()
    {
        animator.SetTrigger("iniciar");
        StartCoroutine(cargando(escena));
    }

    IEnumerator cargando(int indexEscena)
    {

        yield return new WaitForSeconds(tiempoDeEspera);
        animator.SetTrigger("cerrar");
        SceneManager.LoadScene(indexEscena);

    }
}
