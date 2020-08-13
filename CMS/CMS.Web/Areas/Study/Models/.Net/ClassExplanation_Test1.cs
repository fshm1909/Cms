using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Areas.Study
{
    public class ClassExplanation_Test1
    {
        #region 构造函数

        //构造函数
        //【特征】：没有返回值,名称和类名一样
        //【访问权限修饰符】：public,internal,private,protected
        //【非托管代码修饰符】：unsafe,extern
        //【作用】：实例化对象。初始化对象数据
        public ClassExplanation_Test1() {/*【无参构造函数】：没有构造函数时编译器自动构造无参构造函数，一旦显示定义了构造函数，编译器将不再自动生成无参构造函数*/ }

        //构造函数可以作为【对象初始化器】，直接初始化对象的可访问字段或属性
        public ClassExplanation_Test1(string a)
        {
            _a = a;
        }

        //重载（方法名相同，参数列表不同的同一类下不同方法称为方法的重载）构造函数，此处使用this直接调用另一个构造函数
        public ClassExplanation_Test1(string a, string b) : this(a)
        {
            _b = b;
        }

        //使用this调用另一个构造函数时可以使用表达式，但是不能使用实例方法(静态方法可用)
        //public ClassExplanation_Test1(string a, string b, string c) : this(a, b + c) { }
        //public ClassExplanation_Test1(string a, string b, string c, string d) : this(a, b + c + d + Fun2()) { }
        //public ClassExplanation_Test1(string a, string b, string c, string d) : this(a, b + c + d + Fun3()) { }

        //可选参数的构造函数
        public ClassExplanation_Test1(string a = "", string b = "", string c = "")
        {
            _a = a;
            _b = b;
            _c = c;//只有在变量声明阶段或者在这个类的构造函数里才允许对readonly的变量进行赋值
        }

        //静态构造函数，主要目的是用于初始化一些静态变量，系统自动调用的
        static ClassExplanation_Test1() { }

        #endregion

        #region 简单单例模式

        ////构造函数私有化，构造函数的作用是提供实例，私有化了以后就不能通过new来实例化对象
        //private ClassExplanation_Test1() { }
        ////定义一个和类同类型的【静态字段】作为存储实例，静态资源是全局唯一的，所以作为单例
        //private static ClassExplanation_Test1 _instance;

        ////公开一个静态方法来创建实例，即外部只能通过该方法获取该类的实例
        //public static ClassExplanation_Test1 CreateInstance()
        //{
        //    if (_instance == null)
        //    {
        //        //如果静态字段不空才创建新的实例，即全局只创建一次
        //        _instance = new ClassExplanation_Test1();
        //    }
        //    return _instance;
        //}

        #endregion

        #region 字段

        // 字段
        public string _a;
        // 字段
        public string _b;
        // 只读字段，只能在声明时或在其所属的类构造方法中被赋值
        public readonly string _c;
        //静态字段
        public static string _c2;
        #endregion

        #region 属性

        public string N { get; }
        //只读属性
        public string A { get; private set; }

        #endregion

        #region 索引器

        string[] words = "测试".Split();
        public string this[int Num]
        {
            get { return words[Num]; }
            set { words[Num] = value; }
        }

        #endregion


        public void Fun1() { }

        public string Fun2() { return "测试"; }

        //静态方法
        public static string Fun3() { return "测试"; }

    }
}