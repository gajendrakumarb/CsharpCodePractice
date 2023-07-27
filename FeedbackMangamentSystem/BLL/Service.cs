namespace BLL;
using BOL;
using DAL;

public class Service
{
    public static List<TopicList> GetAllTopic()
    {
        return DBTestManager.GetAllTopic();
    }

    public static List<StudentFeedback> GetAllStudent()
    {
        return DBTestManager.GetAllStudnet();
    }

    public static void InsertFeedback(StudentFeedback s)
    {
        DBTestManager.InsertFeedback(s);
    }


}
