using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly Dictionary<TUser, string> _followedUsers;

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            _followedUsers = new Dictionary<TUser, string>();
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (this.GetFollowedUsersInGroup(group).Contains(user))
            {
                return false;
            }
            else
            {
                _followedUsers.Add(user, group);
                return true;
            }
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                List<TUser> returnList = new List<TUser>();
                foreach(var i in _followedUsers)
                {
                    if (!returnList.Contains(i.Key))
                    {
                        returnList.Add(i.Key);
                    }
                }
                return returnList;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            List<TUser> returnList = new List<TUser>();
            foreach (var i in _followedUsers)
            {
                if (i.Value.Equals(group))
                {
                    returnList.Add(i.Key);
                }
            }
            return returnList;
        }
    }
}
