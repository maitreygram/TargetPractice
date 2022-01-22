using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCollision : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private GameObject floatingScorePrefab;
    Vector3 initLoc = new Vector3(0, 4, 10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision col)
    {
        float x = col.gameObject.transform.position.x;
        float y = col.gameObject.transform.position.y;
        float dist = Mathf.Sqrt(x*x + y*y);
        score = Mathf.Max(0.0f, 10 - 2*dist);
    	Debug.Log("Hit! " + col.gameObject.name + " " + y.ToString("0.00") + " " + x.ToString("0.00") + " " + dist.ToString("0.00") + " " + score.ToString("0.00"));
    	ShowScore(score.ToString("0.00"));
    }
    
    void ShowScore(string text)
    {
        if(floatingScorePrefab)
        {
            GameObject prefab = Instantiate(floatingScorePrefab, initLoc, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
}
