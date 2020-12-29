using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class IsLevelEnabled : MonoBehaviour
{
    private Button secondLevelButton;

    public static string isLevelEnabled;

    User user = new User();

    private void Start()
    {
        secondLevelButton = GetComponent<Button>();

        //PostToDatabase();

        RetrieveFromDatabase();
    }

    //private void PostToDatabase()
    //{
    //    User user = new User();
    //    RestClient.Put("https://test-firebase-81e55-default-rtdb.firebaseio.com/" +"open_another"+ ".json", user);
    //}

    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>("https://test-firebase-81e55-default-rtdb.firebaseio.com/" + "open_another" + ".json").Then(response =>
        {
              user = response;

              isLevelEnabled = user.open_another;

            CheckLevel();
        });
    }

    private void CheckLevel() 
    {
        if (isLevelEnabled.Equals("true")) secondLevelButton.interactable = true;
    }
}


