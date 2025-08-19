namespace SmallBlog.External.AsSunnahFoundation;

public class Hadith
{
    public IEnumerable<string> GetAllHadiths()
    {
        List<string> hadiths = new List<string>();

        var randomVal = new Random().Next(1, 3);

        if (randomVal == 1)
        {
            return [];
        }

        hadiths.AddRange([
            "Abu Huraira reported: The Messenger of Allah, peace and blessings be upon him, said, 'Whoever believes in Allah and the Last Day should speak goodness or remain silent.'",
            "The best among you are those who have the best manners and character."
        ]);

        return hadiths;
    }
}