// 代码生成时间: 2025-08-07 02:25:59
using System;
using System.Collections.Generic;

// 定义一个简单的数据模型类
public class DataModel
{
    // 数据模型属性
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    // 构造函数
    public DataModel(string id, string name, int age, string email)
    {
        // 基本的数据验证
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be null or whitespace.");
        if (age <= 0) throw new ArgumentException("Age must be greater than 0.");

        // 分配属性值
        Id = id;
        Name = name;
        Age = age;
        Email = email;
    }

    // 一个简单的方法来显示数据模型信息
    public void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}
Name: {Name}
Age: {Age}
Email: {Email}");
    }
}

// 定义一个数据模型列表类
public class DataModelList
{
    // 数据模型列表
    private List<DataModel> models;

    // 构造函数
    public DataModelList()
    {
        models = new List<DataModel>();
    }

    // 添加数据模型到列表
    public void AddModel(DataModel model)
    {
        models.Add(model);
    }

    // 获取所有数据模型
    public List<DataModel> GetAllModels()
    {
        return models;
    }

    // 显示所有数据模型信息
    public void DisplayAllModels()
    {
        foreach (var model in models)
        {
            model.DisplayInfo();
            Console.WriteLine();
        }
    }
}
