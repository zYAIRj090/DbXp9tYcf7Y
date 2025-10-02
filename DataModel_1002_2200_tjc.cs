// 代码生成时间: 2025-10-02 22:00:49
using System;
using System.Collections.Generic;

// 定义一个简单的数据模型类
public class DataModel
{
    // 属性
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<string> Tags { get; set; }

    // 构造函数
    public DataModel()
    {
        Tags = new List<string>();
        CreatedAt = DateTime.Now;
    }

    // 添加标签方法
    public void AddTag(string tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
        {
            throw new ArgumentException("Tag cannot be null or whitespace.", nameof(tag));
        }
        Tags.Add(tag);
    }

    // 移除标签方法
    public void RemoveTag(string tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
        {
            throw new ArgumentException("Tag cannot be null or whitespace.", nameof(tag));
        }
        Tags.Remove(tag);
    }

    // 显示数据模型信息
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, CreatedAt: {CreatedAt}, Tags: {{" + string.Join(", ", Tags) + "}}";
    }
}
