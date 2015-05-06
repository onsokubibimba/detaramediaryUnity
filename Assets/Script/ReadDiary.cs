using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ReadDiary : MonoBehaviour {

	public Text hidukeText;
	public Text youbiText;
	public Text tenkiText;
	public Text ituText;
	public Text dokoText;
	public Text dareText;
	public Text donnaText;
	public Text naniText;
	public Text dousitaText;
	public Text matomeText;

	public Button tweetbtn;

	string hiduke;

	// Use this for initialization
	void Start () {

		string youbi;
		string tenki;
		string itu;
		string doko;
		string dare;
		string donna;
		string nani;
		string dousita;
		string matome;
		int tweetfg;

		hiduke = staticitem.gethiduke();

		//もし引数がなかったら今日の日付入れておく
		if (hiduke == "") {
			DateTime thisDay = DateTime.Now;
			int year = thisDay.Year;
			int month = thisDay.Month;
			int day = thisDay.Day;
			
			hiduke = year + "ねん" + month + "がつ" + day + "にち";
		}

		SqliteDatabase sqlDB = new SqliteDatabase("diarydb.db");
		
		string squery = "select * from detaramediary where hiduke = '" + hiduke + "';";
		DataTable db = sqlDB.ExecuteQuery(squery);

		if (db != null) {
			DataRow dr = db.Rows [0];

			hiduke = (string)dr["hiduke"];
			youbi = (string)dr["youbi"];
			tenki = (string)dr["tenki"];
			itu = (string)dr["itu"];
			doko = (string)dr["doko"];
			dare = (string)dr["dare"];
			donna = (string)dr["donna"];
			nani = (string)dr["nani"];
			dousita = (string)dr["dousita"];
			matome = (string)dr["matome"];
			tweetfg = (int)dr["tweetfg"];
			
			hidukeText.text=hiduke;
			youbiText.text=youbi;
			tenkiText.text=tenki;
			ituText.text=itu;
			dokoText.text=doko;
			dareText.text=dare;
			donnaText.text=donna;
			naniText.text=nani;
			dousitaText.text=dousita;
			matomeText.text=matome;


			if (tweetfg == 1) {
				tweetbtn.enabled=false;
			}
		}

	}
	

	// Update is called once per frame
	void Update () {
	
	}


	public void tweet() {
		//SocialPost.twitter("Post Message");

		string hiduke=hidukeText.text;
		string youbi=youbiText.text;
		string tenki=tenkiText.text;
		string itu=ituText.text;
		string doko=dokoText.text;
		string dare=dareText.text;
		string donna=donnaText.text;
		string nani=naniText.text;
		string dousita=dousitaText.text;
		string matome=matomeText.text;

		string tweetstr = "#でたらめにっき \n" + hiduke;
		tweetstr += " " + youbi;
		tweetstr += "\n" + tenki;
		tweetstr += "\n" + itu;
		tweetstr += "\n" + doko;
		tweetstr += "\n" + dare;
		tweetstr += "\n" + donna;
		tweetstr += "\n" + nani;
		tweetstr += "\n" + dousita;
		tweetstr += "\n" + matome;
		
		//SocialConnector.Share (tweetstr);
		// UnityでのTwitter連携プラグインは投稿フォームを開くまでなのでその先でキャンセルしかたかどうかが拾えない
		SocialPost.twitter(tweetstr);




	}

	public void modoru() {
		Application.LoadLevel ("selectdiary");

	}









}
