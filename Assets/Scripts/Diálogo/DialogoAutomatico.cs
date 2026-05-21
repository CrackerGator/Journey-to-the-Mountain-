using UnityEngine;
using System.Collections;
public class DialogoAutomatico : MonoBehaviour{
   public GameObject Dialogo;
    public MonoBehaviour Chefe;

    IEnumerator Start(){
        if(Chefe != null){
            Chefe.enabled = false;
        }
        
        yield return new WaitForSeconds(0.5f);

        Dialogo.SetActive(true);

        yield return new WaitUntil(() => Caixa_Dialogo.Ativa == false);

        if(Chefe != null){
            Chefe.enabled = true;
        }
    }
}
