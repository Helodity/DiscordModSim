using UnityEngine;

public static class TypingLists
{
    readonly static string[] CrashoutList =
    {
        "shut Up SHUT UP GRAHHHH AHAHAHAH I DONT CAREEE I DONT CAREEREEEEEE",
        "ALL MY EVIL PLANS... ITS COME TOGETHER! ALL OF THE MEMBERS OF THE DREAMSMP ARE UNDER NDA AND THEY HAVE BEEN FOR YEARS!",
        "That's it. THAT'S IT. I have had enough of you! Let me say this FIRST. Josh has done an absolutely AMAZING job and I am not just saying that just to say it!",
        "That's what THE POINT OF THE MASK IS!!!!"
    };

    readonly static string[] KittenList =
    {
        "Hey, are you there? Haha.. I know this may sound cheesy, but.. I just really love you.",
        "Can we be... more than friends? Can you be... more than.. just my discord kitten?",
        "Can we call more? I like listening to your voice. :point_right: :point_left:",
        "Rules for discord Kitten: 1) No lying to Daddy. 2) Respect Daddy 3) ALWAYS ask for permission before taking pills."
    };
    readonly static string[] PretendKittenList =
    {
        "Hiii~. I'm lookin' for a suuuper cute discowd mod to take cawe of meeee! Pwease be nice to me!!",
        "Hewwoooo~! I wuv and miss you lots, Onii-chan!!!",
        "How old am I? Tee-hee! That's my secret!"
    };
    readonly static string[] ModerateList =
    {
        "for the last time PLEASE do not post memes in #general",
        "that's a violation of Rule #829.b.2, which you would OBVIOUSLY know if you read the rules.",
        "j*b is really triggering to people, I'm gonna have to mute you for that one.",
        "Nobody cares about your trauma here -- put that in #vent please"
    };


    public static string GetRandomTypingPrompt(TypingList list)
    {
        switch (list)
        {
            case TypingList.Crashout:
                return getRandomFromList(CrashoutList);
            case TypingList.Kitten:
                return getRandomFromList(KittenList);
            case TypingList.PretendKitten:
                return getRandomFromList(PretendKittenList);
            case TypingList.Moderate:
                return getRandomFromList(ModerateList);

        }

        Debug.LogError($"Couldn't return a prompt for list {list}!");
        return null;
    }


    static string getRandomFromList(string[] list)
    {
        return list[Random.Range(0, list.Length)];
    }
}

public enum TypingList
{
    Crashout,
    Kitten,
    PretendKitten,
    Moderate
}
