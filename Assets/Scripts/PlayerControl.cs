using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{

    public float speed;

    private CharacterController controller;
    private PCtoNPC quest;

    void Start()
    {

        controller = GetComponent<CharacterController>();
        quest = GetComponent<PCtoNPC>();

    }

    public string getQuestNPC() {
        return quest.getName();
    }
    public bool isQuesting() {
        return quest.questing();
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.UpArrow))
        {
            //vector3.right for x axis, vector3.up for y axis, and vector3.forward for z axis, 
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }

        //rotate right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0);
        }
    }

    void OnTriggerStay(Collider coll) {
        if (Input.GetButtonDown("Action")) {
            if (coll.tag.Equals("Talkable")) {
                if (!quest.questing()) {
                    quest.startQuest(coll.name);
                    coll.SendMessage("startTalking");
                } else {
                    if(getQuestNPC() == coll.name) {
                        coll.SendMessage("endQuest");
                    } else {
                        coll.SendMessage("busySpeech");
                    }
                }
            }else if (coll.tag.Equals("Searchable")) {
                coll.SendMessage("onSearch");
            }
        }
    }
}
