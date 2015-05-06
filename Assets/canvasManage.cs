using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;



public class canvasManage : MonoBehaviour {

	public Text debugtext;

	public RectTransform parentitemyoubi;
	public RectTransform parentitemtenki;
	public RectTransform parentitemitu;
	public RectTransform parentitemdoko;
	public RectTransform parentitemdare;
	public RectTransform parentitemdonna;
	public RectTransform parentitemnani;
	public RectTransform parentitemdousita;
	public RectTransform parentitemmatome;

	public GameObject youbiprefab;
	public GameObject tenkiprefab;
	public GameObject ituprefab;
	public GameObject dokoprefab;
	public GameObject dareprefab;
	public GameObject donnaprefab;
	public GameObject naniprefab;
	public GameObject dousitaprefab;
	public GameObject matomeprefab;

	string youbitag = "youbis";
	string tenkitag = "tenkis";
	string itutag = "itus";
	string dokotag = "dokos";
	string daretag = "dares";
	string donnatag = "donnas";
	string nanitag = "nanis";
	string dousitatag = "dousitas";
	string matometag = "matomes";


	public Text hidukeText;

	public Button nextBtn;

	//回転させるテキストフィールドの数
	int textfieldcount;

	//くるくるしてるテキストフィールドの番号
	int susumiguai;

	//くるくるしてるフィールド内のINDEX
	decimal kurukurucount;
	decimal kurukuruwariai;

	//そのフィールドでくるくるできる最大値
	int[] kurukurumaxcount;

	//くるくるさせるタイミング
	float ktime;

	//テキスト保持配列

	List<string> tempstrings;

	List<string> youbi;
	List<string> tenki;
	List<string> itu;
	List<string> doko;

	List<string> dare;
	List<string> donna;
	List<string> nani;
	List<string> dousita;
	List<string> matome;

	//くるくるフラグ
	bool isStoped;


	Text[] txts;

	//テキストボックスの高さ
	float TEXT_HEIGHT;


	//１回で移動する幅
	float textmoveheight;

	bool nowwait;

	int stopcount;

	List<int> stopedcounts;



	//テキストボックスを生成する
	public GameObject CreateUiFromPrefab(GameObject obj,int cnt,string str,RectTransform parent) {

		RectTransform pos;

		GameObject go = Instantiate (obj) as GameObject;
		go.transform.SetParent (parent, false);

		pos = go.GetComponent<Text>().rectTransform;
		go.GetComponent<Text>().rectTransform.localPosition = new Vector2(pos.localPosition.x, -(cnt * TEXT_HEIGHT));
		go.GetComponent<Text>().text=str;

		return go;
	}


	//リストをシャッフルする
	List<string> arrayshuffle(List<string> lis) {
		for (int i = 0; i < lis.Count; i++) {
			string temp = lis[i];
			int randomIndex = UnityEngine.Random.Range(0, lis.Count);
			lis[i] = lis[randomIndex];
			lis[randomIndex] = temp;
		}

		return lis;
	}


