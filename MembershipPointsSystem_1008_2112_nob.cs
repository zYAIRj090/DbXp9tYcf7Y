// 代码生成时间: 2025-10-08 21:12:46
using System;
using System.Collections.Generic;

namespace MembershipPointsSystem
{
    // Exception for points system errors
    public class PointsSystemException : Exception
    {
        public PointsSystemException(string message) : base(message)
        {
        }
    }

    // Represents a member in the points system
    public class Member
    {
        public int MemberId { get; private set; }
        public string Name { get; private set; }
        public int Points { get; private set; }

        public Member(int memberId, string name)
        {
            MemberId = memberId;
            Name = name;
            Points = 0; // Initial points are zero
        }

        public void AddPoints(int points)
        {
            if (points < 0)
                throw new PointsSystemException("Cannot add negative points.");

            Points += points;
        }

        public void RedeemPoints(int points)
        {
            if (points < 0)
                throw new PointsSystemException("Cannot redeem negative points.");

            if (Points < points)
                throw new PointsSystemException("Not enough points to redeem.");

            Points -= points;
        }
    }

    // Manages the membership points system
    public class PointsManager
    {
        private Dictionary<int, Member> members = new Dictionary<int, Member>();

        public void AddMember(int memberId, string name)
        {
            if (members.ContainsKey(memberId))
                throw new PointsSystemException("Member already exists.");

            members.Add(memberId, new Member(memberId, name));
        }

        public void RemoveMember(int memberId)
        {
            if (!members.ContainsKey(memberId))
                throw new PointsSystemException("Member not found.");

            members.Remove(memberId);
        }

        public void AddPointsToMember(int memberId, int points)
        {
            if (!members.ContainsKey(memberId))
                throw new PointsSystemException("Member not found.");

            members[memberId].AddPoints(points);
        }

        public void RedeemPointsForMember(int memberId, int points)
        {
            if (!members.ContainsKey(memberId))
                throw new PointsSystemException("Member not found.");

            members[memberId].RedeemPoints(points);
        }

        public int GetMemberPoints(int memberId)
        {
            if (!members.ContainsKey(memberId))
                throw new PointsSystemException("Member not found.");

            return members[memberId].Points;
        }
    }

    // Entry point for the application
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PointsManager manager = new PointsManager();

                // Example usage: adding members, adding points, redeeming points
                manager.AddMember(1, "John Doe");
                manager.AddPointsToMember(1, 100);
                Console.WriteLine($"John Doe's points: {manager.GetMemberPoints(1)}");

                manager.RedeemPointsForMember(1, 50);
                Console.WriteLine($"John Doe's points after redeeming: {manager.GetMemberPoints(1)}");
            }
            catch (PointsSystemException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
