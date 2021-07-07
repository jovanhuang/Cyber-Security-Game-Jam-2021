﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine.SceneManagement;
public class PasswordController : MonoBehaviour
{
    private string password;
    public GameObject inputField;
    public TMP_InputField inputFieldElement;
    private bool isStrongPwd;
    public TMP_Text errMsg;
    public GameObject mainDoor;
    public GameObject[] door;
    public Animator[] gateAnim;
    public GameObject pwdInputField;
    public GameObject[] shield;
    private int machineNumber;
    public GameObject gamePart2_dialogue;
    private List<string> list;
    private string path;
    [SerializeField] private GameObject endOfPart1;
     public void ReadStringInput(string s)
    {
        password = s;
        errMsg.text ="";
    }

    public void Update()
    {

            if (Input.GetKeyDown(KeyCode.Return)) 
            {
                Regex rgx = new Regex("[^A-Za-z0-9]");
                path = Application.dataPath + "/passwordLog.txt";
                if(!File.Exists(path))
                {
                    File.WriteAllText(path, ""); //create the file
                }
                Debug.Log("Application Data Path where - "+Application.dataPath);
                list = File.ReadLines(path).ToList();
                    // hash = new HashSet < string > (list);
                if (password.Length >= 8)
                {
                    if (rgx.IsMatch(password))
                    {
                        if(password.Any(char.IsDigit))
                        {
                            if(password.Any(char.IsUpper))
                            {
                                if(password.Any(char.IsLower))
                                {
                                    if(!list.Contains(password))
                                    {
                                        Debug.Log("so it reach here");
                                        inputFieldElement.image.color = Color.green;
                                        errMsg.color = Color.green;
                                        errMsg.text = "You have successfully set the password.";
                                        isStrongPwd = true;
                                    }
                                    else
                                    {
                                        inputFieldElement.image.color = Color.red;
                                        errMsg.text = "This password matches the password on another machine. Please use unique passwords!";
                                        isStrongPwd = false;
                                        Debug.Log("unique");
                                    }
                                    
                                }
                                else
                                {
                                    inputFieldElement.image.color = Color.red;
                                    errMsg.text = "Weak password. The password must have at least one Lowercase character!";
                                    isStrongPwd = false;
                                    Debug.Log("lower case char");
                                }
                            }
                            else
                            {
                                inputFieldElement.image.color = Color.red;
                                errMsg.text = "Weak password. The password must have at least one Uppercase character!";
                                isStrongPwd = false;
                                Debug.Log("uppercase");
                            }
                        }
                        else
                        {
                            inputFieldElement.image.color = Color.red;
                            errMsg.text = "Weak password. The password must have at least one digit!";
                            isStrongPwd = false;
                            Debug.Log("one digit");
                        }
                    }
                    else
                        {
                            inputFieldElement.image.color = Color.red;
                            errMsg.text = "Weak password. The password must have at least one special character!";
                            isStrongPwd = false;
                            Debug.Log("special");
                        }
                }
                else
                {
                    
                    inputFieldElement.image.color = Color.red;
                    errMsg.text = "Weak password. The password must have at least eight characters!";
                    isStrongPwd = false;
                    Debug.Log("atleast8");
                }
            }
            if (Input.GetKeyUp(KeyCode.Return)) 
            { 
                Debug.Log("did it reach here first");
                inputFieldElement.image.color = Color.white;
                Debug.Log("did it reach here");
                if (isStrongPwd) // if password passes
                {
                    File.AppendAllText(path, password+"\n");
                    Debug.Log($"woohoo the machine is {machineNumber} ");
                    mainDoor.SetActive(true);
                    inputField.SetActive(false);
                    switch (machineNumber)
                    {
                        case 1:
                            door[0].SetActive(true);
                            // shieldAnim[0].SetBool(boolstr, true);
                            shield[9].SetActive(true);
                            shield[0].SetActive(false);
                            break;
                        case 2:
                            door[1].SetActive(true);
                            // shieldAnim[1].SetBool(boolstr+"1", true);
                            shield[0].SetActive(true);
                            shield[1].SetActive(false);
                            break;
                        case 3:
                            door[2].SetActive(true);
                            // shieldAnim[2].SetBool(boolstr+"2", true);
                            shield[1].SetActive(true);
                            shield[2].SetActive(false);
                            break;
                        case 4:
                            door[3].SetActive(true);
                            // shieldAnim[3].SetBool(boolstr+"3", true);
                            shield[2].SetActive(true);
                            shield[3].SetActive(false);
                            break;
                        case 5:
                            door[4].SetActive(true);
                            gateAnim[0].SetBool("playMovingUp", true);
                            // shieldAnim[4].SetBool(boolstr+"4", true);
                            shield[3].SetActive(true);
                            shield[4].SetActive(false);
                            break;
                        case 6:
                            door[5].SetActive(true);
                            // shieldAnim[5].SetBool(boolstr+"5", true);
                            shield[4].SetActive(true);
                            shield[5].SetActive(false);
                            break;
                        case 7:
                            door[6].SetActive(true);
                            // shieldAnim[6].SetBool(boolstr+"6", true);
                            shield[5].SetActive(true);
                            shield[6].SetActive(false);
                            break;
                        case 8:
                            door[7].SetActive(true);
                            // shieldAnim[7].SetBool(boolstr+"7", true);
                            shield[6].SetActive(true);
                            shield[7].SetActive(false);
                            break;
                        case 9:
                            door[8].SetActive(true);
                            // shieldAnim[8].SetBool(boolstr+"8", true);
                            shield[7].SetActive(true);
                            shield[8].SetActive(false);
                            break;
                        case 10:
                            gateAnim[1].SetBool("isPressed", true);
                            door[9].SetActive(true);
                            shield[8].SetActive(true);
                            shield[9].SetActive(false);
                            break;
                    }
                }
                inputFieldElement.text ="";
                inputFieldElement.ActivateInputField();
            }  
    }
    void OnTriggerEnter2D(Collider2D other) {
      
        if (other.gameObject.name == "TileGroundTop (62)")
        {
            SceneManager.LoadScene("Introduction_passwordhacking");
        }
        if (other.gameObject.name == "button (11)")
        {
            pwdInputField.SetActive(false);
            gamePart2_dialogue.SetActive(true);
            endOfPart1.SetActive(true);
        }
        else
        {
            if (other.gameObject.name == "button (1)")
            { 
                machineNumber = 1;
                afterActionSettings();
                
            }
            else if (other.gameObject.name == "button (2)")
            {
                machineNumber = 2;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (3)")
            {
                machineNumber = 3;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (4)")
            {
                machineNumber = 4;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (5)")
            {
                machineNumber = 5;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (6)")
            {
                machineNumber = 6;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (7)")
            {
                machineNumber = 7;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (8)")
            {
                machineNumber = 8;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (9)")
            {
                machineNumber = 9;
                afterActionSettings();
            }
            else if (other.gameObject.name == "button (10)")
            {
                machineNumber = 10;
                afterActionSettings();
            }
        }
    }
    private void afterActionSettings()
    {
        pwdInputField.SetActive(true);
        inputField.SetActive(true);
        errMsg.text ="";
        errMsg.color = Color.white;
        inputFieldElement.ActivateInputField();
        inputFieldElement.text ="";
        isStrongPwd = false;
    }
}

