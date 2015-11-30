using UnityEngine;
using System.Collections;

public class SpeechData {
    string title;
    string[] lines;
    bool question;
    bool singleLine;

    public SpeechData(string []arr,string name,bool question) {
        lines = arr;
        title = name;
        this.question = question;
        singleLine = false;
    }
    public SpeechData(string[] arr, string name, bool question, bool single) {
        lines = arr;
        title = name;
        this.question = question;
        singleLine = single;
    }

    public bool isQuestion() {
        return question;
    }
    public string[] getLines() {
        return lines;
    }
    public string getLine(int index) {
        return lines[index];
    }
    public void setLines(string[] newLines) {
        lines = newLines;
    }

    
    
    /// <summary>
    /// Returns the title of this speech
    /// </summary>
    /// <returns></returns>
    override
    public string ToString() {
        return title;
    }
}
