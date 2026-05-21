using UnityEngine;
using System.Collections;

public class Chaos : Cutscenes{
    public GameObject Dialogo;

    protected override IEnumerator ProximoQuadro(){

        Fading = true;

        yield return StartCoroutine(FadeOut());

        i++;

        if(i >= Quadros.Length){
            canvasGroup.alpha = 1;
            
            if(Dialogo != null){

                Dialogo.SetActive(true);

                yield return null;

                yield return new WaitUntil(() => Caixa_Dialogo.Ativa == false);
            }

            Fade.Instancia.TrocarCena(ProximaFase);

            yield break;
        }

        MostrarQuadro();

        yield return StartCoroutine(FadeIn());

        Fading = false;
    }
}