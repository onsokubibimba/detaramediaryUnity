using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScrollControll : MonoBehaviour {

	[SerializeField]
	RectTransform prefab = null;

	public RectTransform parentitem;

	// Use this for initialization
	void Start () {
		string hiduke;
		string youbi;
		string tenki;


		SqliteDatabase sqlDB = new SqliteDatabase("diarydb.db");

		string squery = "select id,hiduke,youbi,tenki from detaramediary order by id ASC;";
		DataTable db = sqlDB.ExecuteQuery(squery);

		if (db != null) {
			foreach (DataRow dr in db.Rows) {
				hiduke = (string)dr["hiduke"];
				youbi = (string)dr["youbi"];
				tenki = (string)dr["tenki"];

				var item = GameObject.Instantiate(prefab) as RectTransform;
				item.SetParent(parentitem, false);

				var texts = item.GetComponentsInChildren<Text>();

				foreach (Text tx in texts){
					if (tx.tag == "hidukes") {
						tx.text=hiduke;
					}

					if (tx.tag == "youbis") {
						tx.text=youbi;
					}

					if (tx.tag == "tenkis") {
						tx.text=tenki;
					}

				}

			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void diaryclick(Text hiduketx) {
		staticitem.sethiduke(hiduketx.text);
		//Debug.Log (staticitem.gethiduke());

		Application.LoadLevel ("readdiary");

	}

	public void modoru() {
		Application.LoadLevel ("menu");
	}

}
