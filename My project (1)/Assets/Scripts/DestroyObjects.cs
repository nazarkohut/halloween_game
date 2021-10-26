using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    Vector2 pos;
    [SerializeField] Animator animator;
    bool isShacking = false;
    float shake=.2f;
    [SerializeField] Object candy;
    
    // Start is called before the first frame update
    void StopShaking(){
        isShacking=false;
        transform.position=pos;
    }
    void Start()
    {
        pos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if(isShacking ==true){
        //     transform.position=pos+UnityEngine.Random.insideUnitCircle*shake;
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "AttackHitBox"){
            // isShacking=true;
            animator.Play("destroy");
             Invoke("ExplodeTheObject",.3f);
        }
    }
    void ExplodeTheObject(){
        GameObject cand = (GameObject)Instantiate(candy);
        cand.transform.position = transform.position;
        Destroy(gameObject);
    }
}
