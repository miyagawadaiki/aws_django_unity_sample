using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewController : MonoBehaviour
{
	[SerializeField]
	private HttpManager httpManager = null;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(MakeListCor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// $B%j%9%H$r:n$k%3%k!<%A%s(B
	IEnumerator MakeListCor() {
		//// GET$B$,@.8y$7$?$+$I$&$+$NCM(B
		//bool succeeded = false;

		// GET$B$N%3%k!<%A%s$r%$%s%9%?%s%92=(B
		IEnumerator coroutine = httpManager.GET("Map/maps/");
		// GET$B$,=*$o$k$^$GBT5!(B
		yield return StartCoroutine(coroutine);

		//// $BDL?.$K<:GT$7$?$H$-(B
		//if (!succeeded) {
		//
		//}
		//else {
		//foreach (Dictionary<string, string> item in coroutine.Current) {
		//	Debug.Log(item["name"]);
		//}
		//}
		Debug.Log(coroutine.Current);
	}
}
