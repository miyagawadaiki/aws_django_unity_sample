using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using PublicContents;

public class ListItemController : MonoBehaviour
{
	[SerializeField]
	private Button button = null;
	[SerializeField]
	private TextMeshProUGUI text = null;
	[SerializeField]
	private Image image = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void RegisterBehavior(ImageItem imageItem) {
		text.text = imageItem.name;
		Sprite sprite = Resources.Load<Sprite>(imageItem.obj_path);
		// もし画像がないとき
		//if ()
		image.sprite = sprite;

		//button.
	}
}
