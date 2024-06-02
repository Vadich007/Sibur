namespace Interview;

public record Visitor(string name, int age, bool sex, int friendsCount, string surname) { }

public static class TimeOfDay
{
    public static int EndMorning = 10;
    public static int EndDay = 20;
} 

public class Greeter
{
    static List<Visitor> m_Visitors = new List<Visitor>();
    public void PrintInvitation(Visitor visitor)
    {
        try
        {
            if (DateTime.Now.Hour < TimeOfDay.EndMorning) Console.WriteLine("Good morning");
            else if (DateTime.Now.Hour >= TimeOfDay.EndMorning && DateTime.Now.Hour < TimeOfDay.EndDay) Console.WriteLine("Good day");
            else Console.WriteLine("Good evening");

            Console.Write(visitor.sex ? "Mr " : "Mrs ");
            Console.WriteLine(visitor.name + " " + visitor.surname + ".");
            Console.WriteLine("We are glad to see you" + (m_Visitors.Contains(visitor) ? " again.":"."));

            m_Visitors.Add(visitor);

            Console.WriteLine("We want to invite you {0}to the party.", 
                visitor.friendsCount == 0 ? String.Empty : "and your " + visitor.friendsCount + " friends ");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PrintInvitationAsync(Visitor visitor)
    {
        await Task.Run(() => PrintInvitation(visitor));
    }
}