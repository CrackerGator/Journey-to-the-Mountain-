using System.Collections;
using UnityEngine;

public class Impostor : Interagir{
    public GameObject Dialogo;
    public GameObject Explosao;
    
    public override void Interagir1(){
        StartCoroutine(Explodir());
    }
    
    IEnumerator Explodir(){
        Dialogo.SetActive(true);
        yield return new WaitUntil(() => Caixa_Dialogo.Ativa == false);
        Explosao.SetActive(true);
        Destroy(gameObject);
    }
}
