using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBranco : MonoBehaviour{

    public static FadeBranco Instancia;

    public CanvasGroup canvasGroup;

    public float VelocidadeFade = 2f;

    void Awake(){

        if(Instancia == null){

            Instancia = this;
        }
        else{

            Destroy(gameObject);
        }
    }
    void Start(){
        StartCoroutine(FadeIn());
    }

    public void TrocarCena(string ProximaCena){

        StartCoroutine(FadeAndLoad(ProximaCena));
    }

    IEnumerator FadeAndLoad(string ProximaCena){

        yield return StartCoroutine(FadeOut());

        SceneManager.LoadScene(ProximaCena);

        yield return new WaitForSeconds(0.1f);

        yield return StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn(){
        canvasGroup.blocksRaycasts = false;
        while(canvasGroup.alpha > 0){

            canvasGroup.alpha -= Time.deltaTime * VelocidadeFade;

            yield return null;
        }

        canvasGroup.alpha = 0;
    }
    IEnumerator FadeOut(){
        canvasGroup.blocksRaycasts = true;
        while(canvasGroup.alpha < 1){

            canvasGroup.alpha += Time.deltaTime * VelocidadeFade;

            yield return null;
        }

        canvasGroup.alpha = 1;
    }
}