	// Use this for initialization
	void Start () {
		textfieldcount = 9;
		susumiguai = 0;
		kurukurucount = 0;
		stopcount = 0;
		stopedcounts = new List<int>();
		kurukuruwariai = 0.2m;

		nowwait = false;

		isStoped = false;

		ktime = 0.0f;

		tempstrings = new List<string> ();

		DateTime thisDay = DateTime.Now;
		int year = thisDay.Year;
		int month = thisDay.Month;
		int day = thisDay.Day;

		hidukeText.text = year + "ねん" + month + "がつ" + day + "にち";

		TEXT_HEIGHT = hidukeText.rectTransform.rect.height;

		textmoveheight = TEXT_HEIGHT * Convert.ToSingle(kurukuruwariai);

		DayOfWeek week = thisDay.DayOfWeek;

		int tc = 0;

		youbi = new List<string> ();

		switch (week) {
		case DayOfWeek.Sunday:
			tempstrings.Add ("(にちようび)");
			tempstrings.Add ("(日)");
			tempstrings.Add ("(白)");
			tempstrings.Add ("(目)");
			tempstrings.Add ("(サンダイ)");
			tempstrings.Add ("(Ｓｕｎｄａｙ)");


			break;
		case DayOfWeek.Monday:
			tempstrings.Add ("(げつようび)");
			tempstrings.Add ("(月)");
			tempstrings.Add ("(且)");
			tempstrings.Add ("(マンダイ)");
			tempstrings.Add ("(Ｍｏｎｄａｙ)");

			break;
		case DayOfWeek.Tuesday:
			tempstrings.Add ("(かようび)");
			tempstrings.Add ("(火)");
			tempstrings.Add ("(炎)");
			tempstrings.Add ("(チューズダイ)");
			tempstrings.Add ("(Ｔｕｅｓｄａｙ)");

			break;
		case DayOfWeek.Wednesday:
			tempstrings.Add ("(すいようび)");
			tempstrings.Add ("(水)");
			tempstrings.Add ("(ウェンズダイ)");
			tempstrings.Add ("(Ｗｅｄｎｅｓｄａｙ)");
			tempstrings.Add ("(氷)");


			break;
		case DayOfWeek.Thursday:
			tempstrings.Add ("(もくようび)");
			tempstrings.Add ("(木)");
			tempstrings.Add ("(本)");
			tempstrings.Add ("(サーズダイ)");
			tempstrings.Add ("(Ｔｈｕｒｓｄａｙ)");


			break;
		case DayOfWeek.Friday:
			tempstrings.Add ("(きんようび)");
			tempstrings.Add ("(金)");
			tempstrings.Add ("(全)");
			tempstrings.Add ("(フライダイ)");
			tempstrings.Add ("(Ｆｒｉｄａｙ)");

			break;
		case DayOfWeek.Saturday:
			tempstrings.Add ("(どようび)");
			tempstrings.Add ("(土)");
			tempstrings.Add ("(士)");
			tempstrings.Add ("(サタダイ)");
			tempstrings.Add ("(Ｓａｔｕｒｄａｙ)");

			break;
		}

		youbi = arrayshuffle(tempstrings);
		
		foreach (string tempstr in youbi) {
			CreateUiFromPrefab(youbiprefab,tc,tempstr,parentitemyoubi);
			tc++;
			
		}


		tenki = new List<string> ();
		tenki.Add ("晴れ");
		tenki.Add ("かいせい");
		tenki.Add ("くもり");
		tenki.Add ("雨");
		tenki.Add ("ゆき");
		tenki.Add ("ふぶき");
		tenki.Add ("たいふう");
		tenki.Add ("みぞれ");
		tenki.Add ("のうむ");
		tenki.Add ("さじんあらし");
		tenki.Add ("えんむ");
		tenki.Add ("もうふぶき");
		tenki.Add ("きつねのよめいり");
		tenki.Add ("こがらし");
		tenki.Add ("かみなり");
		tenki.Add ("豆");

		tenki = arrayshuffle(tenki);

		itu = new List<string> ();
		itu.Add ("朝、");
		itu.Add ("昼、");
		itu.Add ("夜、");
		itu.Add ("ひるねちゅう、");
		itu.Add ("うしみつどき、");
		itu.Add ("ひづけがかわるしゅんかん、");
		itu.Add ("ある日");
		itu.Add ("まよなかに、");
		itu.Add ("きのう、");
		itu.Add ("ごぜん、");
		itu.Add ("ごご、");
		itu.Add ("１３～１６時に");
		itu.Add ("ゴールデンタイムに");
		itu.Add ("お昼ごろに、");
		itu.Add ("ゆうがた、");
		itu.Add ("本日未明、");
		itu.Add ("おうまがときに");
		itu.Add ("あさごはんのとき、");
		itu.Add ("へんなじかんに、");

		itu = arrayshuffle(itu);

		doko = new List<string> ();
		doko.Add ("リビングで");
		doko.Add ("ブルジュハリファで");
		doko.Add ("WindowsXPかべがみのあのそうげんで");
		doko.Add ("だがしやで");
		doko.Add ("竹林で");
		doko.Add ("めいろで");
		doko.Add ("ひみつきちで");
		doko.Add ("けんもんじょで");
		doko.Add ("ゆうえんちで");
		doko.Add ("ごみしょりじょうで");
		doko.Add ("プールで");
		doko.Add ("けんこうランドで");
		doko.Add ("海で");
		doko.Add ("おんせんで");
		doko.Add ("やきにくやで");
		doko.Add ("ブラジルで");
		doko.Add ("ふじ山で");
		doko.Add ("じぶんのへやで");
		doko.Add ("むじんとうで");
		doko.Add ("びょういんで");
		doko.Add ("こうえんで");
		doko.Add ("こうじげんばで");
		doko.Add ("さくらんぼのうえんで");
		doko.Add ("でぱーとで");
		doko.Add ("かくしとりでで");
		doko.Add ("がっこうで");
		doko.Add ("けいむしょで");
		doko.Add ("田んぼで");
		doko.Add ("上野で");
		doko.Add ("かぶぬしそうかいで");
		doko.Add ("ジンバブエで");
		doko.Add ("すかいつりーで");

		doko = arrayshuffle(doko);

		dare = new List<string> ();
		dare.Add ("じゃがいもみたいな人と");
		dare.Add ("ややこしい立場の人と");
	
		dare.Add ("先生と");
		dare.Add ("豆マニアと");
		dare.Add ("カウボーイのたいぐんが");
		dare.Add ("おとうさんと");
		dare.Add ("かせいじんと");
		dare.Add ("だれということもなく");
		dare.Add ("軍師と");
		dare.Add ("シャガールと");
		dare.Add ("犬と");
		dare.Add ("かぐやひめと");
		dare.Add ("きょにゅうあいどると");
		dare.Add ("しんはんにんと");
		dare.Add ("ひとりで");
		dare.Add ("おとうとと");
		dare.Add ("にんじゃと");
		dare.Add ("ゆうしゃっぽいかっこうのおじさんと");
		dare.Add ("白目をむいてるけどげんきな人と");
		dare.Add ("がんめんそうはくなおにいちゃんと");
		dare.Add ("パン粉まみれのおぼうさんと");
		dare.Add ("おかねもちと");
		dare.Add ("交つうせいりの人と");
		dare.Add ("「もうだめだ」がくちぐせのおじさんと");
		dare.Add ("マグロと");
		dare.Add ("さいばんちょうと");
		dare.Add ("おじいちゃんと");
		dare.Add ("せんちょうと");
		dare.Add ("ごにんたいほのプロと");
		dare.Add ("カレーのおうじさまと");

		dare = arrayshuffle(dare);




		donna = new List<string> ();
		donna.Add ("鉄の");
		donna.Add ("ぐんじょう色の");

		donna.Add ("たいりょうの");
		donna.Add ("あいしゅうただよう");
		donna.Add ("本格派の");
		donna.Add ("つねにかいてんしている");
		donna.Add ("甘いにおいの");
		donna.Add ("せんぞだいだいの");
		donna.Add ("おとうさんの");
		donna.Add ("もも色の");
		donna.Add ("Ｔシャツみたいな<");
		donna.Add ("うすくてじょうぶな");
		donna.Add ("ぺらぺらの");
		donna.Add ("こおった");
		donna.Add ("けむりがでている");
		donna.Add ("あつあつの");
		donna.Add ("みたことのない");
		donna.Add ("べとべとした");
		donna.Add ("まっきいろの");
		donna.Add ("ひかりかがやく");
		donna.Add ("どうもうな");
		donna.Add ("きょだいな");
		donna.Add ("よく手入れしてある");
		donna.Add ("すこしえがおの");
		donna.Add ("おきにいりの");
		donna.Add ("いんたーねっと上の");
		donna.Add ("はんぶんになった");
		donna.Add ("のびたりちぢんだりする");
		donna.Add ("めざわりな");
		donna.Add ("邪念に満ちた");
		donna.Add ("おおきくてくろい");
		donna.Add ("けいしきじょうの");
		donna.Add ("なまぐさい");
		donna.Add ("よく煮込んだ");
		donna.Add ("とんこつ風味の");

		donna = arrayshuffle(donna);

		nani = new List<string> ();
		nani.Add ("じゃがいもを");
		nani.Add ("船を");

		nani.Add ("にほんにんぎょうを");
		nani.Add ("ばくだんを");
		nani.Add ("おかあさんのへそくりを");
		nani.Add ("チョコレートを");
		nani.Add ("はんばーがーを");
		nani.Add ("えんぴつを");
		nani.Add ("てれびを");
		nani.Add ("りゅうせいぐんを");
		nani.Add ("ロボットを");
		nani.Add ("えほんを");
		nani.Add ("けがにんを");
		nani.Add ("ふうぜんのともしびを");
		nani.Add ("あかいいろをしたきつねを");
		nani.Add ("みどりいろのたぬきを");
		nani.Add ("ブタを");
		nani.Add ("よごれを");
		nani.Add ("やくたたずを");
		nani.Add ("ぼうを");
		nani.Add ("なにかを");
		nani.Add ("きおくを");
		nani.Add ("石炭を");
		nani.Add ("ゾウを");
		nani.Add ("ちゃんぽんめんを");
		nani.Add ("カレーを");
		nani.Add ("しゃっきんを");
		nani.Add ("おたがいを");
		nani.Add ("くつしたを");
		nani.Add ("ウニとイクラを");
		nani.Add ("ごりらを");
		nani.Add ("勇気を");
		nani.Add ("ふやけた肉まんを");

		nani = arrayshuffle(nani);

		dousita = new List<string> ();
		dousita.Add ("絞めました");
		dousita.Add ("あぶら絵にしました");

		dousita.Add ("わさびじょうゆに漬けました");
		dousita.Add ("となりにおきました");
		dousita.Add ("絞りました。");
		dousita.Add ("とばしました。");
		dousita.Add ("消しました。");
		dousita.Add ("見ました。");
		dousita.Add ("あらいました。");
		dousita.Add ("たべました。");
		dousita.Add ("とびこえました。");
		dousita.Add ("しらべました。");
		dousita.Add ("ふういんしました。");
		dousita.Add ("クレープ状にしました。");
		dousita.Add ("つくりました。");
		dousita.Add ("うめました。");
		dousita.Add ("わりました。");
		dousita.Add ("臼でごりごりしました。");
		dousita.Add ("とおくから見ました。");
		dousita.Add ("にこみました。");
		dousita.Add ("うごかしました。");
		dousita.Add ("ひっぱりました。");
		dousita.Add ("箱につめました。");
		dousita.Add ("ゆっくりねかせました。");

		dousita = arrayshuffle(dousita);

		matome = new List<string> ();
		matome.Add ("じごくでした");
		matome.Add ("さんぽういちりょうぞんでござる");

		matome.Add ("まさにうぃんうぃんのかんけいです");
		matome.Add ("ふにおちない");
		matome.Add ("ただただ、時が解決するのを待つばかりです");
		matome.Add ("たのしかったです");
		matome.Add ("もうにどとやりたくないです");
		matome.Add ("しゅぎょうがたりないとおもいました");
		matome.Add ("こういうのはやめたほうがいいとおもいました");
		matome.Add ("あしたがたのしみです");
		matome.Add ("さっぱりしました");
		matome.Add ("おかあさんにおこられました");
		matome.Add ("これがじんせいだなとおもいました");
		matome.Add ("もっとつづけばいいのになあとおもいました");
		matome.Add ("ずるいぞふとし君");
		matome.Add ("あれはなんだったんだろう");
		matome.Add ("ゆめかとおもいました");
		matome.Add ("うそです");
		matome.Add ("はやると思います");
		matome.Add ("すごくつかれました");
		matome.Add ("まわりがざわめいてました");
		matome.Add ("びっくりです");
		matome.Add ("ねつがでました");
		matome.Add ("ぐあいがわるいです");
		matome.Add ("にがにがしい");

		matome = arrayshuffle(matome);

		kurukurumaxcount = new int[9];

		/*
		kurukurumaxcount[0] = youbi.Count;
		kurukurumaxcount[1] = tenki.Count;
		kurukurumaxcount[2] = itu.Count;
		kurukurumaxcount[3] = doko.Count;
		kurukurumaxcount[4] = dare.Count;
		kurukurumaxcount[5] = donna.Count;
		kurukurumaxcount[6] = nani.Count;
		kurukurumaxcount[7] = dousita.Count;
		kurukurumaxcount[8] = matome.Count;
*/

		kurukurumaxcount[0] = youbi.Count - 1;
		kurukurumaxcount[1] = tenki.Count - 1;
		kurukurumaxcount[2] = itu.Count - 1;
		kurukurumaxcount[3] = doko.Count - 1;
		kurukurumaxcount[4] = dare.Count - 1;
		kurukurumaxcount[5] = donna.Count - 1;
		kurukurumaxcount[6] = nani.Count - 1;
		kurukurumaxcount[7] = dousita.Count - 1;
		kurukurumaxcount[8] = matome.Count - 1;


	}
	
