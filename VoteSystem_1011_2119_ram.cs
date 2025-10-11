// 代码生成时间: 2025-10-11 21:19:49
using System;
using System.Collections.Generic;
using System.Linq;

// 投票系统类
public class VoteSystem
{
    // 存储投票结果的字典，键为候选人，值为票数
    private Dictionary<string, int> voteCounts = new Dictionary<string, int>();

    // 添加候选人
    public void AddCandidate(string candidateName)
    {
        if (string.IsNullOrWhiteSpace(candidateName))
        {
            throw new ArgumentException("Candidate name cannot be empty or null.");
        }
        
        if (!voteCounts.ContainsKey(candidateName))
        {
            voteCounts.Add(candidateName, 0);
        }
        else
        {
            throw new InvalidOperationException("Candidate already exists.");
        }
    }

    // 为候选人投票
    public void VoteForCandidate(string candidateName)
    {
        if (!voteCounts.ContainsKey(candidateName))
        {
            throw new ArgumentException("Candidate does not exist.");
        }
        
        voteCounts[candidateName]++;
    }

    // 获取投票结果
    public Dictionary<string, int> GetVoteResults()
    {
        return new Dictionary<string, int>(voteCounts);
    }
}

// 程序类，用于演示投票系统的功能
class Program
{
    static void Main(string[] args)
    {
        VoteSystem voteSystem = new VoteSystem();
        
        try
        {
            voteSystem.AddCandidate("Alice");
            voteSystem.AddCandidate("Bob");
            voteSystem.AddCandidate("Charlie");

            // 模拟投票过程
            for (int i = 0; i < 100; i++)
            {
                string[] candidates = new string[] { "Alice", "Bob", "Charlie" };
                voteSystem.VoteForCandidate(candidates[new Random().Next(3)]);
            }

            // 输出投票结果
            Dictionary<string, int> results = voteSystem.GetVoteResults();
            foreach (var candidate in results)
            {
                Console.WriteLine($"Candidate {candidate.Key} has {candidate.Value} votes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
