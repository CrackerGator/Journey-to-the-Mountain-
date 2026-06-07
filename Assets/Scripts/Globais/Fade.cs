using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour{
    public static Fade Instancia;

    public CanvasGroup canvasGroup;
    public float VelocidadeFade;

    void Awake(){
        if (Instancia == null){
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        Destroy(gameObject);
    }
    void Start(){
        StartCoroutine(FadeIn());
    }

    public void TrocarCena(string ProximaCena){
        StartCoroutine(FadeAndLoad(ProximaCena));
    }

    IEnumerator FadeAndLoad (string ProximaCena){
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