	// Update is called once per frame
	void Update () {
		if (isStoped == false) {

			waittime();



		}


	}

	void textfieldcreate(int susumi) {


		int tc = 0;

		switch (susumi) {
			
		case 0:
			break;
		case 1:

			foreach (string tempstr in tenki) {
				CreateUiFromPrefab(tenkiprefab,tc,tempstr,parentitemtenki);
				tc++;
				
			}
			
			break;
			
		case 2:

			foreach (string tempstr in itu) {
				CreateUiFromPrefab(ituprefab,tc,tempstr,parentitemitu);
				tc++;
				
			}

			break;
			
		case 3:

			foreach (string tempstr in doko) {
				CreateUiFromPrefab(dokoprefab,tc,tempstr,parentitemdoko);
				tc++;
				
			}

			break;
			
		case 4:

			foreach (string tempstr in dare) {
				CreateUiFromPrefab(dareprefab,tc,tempstr,parentitemdare);
				tc++;
				
			}

			break;
			
		case 5:

			foreach (string tempstr in donna) {
				CreateUiFromPrefab(donnaprefab,tc,tempstr,parentitemdonna);
				tc++;
				
			}

			break;
			
		case 6:

			foreach (string tempstr in nani) {
				CreateUiFromPrefab(naniprefab,tc,tempstr,parentitemnani);
				tc++;
				
			}

			break;
			
		case 7:

			foreach (string tempstr in dousita) {
				CreateUiFromPrefab(dousitaprefab,tc,tempstr,parentitemdousita);
				tc++;
				
			}

			break;
			
		case 8:
			foreach (string tempstr in matome) {
				CreateUiFromPrefab(matomeprefab,tc,tempstr,parentitemmatome);
				tc++;
			
			}

			break;
			
		}
	}


