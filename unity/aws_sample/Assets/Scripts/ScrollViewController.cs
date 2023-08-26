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

	// リストを作るコルーチン
	IEnumerator MakeListCor() {
		// GETのコルーチンをインスタンス化
		IEnumerator coroutine = httpManager.GET("Map/maps/");
		// GETが終わるまで待機
		yield return StartCoroutine(coroutine);

		// GETコルーチンが返す文字列
		string response = (string)coroutine.Current;

		// 通信に失敗したとき
		if (response.Substring(0,5) == "ERROR") {
				
		}
		// 通信に成功
		else {
			// JSON形式文字列を分解
			List<ImageItem> items = JsonConvert.DeserializeObject<List<ImageItem>>(response);

			// それぞれに対して操作
			foreach (ImageItem item in items) {
				GameObject obj = Instantiate(listItemObj, Vector3.zero, Quaternion.identity, contentTrans) as GameObject;
				ListItemController listItem = obj.GetComponent<ListItemController>();
				listItem.RegisterBehavior(item, bgCntr);
			}
		}
	}
}
