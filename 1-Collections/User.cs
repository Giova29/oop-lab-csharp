using System;

namespace Collections
{
    public class User : IUser
    {

        public User(string fullName, string username, uint? age)
        {
            FullName = fullName;
            Username = (username == null ? throw new NullReferenceException("Username cannot be null") : username);
            Age = age;
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => Age != null;

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Age == user.Age &&
                   FullName == user.FullName &&
                   Username == user.Username;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Age, FullName, Username);
        }
    }
}
