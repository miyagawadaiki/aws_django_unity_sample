using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;

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

	public IEnumerator GET(string sentence) {
		string uri = Constants.API_PREFIX + "/" + sentence;

		Debug.Log("-------- GET Request Start --------");
		Debug.Log("URI: " + uri);	
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError ||
				request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("GET Request Failure");
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("GET Request Success");
                Debug.Log(request.downloadHandler.text);
                Dictionary<string, object> response = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
                Debug.Log(response["name"]);
            }
        }
	}
}
