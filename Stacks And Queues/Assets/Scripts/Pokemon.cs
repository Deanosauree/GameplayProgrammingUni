using UnityEngine;

public class Pokemon : MonoBehaviour
{
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private bool isCaught = false;
    [SerializeField] private string name;
    
    public string GetName()
    {
        return name;
    }
    public int GetLevel()
    {
        return level;
    }
    public bool GetIsCaught()
    {
        return isCaught;
    }

    public void SetLevel(int levelSet)
    {
        this.level = levelSet;
    }
    public void SetIsCaught(bool isCaught)
    {
        this.isCaught = isCaught;
        this.gameObject.SetActive(!isCaught);
    }

}
