using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login_script : MonoBehaviour {
	
	public Text emailText;
	public Text passwordText;
	public Text responseText;
	public Text errorText;
	public Button loginButton;
	public Button logoutButton;
	
	public List<String> errors;
	private string url_login = "http://localhost/unityloginexample/login.php";
	
	public void DoLogin() {
		StartCoroutine(Login());
	}
	
	public void DoLogout(){
		StartCoroutine(Logout());
	}
    IEnumerator Login() {
		WWWForm form = new WWWForm();
		form.AddField("username", emailText.text);
		form.AddField("password", passwordText.text);
		WWW www = new WWW(url_login, form);
        yield return www;
		
			    errors.Add("Cannot Leave Username Empty");
				errors.Add("Cannot Leave Password Empty");
				errors.Add("Cannot Leave Username/Password Empty");
				
				if(emailText.text != "" && passwordText.text != ""){
					errorText.text = "";
					responseText.text = www.text;
					loginButton.gameObject.SetActive(false);
				}
				
			    if(emailText.text == ""){
					errors.Add("Cannot Leave Username Empty");
					errorText.text = errors[0];
                    Debug.Log("Form error");
			    } 
				
				if(passwordText.text == ""){
					errorText.text = errors[1];
					Debug.Log("Form error");
				}
				
				if(emailText.text == "" && passwordText.text == ""){
					errorText.text = errors[2];
					Debug.Log("Form error");
				}
				
				if(www.text == "Username doesn't exist"){
					loginButton.gameObject.SetActive(true);
				}
	}
	
	IEnumerator Logout(){
		yield return responseText.text = "";
		loginButton.gameObject.SetActive(true);
	}
    void Start() {
	}
	
	void Update() {
		
	}
}
