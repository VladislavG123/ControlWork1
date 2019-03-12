using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ControlWork
{
    class UserController
    {
        public string Path { get; set; }
        public UserController()
        {
            Path = @"~UsersData\JsonData.txt";
        }
        public void Register(User user)
        {
            string jsonFile = JsonConvert.SerializeObject(user);
            using (var writer = new StreamWriter(Path, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(jsonFile);
            }
        }

        public bool FindSimilarUser(string usersEmail)
        {
            string json;
            using (var fileStream = File.OpenRead(Path))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                json = Encoding.UTF8.GetString(buffer);
            }

            json += ']';


            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (var user in users)
            {
                if (user.Email == usersEmail)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsUserExists(string email, string password)
        {
            email.Trim();
            string json;
            using (var fileStream = File.OpenRead(Path))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                json = Encoding.UTF8.GetString(buffer);
            }

            json += ']';

            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }

            }
            return false;
        }

        public User GetUserFromEmail(string email)
        {
            email.Trim();
            string json;
            using (var fileStream = File.OpenRead(Path))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                json = Encoding.UTF8.GetString(buffer);
            }

            json += ']';

            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    return user;
                }

            }
            return new User { FullName = "Error" };
        }

    }
}
