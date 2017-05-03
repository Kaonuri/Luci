using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene
{
    private static Scene instance = null;

    public bool local = true;

    private Scene()
    {

            }

    public static Scene Instance
    {
        get
        {
            if (instance == null)
                instance = new Scene();

            return instance;
        }
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene("Title");
        Cursor.visible = false;
    }

    public void GoToPlayScene()
    {
        if (local)
        {
            SceneManager.LoadScene("Play");
            return;
        }
        SceneManager.LoadScene("Play_Network");
        Cursor.visible = false;
    }

    public void GoToEndScene()
    {
        SceneManager.LoadScene("End");
        Cursor.visible = false;
    }

    public void GoToWaitScene()
    {
        SceneManager.LoadScene("Wait");
        Cursor.visible = false;
    }

    public void ManualUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToWaitScene();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            local = true;
            GoToTitleScene();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            local = false;
            GoToTitleScene();
            return;
        }
    }
}
