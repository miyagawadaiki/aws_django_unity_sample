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

	// リストを作るコルーチン
	IEnumerator MakeListCor() {
		//// GETが成功したかどうかの値
		//bool succeeded = false;

		// GETのコルーチンをインスタンス化
		IEnumerator coroutine = httpManager.GET("Map/maps/");
		// GETが終わるまで待機
		yield return StartCoroutine(coroutine);

		//// 通信に失敗したとき
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
