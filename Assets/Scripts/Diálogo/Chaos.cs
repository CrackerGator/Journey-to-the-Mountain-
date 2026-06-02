using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class Chaos : Cutscenes{
    public GameObject DialogoSemNome;
    public GameObject DialogoCrocodilo;
    public GameObject DialogoJacare;


    protected override IEnumerator ProximoQuadro(){

        Fading = true;

        yield return StartCoroutine(FadeOut());

        i++;

        if(i >= Quadros.Length){
            canvasGroup.alpha = 1;
            
            if(DialogoSemNome != null || DialogoCrocodilo != null || DialogoJacare != null){

                if(Geral.Instancia.NomeJogador == "??????"){
                    DialogoSemNome.SetActive(true);
                }
                else if(Geral.Instancia.A == TipoAnimal.Crocodilo){
                    DialogoCrocodilo.SetActive(true);
                }
                else if(Geral.Instancia.A == TipoAnimal.Jacaré){
                    DialogoJacare.SetActive(true);
                }

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