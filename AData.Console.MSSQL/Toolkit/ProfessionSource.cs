using AData.Common;
using AData.DataGenerator;
using AData.DataGenerator.Sources;
using System;

namespace AData.Console.MSSQL.Toolkit
{
    public class ProfessionSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Name" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _professions = new string[] 
        {
            "哲学"
            , "经济学"
            , "法学"
            , "教育学"
            , "文学"
            , "历史学"
            , "理学"
            , "工学"
            , "农学"
            , "医学"
            , "军事学"
            , "管理学"
            , "艺术学"
        };

        public override object NextValue(IGenerateContext generateContext)
        {
            return _professions[RandomGenerator.Current.Next(0, _professions.Length)];
        }

        public ProfessionSource()
            : base(_types, _names)
        {

        }
    }
}
