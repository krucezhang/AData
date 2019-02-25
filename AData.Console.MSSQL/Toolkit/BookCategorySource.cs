using DataGenerator;
using DataGenerator.Sources;
using System;

namespace AData.Console.MSSQL.Toolkit
{
    public class BookCategorySource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Name" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _categories = new string[]
        {
            "马克思、列宁主义，毛泽东思想，邓小平理论"
            , "哲学、宗教"
            ,"社会科学总论"
            ,"政治、法律"
            , "军事"
            , "经济"
            , "文化、科学、教育、体育"
            , "语言、文字"
            , "文学"
            , "艺术"
            , "历史、地理"
            , "自然科学总论"
            , "数理科学和化学"
            , "天文学、地球科学"
            , "生物科学"
            , "医药、卫生"
            , "农业科学"
            , "工业技术"
            , "交通运输"
            , "航空、航天"
            , "环境科学、劳动保护科学(安全科学)"
            , "综合性图书"
        };

        public override object NextValue(IGenerateContext generateContext)
        {
            return _categories[RandomGenerator.Current.Next(0, _categories.Length)];
        }

        public BookCategorySource()
            : base(_types, _names)
        {

        }
    }
}