	void textmove(string findtagname) {
		GameObject[] ttt;
		RectTransform pos;
		float temppos;


		ttt = GameObject.FindGameObjectsWithTag (findtagname);



		foreach (GameObject tempobj in ttt) {
			
			pos = tempobj.GetComponent<Text>().rectTransform;
			
			if (pos.localPosition.y >= TEXT_HEIGHT) {
				temppos=-(kurukurumaxcount[susumiguai] * TEXT_HEIGHT) + textmoveheight;
				
			} else {
				temppos=pos.localPosition.y + textmoveheight;
				
			}
			tempobj.GetComponent<Text>().rectTransform.localPosition = new Vector2(pos.localPosition.x,temppos);
		}

	}

	void kurukurutextupdate() {




		if (kurukurucount >= kurukurumaxcount[susumiguai]+1) {
			kurukurucount=0;
		}

		switch (susumiguai) {

			case 0:
				//youbiText.text = youbi [kurukurucount];

			textmove (youbitag);


				break;
			case 1:
				//tenkiText.text = tenki [kurukurucount];

			textmove (tenkitag);

				break;
				
			case 2:
			textmove (itutag);
				break;

			case 3:
			textmove (dokotag);

				break;

			case 4:
			textmove (daretag);
				break;

			case 5:
			textmove (donnatag);
				break;

			case 6:
			textmove (nanitag);
				break;

			case 7:
			textmove (dousitatag);
				break;

			case 8:
			textmove (matometag);
				break;

		}

		if (nowwait) {

			//Debug.Log("stop" + stopcount + " kurukuru" + kurukurucount + " tkurukuru" + Math.Truncate(kurukurucount));


			//if (stopcount == Math.Truncate(kurukurucount)) {
				if (stopcount == kurukurucount) {
				Debug.Log("stop" + stopcount + " kurukuru" + kurukurucount );
				susumiguai ++;
				if (susumiguai > (textfieldcount - 1)) {
					isStoped = true;
					//nextBtn.enabled = false;
				} else {
					kurukurucount=0;
					stopcount=0;
					ktime=0;
					textfieldcreate(susumiguai);
				}
				nowwait=false;

			}
		}

	}


