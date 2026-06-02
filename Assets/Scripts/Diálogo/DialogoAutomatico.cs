using UnityEngine;
using System.Collections;
public class DialogoAutomatico : MonoBehaviour{
   public GameObject DialogoCrocodilo;
   public GameObject DialogoJacare;
    public MonoBehaviour Chefe;

    IEnumerator Start(){
        if(Chefe != null){
            Chefe.enabled = false;
        }
        
        yield return new WaitForSeconds(0.5f);

        if(Geral.Instancia.A == TipoAnimal.Crocodilo){
            DialogoCrocodilo.SetActive(true);
        }
        else if(Geral.Instancia.A == TipoAnimal.Jacaré || Geral.Instancia.A == TipoAnimal.Nenhum){
            DialogoJacare.SetActive(true);
        }

        yield return new WaitUntil(() => Caixa_Dialogo.Ativa == false);

        if(Chefe != null){
            Chefe.enabled = true;
        }
    }
}
