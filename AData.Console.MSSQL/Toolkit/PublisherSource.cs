﻿using AData.Common;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using System;

namespace AData.Console.MSSQL.Toolkit
{
    public class PublisherSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Name" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _publisher = new string[]
        {
            "安徽人民出版社", "北京出版社", "长春出版社", "重庆出版社", "党建读物出版社", "法律出版社",
            "湖南人民出版社", "吉林出版集团有限责任公司", "江苏人民出版社", "江西人民出版社", "解放军出版社",
            "经济科学出版社", "九州出版社", "青岛出版社", "山东人民出版社", "商务印书馆", "上海人民出版社",
            "生活.读书.新知三联书店", "外文出版社", "学习出版社", "知识产权出版社", "中国金融出版社",
            "中国民主法制出版社", "中国青年出版社", "中国社会出版社", "中国时代经济出版社", "中信出版社",
            "中央编译出版社", "电子工业出版社", "湖南科学技术出版社", "化学工业出版社", "江苏科学技术出版社",
            "科学出版社", "人民交通出版社", "人民军医出版社", "人民卫生出版社", "人民邮电出版社",
            "星球地图出版社", "中国电力出版社", "中国纺织出版社", "中国轻工业出版社", "中国人口出版社",
            "中国中医药出版社", "北京大学出版社", "北京大学医学出版社", "北京语言大学出版社",
            "重庆大学出版社", "复旦大学出版社", "湖南师范大学出版社", "清华大学出版社", "外语教学与研究出版社",
            "西安交通大学出版社", "西南师范大学出版社", "厦门大学出版社", "浙江大学出版社",
            "中国矿业大学出版社", "中国人民大学出版社", "中国人民公安大学出版社", "中国政法大学出版社",
            "高等教育出版社", "广东教育出版社", "江苏教育出版社", "教育科学出版社", "人民教育出版社",
            "浙江教育出版社", "5.古籍类", "国家图书馆出版社", "黄山书社", "岳麓书社", "中华书局",
            "安徽少年儿童出版社", "二十一世纪出版社", "江苏少年儿童出版社", "接力出版社", "明天出版社",
            "浙江少年儿童出版社", "安徽美术出版社", "湖南美术出版社", "吉林美术出版社", "江苏美术出版社",
            "江西美术出版社", "浙江人民美术出版社", "长江文艺出版社", "湖南文艺出版社", "人民文学出版社",
            "人民音乐出版社", "上海文艺出版社", "上海译文出版社", "译林出版社", "浙江摄影出版社", "作家出版社↵"
        };

        public PublisherSource()
            :base(_types, _names)
        {

        }

        public override object NextValue(IGenerateContext generateContext)
        {
            return _publisher[RandomGenerator.Current.Next(0, _publisher.Length)];
        }
    }
}
