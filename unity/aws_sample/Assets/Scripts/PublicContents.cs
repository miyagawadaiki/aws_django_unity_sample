namespace PublicContents {

public static class Constants {
	public static readonly string PROTOCOL = "https";
	public static readonly string IP_ADDRESS = "35.77.89.172";
	public static readonly int PORT = 8000;
	public static readonly string API_PREFIX = PROTOCOL + "://" + IP_ADDRESS;
	//public static readonly string API_PREFIX = PROTOCOL + "://" + IP_ADDRESS + ":" + PORT;
}



public class BaseItem {
	public int id { get; set; }
	public string name { get; set; }
	//public string explanation { get; set; }
}

// $B2hA|(B
public class ImageItem : BaseItem {
	public string obj_path { get; set; }
}

}
