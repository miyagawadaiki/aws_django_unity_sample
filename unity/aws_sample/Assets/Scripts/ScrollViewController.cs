using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewController : MonoBehaviour
{
	[SerializeField]
	private HttpManager httpManager = null;

	private 

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(httpManager.GET("Map/maps/1/"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
