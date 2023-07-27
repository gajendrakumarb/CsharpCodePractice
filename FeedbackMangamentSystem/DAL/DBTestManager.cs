namespace DAL;
using BOL;
using MySql.Data.MySqlClient;

public class DBTestManager
{
    public static string conString = @"server=192.168.10.150;port=3306;user=dac31;password=welcome;database=dac31";

    public static List<TopicList> GetAllTopic()
    {
        //created Department List
        List<TopicList> tlist = new List<TopicList>();
        //create connection obj
        MySqlConnection con = new MySqlConnection();
        //set connection string to connection obj
        con.ConnectionString = conString;
        //create command obj
        MySqlCommand cmd = new MySqlCommand();
        //associate existing connection to command obj
        cmd.Connection = con;
        String Query = "Select * From TopicList";
        //set query to command obj
        cmd.CommandText = Query;

        try
        {
            //open connection 
            con.Open();
            //execute command obj and access data reader as output from execution 
            MySqlDataReader reader = cmd.ExecuteReader();
            //iterate data reader
            while (reader.Read())
            {
                //extract each record from data reader 
                int srno = int.Parse(reader["srno"].ToString());
                string topicname = reader["topicname"].ToString();
                
                //create department obj
                TopicList tl = new TopicList
                {
                    SrNO = srno,
                    TopicName = topicname
                    
                };
                //add dept obj to dlist
                tlist.Add(tl);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            //close connection 
            con.Close();
        }
        
        return tlist;
    }


   public static List<StudentFeedback> GetAllStudnet()
    {
       
        List<StudentFeedback> slist = new List<StudentFeedback>();
       
        MySqlConnection con = new MySqlConnection();
       
        con.ConnectionString = conString;
        
        MySqlCommand cmd = new MySqlCommand();
        
        cmd.Connection = con;
        String Query = "Select * From StudentFeedback";
       
        cmd.CommandText = Query;

        try
        {
           
            con.Open();
            
            MySqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                
                int srno = int.Parse(reader["srno"].ToString());
                
                string d = reader["d"].ToString();
                string sname = reader["sname"].ToString();
                string topicname = reader["topicname"].ToString();
                string module = reader["module"].ToString();
                string faculty = reader["faculty"].ToString();
                int psr=int.Parse(reader["psr"].ToString());
                int ps= int.Parse(reader["ps"].ToString());
                string comment = reader["comment"].ToString();
               
                StudentFeedback sl = new StudentFeedback
                {
                    SrNO = srno,
                    D = d,
                    StudentName = sname,
                    TopicName = topicname,
                    Module = module,
                    Faculty = faculty,
                    PSR = psr,
                    PS = ps,
                    Comment = comment

                    
                };
                
                slist.Add(sl);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            
            con.Close();
        }
        
        return slist;
    }

public static bool InsertFeedback(StudentFeedback s)
    {
        //Console.WriteLine("In insert ");
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        String Query = "insert into studentFeedback values(" + s.SrNO + ",'" + s.D + "','" + s.StudentName + ",'" + s.TopicName + ",'" + s.Module + ",'" + s.Faculty + ",'" + s.PSR + ",'" + s.PS + ",'" + s.Comment + "')";
        try
        {
            
            con.Open();
            MySqlCommand cmd = new MySqlCommand(Query);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            status=true;
        }
        catch (Exception e)
        {
            //Console.WriteLine("In exception ");
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }







}