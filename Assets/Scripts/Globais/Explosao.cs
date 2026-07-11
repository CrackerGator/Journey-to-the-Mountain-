using System.Collections;
using UnityEngine;


public class Explosao : MonoBehaviour{
    private Animator Animator1;
    public string Animacao1;
    void Awake(){
        Animator1 = GetComponent<Animator>();
    }

    private void OnEnable(){
        StartCoroutine(Desativar());
    }

    IEnumerator Desativar(){
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}