	void waittime(){
		
		ktime = ktime + Time.deltaTime;
		if (ktime >= 0.03f) {
			ktime=0;
			kurukurucount = kurukurucount + kurukuruwariai;
			kurukurutextupdate ();
		}

		//debugtext.text = Convert.ToString(kurukurucount);

		
	}

	public void onBtnClick() {

		if (isStoped == true) {
			//Debug.Log(youbi[stopedcounts[0]]);

			databaseins();

			Application.LoadLevel ("menu");
		} else {
			if (nowwait == false) {


				stopcount=Convert.ToInt32(Math.Ceiling(kurukurucount));
				if (stopcount >= kurukurumaxcount[susumiguai]) {
					stopcount =0;
				}

				stopedcounts.Add (stopcount);

				nowwait=true;
				
			}
		}


	}

	public void onmodoruBtnClick() {
		Application.LoadLevel ("menu");
	}


	void databaseins() {

		string hid = hidukeText.text;

		SqliteDatabase sqlDB = new SqliteDatabase("diarydb.db");

		//日記書き直しかどうかチェックする
		string squery = "select count(id) counts from detaramediary where hiduke = '" + hid + "'";
		DataTable db = sqlDB.ExecuteQuery(squery);
		int cnt = 0;

		if (db != null) {
			foreach (DataRow dr in db.Rows) {
				cnt = (int)dr["counts"];
			}

		}



		//データがあったら削除
		if (cnt > 0) {
			string dquery = "delete from detaramediary where hiduke = '" + hid + "'";
			sqlDB.ExecuteNonQuery(dquery);
		}

		//insert
		string query = "insert into detaramediary(hiduke,youbi,tenki,itu,doko,dare,donna,nani,dousita,matome,tweetfg) values('" +
			hidukeText.text + "','" + youbi[stopedcounts[0]] + "','" +
				tenki[stopedcounts[1]] + "','" + itu[stopedcounts[2]] +
				"','" + doko[stopedcounts[3]] + "','" +
				dare[stopedcounts[4]] + "','" + donna[stopedcounts[5]] +
				"','" + nani[stopedcounts[6]] + "','" + dousita[stopedcounts[7]] +
				"','" + matome[stopedcounts[8]] + "',0)";
		sqlDB.ExecuteNonQuery(query);


	}


}
