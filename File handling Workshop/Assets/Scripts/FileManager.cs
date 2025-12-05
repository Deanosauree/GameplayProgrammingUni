using UnityEngine;
using System.IO;

using Unity.Collections;

public class FileManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created#
    private string[] names;
    private string[] titles;
    private static FileManager instance;
    public FileManager getInstance()
    {
        return instance;
    }
    public void Awake()
    {
        instance = this;
        string namePath = "Assets/StreamingAssets/names.txt.txt";
        string titlePath = "Assets/StreamingAssets/titles.txt.txt";

        if (File.Exists(namePath))
        {
            names = File.ReadAllLines(namePath);
        }
        else
        {
            Debug.Log($"{namePath} Not Found");
        }
        if (File.Exists(titlePath))
        {
            titles = File.ReadAllLines(titlePath);
        }
        else
        {
            Debug.Log($"{titlePath} Not Found");
        }
    }
    void Start()
    {
        
        Debug.Log(GenerateRandomName());
        print(GenerateRandomName());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string GenerateRandomName()
    {
        return names[Random.Range(0, names.Length)] + " " + titles[Random.Range(0, titles.Length)];    
    }
}
