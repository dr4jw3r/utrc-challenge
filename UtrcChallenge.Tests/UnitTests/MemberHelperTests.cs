using NUnit.Framework;
using System.Collections.Generic;
using UtrcChallenge.Helpers;

namespace UtrcChallenge.Tests.UnitTests
{
    [TestFixture]
    class MemberHelperTests
    {
        private HashSet<string> CreateFriendsList(params string[] parameters)
        {
            HashSet<string> friends = new HashSet<string>();
            foreach (string parameter in parameters)
            {
                friends.Add(parameter);
            }
            return friends;
        }

        [Test]
        public void CreatesMembersCorrectly()
        {
            string[] fileContents = {
                "PERSON_1,PERSON_2",
                "PERSON_1,PERSON_3",
                "PERSON_1,PERSON_4",
                "PERSON_2,PERSON_3",
                "PERSON_2,PERSON_4",
                "PERSON_3,PERSON_4",
            };

            Dictionary<string, HashSet<string>> members = MemberHelper.CreateMembers(fileContents);

            // Check that four members are created
            Assert.AreEqual(4, members.Count);

            // Make sure that PERSON_1 has 3 friends
            Assert.AreEqual(3, members["PERSON_1"].Count);
        }

        [Test]
        public void CorrectlyFindsShortestDistanceBetweenNodes()
        {
            Dictionary<string, HashSet<string>> members = new Dictionary<string, HashSet<string>>();

            HashSet<string> personOneFriends = CreateFriendsList("PERSON_2", "PERSON_6", "PERSON_7");
            members.Add("PERSON_1", personOneFriends);

            HashSet<string> personTwoFriends = CreateFriendsList("PERSON_1", "PERSON_3", "PERSON_6");
            members.Add("PERSON_2", personTwoFriends);

            HashSet<string> personThreeFriends = CreateFriendsList("PERSON_2", "PERSON_4");
            members.Add("PERSON_3", personThreeFriends);

            HashSet<string> personFourFriends = CreateFriendsList("PERSON_3", "PERSON_5");
            members.Add("PERSON_4", personFourFriends);

            HashSet<string> personFiveFriends = CreateFriendsList("PERSON_4");
            members.Add("PERSON_5", personFiveFriends);

            HashSet<string> personSixFriends = CreateFriendsList("PERSON_1", "PERSON_2");
            members.Add("PERSON_6", personSixFriends);

            HashSet<string> personSevenFriends = CreateFriendsList("PERSON_1");
            members.Add("PERSON_7", personSevenFriends);

            HashSet<string> personEightFriends = CreateFriendsList("");
            members.Add("PERSON_8", personEightFriends);

            
            int distanceP1ToP5 = MemberHelper.GetShortestDistance(members, "PERSON_1", "PERSON_5");
            int distanceP1ToP7 = MemberHelper.GetShortestDistance(members, "PERSON_1", "PERSON_7");
            int distanceP1ToP8 = MemberHelper.GetShortestDistance(members, "PERSON_1", "PERSON_8");

            // Distance between PERSON_1 and PERSON_5 should be 4
            Assert.AreEqual(4, distanceP1ToP5);

            // Distance between PERSON_1 and PERSON_7 should be 1
            Assert.AreEqual(1, distanceP1ToP7);

            // Distance between PERSON_1 and PERSON_7 should be -1 because there is no link between them
            Assert.AreEqual(-1, distanceP1ToP8);
        }
    }
}
