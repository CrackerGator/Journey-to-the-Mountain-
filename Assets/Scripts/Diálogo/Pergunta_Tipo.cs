using UnityEngine;
using System.Collections;

public class Pergunta_Tipo : Interagir{

    public GameObject Dialogo1;
    public GameObject Escolha;
    public GameObject DialogoCrocodilo;
    public GameObject DialogoJacare;
    public GameObject UltimoDialogo;

    private bool Escolheu = false;
    private bool EmSequencia = false;
    private Jogador J;

    void Awake(){
        J = GameObject.FindWithTag("Jogador").GetComponent<Jogador>();
    }

    public override void Interagir1(){
        if(EmSequencia){
            return;
        }
        if(!Escolheu){
            StartCoroutine(Sequencia());
        }
        else{
            UltimoDialogo.SetActive(true);
        }
    }

    IEnumerator Sequencia(){
        EmSequencia = true;
        J.enabled = false;

        Dialogo1.SetActive(true);
        yield return new WaitUntil(() => Caixa_Dialogo.Ativa == false);

        Escolha.SetActive(true);
        yield return new WaitUntil(() => Geral.Instancia.A != TipoAnimal.Nenhum);

        if(Geral.Instancia.A == TipoAnimal.Crocodilo){
            DialogoCrocodilo.SetActive(true);
        }
        else if(Geral.Instancia.A == TipoAnimal.Jacaré){
            DialogoJacare.SetActive(true);
        }
        yield return new WaitUntil(() => Caixa_Dialogo.Ativa == false);

        J.enabled = true;
        Escolheu = true;
        EmSequencia = false;
    }
}