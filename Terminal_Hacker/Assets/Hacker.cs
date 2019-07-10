using UnityEngine;

public class Hacker : MonoBehaviour
{

    string[] level1Passwords = { "books", "aisle", "self", "password", "font" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
    }


    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Terminal.WriteLine("Error");
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password, hint: " + password.Anagram());
    }

    // Update is called once per frame
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        } else
        {
            Terminal.WriteLine("Wrong, try again!");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _________
   /        //
  /        //
 /________//
(________(/
"
                );
                break;
            case 2:
                Terminal.WriteLine(@"
         .::::::::::.        -(_)====u         .::::::::::.
       .::::''''''::::.                      .::::''''''::::.
     .:::'          `::::....          ....::::'          `:::.
    .::'             `:::::::|        |:::::::'             `::.
   .::|               |::::::|_ ___ __|::::::|               |::.
   `--'               |::::::|_()__()_|::::::|               `--'
    :::               |::-o::|        |::o-::|               :::
    `::.             .|::::::|        |::::::|.             .::'
     `:::.          .::\-----'        `-----/::.          .:::'
       `::::......::::'                      `::::......::::'
         `::::::::::'                          `::::::::::'

"
                );
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
        
    }
}
