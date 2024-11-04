using System.Collections;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private GameObject canvasPrefab;

    private GameObject player;
    private bool startingLevel;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(nameof(StartLevelCoroutine));
    }

    void Update(){
        if(startingLevel){
            player.transform.Translate(5 * Time.deltaTime * Vector2.up);
        }
    }

    IEnumerator StartLevelCoroutine (){
        startingLevel = true;
        yield return new WaitForSeconds(1.2f);
        startingLevel = false;
        Instantiate(canvasPrefab, transform.position, Quaternion.identity); 
        this.enabled = false;
    }
}
