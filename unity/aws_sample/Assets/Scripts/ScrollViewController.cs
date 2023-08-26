using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json;
using PublicContents;

public class ScrollViewController : MonoBehaviour
{
	[SerializeField]
	private HttpManager httpManager = null;
	[SerializeField]
	private BackgroundController bgCntr = null;
	[SerializeField]
	private GameObject listItemObj = null;

	private Transform contentTrans;

    // Start is called before the first frame update
    void Start()
    {
		contentTrans = this.GetComponent<ScrollRect>().content.transform;
		StartCoroutine(MakeListCor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// $B%j%9%H$r:n$k%3%k!<%A%s(B
	IEnumerator MakeListCor() {
		// GET$B$N%3%k!<%A%s$r%$%s%9%?%s%92=(B
		IEnumerator coroutine = httpManager.GET("Map/maps/");
		// GET$B$,=*$o$k$^$GBT5!(B
		yield return StartCoroutine(coroutine);

		// GET$B%3%k!<%A%s$,JV$9J8;zNs(B
		string response = (string)coroutine.Current;

		// $BDL?.$K<:GT$7$?$H$-(B
		if (response.Substring(0,5) == "ERROR") {
				
		}
		// $BDL?.$K@.8y(B
		else {
			// JSON$B7A<0J8;zNs$rJ,2r(B
			List<ImageItem> items = JsonConvert.DeserializeObject<List<ImageItem>>(response);

			// $B$=$l$>$l$KBP$7$FA`:n(B
			foreach (ImageItem item in items) {
				GameObject obj = Instantiate(listItemObj, Vector3.zero, Quaternion.identity, contentTrans) as GameObject;
				ListItemController listItem = obj.GetComponent<ListItemController>();
				listItem.RegisterBehavior(item, bgCntr);
			}
		}
	}
}
