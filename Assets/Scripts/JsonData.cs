using UnityEngine;
using System.IO;

[System.Serializable]
public class Dialogue
{
    public string text;
}
public class JsonData
{
    public Dialogue dialogue;

    public static JsonData CreateFromJSON()
    {
        string path = Path.Combine(Application.absoluteURL, "Assets/Samples/testDialogue.json");
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            Dialogue dialogue = JsonUtility.FromJson<Dialogue>(jsonString);

            JsonData jsonHandler = new JsonData();
            jsonHandler.dialogue = dialogue;
            return jsonHandler;
        }
        else
        {
            Debug.LogError("File not found at " + path);
            return null;
        }
    }
}
