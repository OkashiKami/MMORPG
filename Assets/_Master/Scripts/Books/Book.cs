using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum BookType { None, Item, Skill, Quest, }
public abstract class Book : MonoBehaviour
{
    public string title;
    public BookType type;

    public abstract void Update();
    public abstract void Start();


    public static void AddItem(INIParser p, Item item)
    {
        string defaultpath = Application.dataPath + "/StreamingAssets/libraries/";
        p.Open(defaultpath + "items.ini");
        if (!p.IsSectionExists(item.GetItemCode()))
        {
            p.WriteValue(item.GetItemCode(), "id", item.id);
            p.WriteValue(item.GetItemCode(), "name", item.name);
            p.WriteValue(item.GetItemCode(), "stackable", item.stackable.ToString());
            p.WriteValue(item.GetItemCode(), "stack", item.stack.ToString());
            p.WriteValue(item.GetItemCode(), "maxstacksize", item.maxstacksize);
            p.WriteValue(item.GetItemCode(), "type", item.type.ToString());
            p.WriteValue("Calculator", "itemcount", (int.Parse(p.ReadValue("Calculator", "itemcount", "0")) + 1));
        }
        else Debug.Log("Item Already Exist");
        p.Close();
    }
    public static void RemoveItem(INIParser p, Item item)
    {
        string defaultpath = Application.dataPath + "/StreamingAssets/libraries/";
        p.Open(defaultpath + "items.ini");
        if (p.IsSectionExists(item.GetItemCode()))
        {
            if (int.Parse(p.ReadValue("Calculator", "itemcount", "0")) > 0)
            {
                p.SectionDelete(item.name + " " + item.type);
                p.WriteValue("Calculator", "itemcount", (int.Parse(p.ReadValue("Calculator", "itemcount", "0")) - 1));
            }
        }
        else Debug.Log("Item Does Not Exist");
        p.Close();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Book), true)]
public class BookEditor : Editor
{
    private Vector2 vector;

    public override void OnInspectorGUI()
    {
        Book tar = (Book)target;
        GUI.skin = Resources.Load<GUISkin>("editor_skin");
        Repaint();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Box(tar.title);
        GUILayout.Box(tar.type.ToString(), GUILayout.Width(75));
        EditorGUILayout.EndHorizontal();
        vector = EditorGUILayout.BeginScrollView(vector);
        switch (tar.type)
        {
            case BookType.Item:
                foreach (Item i in R.findItems())
                {
                    GUILayout.Box(string.Format("{0} [{1}]", i.name, i.type));
                }
                break;
            case BookType.Skill:
                foreach (Skill s in R.findSkills())
                {
                    GUILayout.Box(string.Format("{0} [{1}]", s.name, s.type));
                }
                break;
            case BookType.Quest:

                break;
        }
        EditorGUILayout.EndScrollView();
    }
}
public class BookEditrWindow : EditorWindow
{
    public static BookEditrWindow book;
    private Vector2 vector;
    public static INIParser parser = new INIParser();

    [MenuItem("Book/Edit")]
    public static void Init()
    {
        // Get existing open window or if none, make a new one:
        book = (BookEditrWindow)EditorWindow.GetWindow(typeof(BookEditrWindow));
        parser = new INIParser();
        book.Show();
    }
    
    Book SelectedBook;
    public void OnGUI()
    {
        GUI.skin = Resources.Load<GUISkin>("editor_skin");
        Repaint();

        
        if(SelectedBook == null)
        {
            foreach(Book book in FindObjectsOfType<Book>())
            {
                if(GUILayout.Button(book.title))
                {
                    SelectedBook = book;
                }
            }
        }
        else if(SelectedBook != null)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Box(SelectedBook.title);
            GUILayout.Box(SelectedBook.type.ToString(), GUILayout.Width(75));
            EditorGUILayout.EndHorizontal();
            vector = EditorGUILayout.BeginScrollView(vector);
            switch (SelectedBook.type)
            {
                case BookType.Item:
                    foreach (Item i in R.findItems())
                    {
                        GUILayout.Box(string.Format("{0} [{1}]", i.name, i.type));
                    }
                    break;
                case BookType.Skill:
                    foreach (Skill s in R.findSkills())
                    {
                        GUILayout.Box(string.Format("{0} [{1}]", s.name, s.type));
                    }
                    break;
                case BookType.Quest:

                    break;
            }
            EditorGUILayout.EndScrollView();
        }


        Item testItem = new Item("Health", true, 64, ItemType.Potion);
        string defaultpath = Application.dataPath + "/StreamingAssets/libraries/";
        parser.Open(defaultpath + "items.ini");
        if (int.Parse(parser.ReadValue("Calculator", "itemcount", "0")) < 1)
        {
            if(GUILayout.Button("Add"))
            { 
                Book.AddItem(parser, testItem);
            }
        }
        if (int.Parse(parser.ReadValue("Calculator", "itemcount", "0")) > 0)
        {
            if (GUILayout.Button("Delete"))
            {
                Book.RemoveItem(parser, testItem);
            }
        }
        parser.Close();
    }
}
#endif