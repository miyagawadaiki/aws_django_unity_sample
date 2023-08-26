using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;
//using MiniJSON;
using PublicContents;

public class HttpManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// http://XXXX:yyyy/sentense/ のAPIを実行し, responseに格納する
	public IEnumerator GET(string sentence) {
		// APIのURI は定数として定められたIPアドレスなどと, 指定された文字列で構成する
		string uri = Constants.API_PREFIX + "/" + sentence;
		// 戻り値用のリスト
		List<Dictionary<string, string>> response;

		Debug.Log("-------- GET Request Start --------");
		Debug.Log("URI: " + uri);	

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

			// エラーが発生したとき
            if (request.result == UnityWebRequest.Result.ConnectionError ||
				request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("GET Request Failure");
                Debug.Log(request.error);
				// エラーのときは空で返す
				response = new List<Dictionary<string, string>>();
            }
			// 通信できたとき
            else
            {
				//succeeded = true;
                Debug.Log("GET Request Success");

				// 受け取った文字列を格納
				string resText = request.downloadHandler.text;
                Debug.Log(resText);

				// 文字列を分割してリストに納める
				response = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(resText);
            }

			// リストを返す
			yield return response;
        }
	}
}
