using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SING.Data.BaseTools
{
    public static class XmlHelper
    {
        /// <summary>
        /// Like Add, but chainable.
        /// </summary>
        /// <param name="el">The parent element.</param>
        /// <param name="children">The elements to add.</param>
        /// <returns>Itself</returns>
        public static XElement AddEl(this XElement el, params XElement[] children)
        {
            el.Add(children.Cast<object>());
            return el;
        }

        /// <summary>
        /// Gets the string value of an attribute, and null if the attribute doesn't exist.
        /// </summary>
        /// <param name="el">The element.</param>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>The string value of the attribute if it exists, null otherwise.</returns>
        public static string Attr(this XElement el, string name)
        {
            var attr = el.Attribute(name);
            return attr == null ? null : attr.Value;
        }

        /// <summary>
        /// Gets a typed value from an attribute.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="el">The element.</param>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>The attribute value</returns>
        public static T Attr<T>(this XElement el, string name)
        {

            var attr = el.Attribute(name);
            var type = typeof(T);

            if (attr == null ||
                ((!type.IsValueType || Nullable.GetUnderlyingType(type) != null) && type != typeof(string) &&
                 "null".Equals(attr.Value, StringComparison.Ordinal)))
            {

                return default(T);
            }

            if (type == typeof(string))
            {
                return (T)(object)attr.Value;
            }
            if (type == typeof(int))
            {
                return (T)(object)(int)attr; // Pretty, eh? OK, if you're so smart, find a better way. I'm waiting. Seriously, I'd love to not do this.
            }
            if (type == typeof(bool))
            {
                return (T)(object)(bool)attr;
            }
            if (type == typeof(DateTime))
            {
                return (T)(object)(DateTime)attr;
            }
            if (type == typeof(double))
            {
                return (T)(object)(double)attr;
            }
            if (type == typeof(float))
            {
                return (T)(object)(float)attr;
            }
            if (type == typeof(decimal))
            {
                return (T)(object)(decimal)attr;
            }
            if (type == typeof(int?))
            {
                return (T)(object)(int?)attr;
            }
            if (type == typeof(bool?))
            {
                return (T)(object)(bool?)attr;
            }
            if (type == typeof(DateTime?))
            {
                return (T)(object)(DateTime?)attr;
            }
            if (type == typeof(double?))
            {
                return (T)(object)(double?)attr;
            }
            if (type == typeof(float?))
            {
                return (T)(object)(float?)attr;
            }
            if (type == typeof(decimal?))
            {
                return (T)(object)(decimal?)attr;
            }
            throw new InvalidCastException(String.Format("Couldn't find how to deserialize to type {0}.", type.Name));
        }

        /// <summary>
        /// Sets an attribute value. This is chainable.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="el">The element.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>Itself</returns>
        public static XElement Attr<T>(this XElement el, string name, T value)
        {
            el.SetAttributeValue(name, value);
            return el;
        }

        /// <summary>
        /// Returns the text contents of a child element.
        /// </summary>
        /// <param name="el">The parent element.</param>
        /// <param name="name">The name of the child element.</param>
        /// <returns>The text for the child element, and null if it doesn't exist.</returns>
        public static string El(this XElement el, string name)
        {
            var childElement = el.Element(name);
            return childElement == null ? null : childElement.Value;
        }

        /// <summary>
        /// Creates and sets the value of a child element. This is chainable.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="el">The parent element.</param>
        /// <param name="name">The name of the child element.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>Itself</returns>
        public static XElement El<T>(this XElement el, string name, T value)
        {
            el.SetElementValue(name, value);
            return el;
        }

        /// <summary>
        /// Sets a property value from an attribute of the same name.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target object.</typeparam>
        /// <typeparam name="TProperty">The type of the target property</typeparam>
        /// <param name="el">The element.</param>
        /// <param name="target">The target object.</param>
        /// <param name="targetExpression">The property expression.</param>
        /// <returns>Itself</returns>
        public static XElement FromAttr<TTarget, TProperty>(this XElement el, TTarget target,
            Expression<Func<TTarget, TProperty>> targetExpression)
        {

            var propertyInfo = GetPropertyInfo(targetExpression);
            var name = propertyInfo.Name;
            var attr = el.Attribute(name);

            if (attr == null) return el;
            propertyInfo.SetValue(target, el.Attr<TProperty>(name), null);
            return el;
        }

        /// <summary>
        /// Sets an attribute with the value of a property of the same name.
        /// </summary>
        /// <typeparam name="TTarget">The type of the object.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="el">The element.</param>
        /// <param name="target">The object.</param>
        /// <param name="targetExpression">The property expression.</param>
        /// <returns>Itself</returns>
        public static XElement ToAttr<TTarget, TProperty>(this XElement el, TTarget target,
            Expression<Func<TTarget, TProperty>> targetExpression)
        {
            var propertyInfo = GetPropertyInfo(targetExpression);
            var name = propertyInfo.Name;
            var val = propertyInfo.GetValue(target, null);

            if (typeof(TProperty) == typeof(string))
            {
                el.Attr(name, (string)val);
            }
            else if (val == null)
            {
                el.Attr(name, "null");
            }
            else if (typeof(TProperty) == typeof(int))
            {
                el.Attr(name, (int)val);
            }
            else if (typeof(TProperty) == typeof(bool))
            {
                el.Attr(name, (bool)val);
            }
            else if (typeof(TProperty) == typeof(DateTime))
            {
                el.Attr(name, (DateTime)val);
            }
            else if (typeof(TProperty) == typeof(double))
            {
                el.Attr(name, (double)val);
            }
            else if (typeof(TProperty) == typeof(float))
            {
                el.Attr(name, (float)val);
            }
            else if (typeof(TProperty) == typeof(decimal))
            {
                el.Attr(name, (decimal)val);
            }
            else if (typeof(TProperty) == typeof(int?))
            {
                el.Attr(name, (int?)val);
            }
            else if (typeof(TProperty) == typeof(bool?))
            {
                el.Attr(name, (bool?)val);
            }
            else if (typeof(TProperty) == typeof(DateTime?))
            {
                el.Attr(name, (DateTime?)val);
            }
            else if (typeof(TProperty) == typeof(double?))
            {
                el.Attr(name, (double?)val);
            }
            else if (typeof(TProperty) == typeof(float?))
            {
                el.Attr(name, (float?)val);
            }
            else if (typeof(TProperty) == typeof(decimal?))
            {
                el.Attr(name, (decimal?)val);
            }
            return el;
        }

        public static PropertyInfo GetPropertyInfo<TContext, TProperty>(Expression<Func<TContext, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression is not a member expression.");
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null) throw new InvalidOperationException("Expression is not for a property.");
            return propertyInfo;
        }

        /// <summary>
        /// Gives context to an XElement, enabling chained property operations.
        /// </summary>
        /// <typeparam name="TContext">The type of the context.</typeparam>
        /// <param name="el">The element.</param>
        /// <param name="context">The context.</param>
        /// <returns>The element with context.</returns>
        public static XElementWithContext<TContext> With<TContext>(this XElement el, TContext context)
        {
            return new XElementWithContext<TContext>(el, context);
        }

        public class XElementWithContext<TContext>
        {
            public XElementWithContext(XElement element, TContext context)
            {
                Element = element;
                Context = context;
            }

            public XElement Element { get; private set; }
            public TContext Context { get; private set; }

            public static implicit operator XElement(XElementWithContext<TContext> elementWithContext)
            {
                return elementWithContext.Element;
            }

            /// <summary>
            /// Replaces the current context with a new one, enabling chained action on different objects.
            /// </summary>
            /// <typeparam name="TNewContext">The type of the new context.</typeparam>
            /// <param name="context">The new context.</param>
            /// <returns>A new XElementWithContext, that has the new context.</returns>
            public XElementWithContext<TNewContext> With<TNewContext>(TNewContext context)
            {
                return new XElementWithContext<TNewContext>(Element, context);
            }

            /// <summary>
            /// Sets the value of a context property as an attribute of the same name on the element.
            /// </summary>
            /// <typeparam name="TProperty">The type of the property.</typeparam>
            /// <param name="targetExpression">The property expression.</param>
            /// <returns>Itself</returns>
            public XElementWithContext<TContext> ToAttr<TProperty>(
                Expression<Func<TContext, TProperty>> targetExpression)
            {
                Element.ToAttr(Context, targetExpression);
                return this;
            }

            /// <summary>
            /// Gets an attribute on the element and sets the property of the same name on the context with its value.
            /// </summary>
            /// <typeparam name="TProperty">The type of the property.</typeparam>
            /// <param name="targetExpression">The property expression.</param>
            /// <returns>Itself</returns>
            public XElementWithContext<TContext> FromAttr<TProperty>(
                Expression<Func<TContext, TProperty>> targetExpression)
            {
                Element.FromAttr(Context, targetExpression);
                return this;
            }

            /// <summary>
            /// Evaluates an attribute from an expression.
            /// It's a nice strongly-typed way to read attributes.
            /// </summary>
            /// <typeparam name="TProperty">The type of the property.</typeparam>
            /// <param name="expression">The property expression.</param>
            /// <returns>The attribute, ready to be cast.</returns>
            public TProperty Attr<TProperty>(Expression<Func<TContext, TProperty>> expression)
            {
                var propertyInfo = GetPropertyInfo(expression);
                var name = propertyInfo.Name;
                return Element.Attr<TProperty>(name);
            }
        }
    }

    // Example class for a serializable object
    public class SimpleData
    {
        private string name = "";
        private string phone = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    // Example how to use the class
    public class SampleUsage
    {
        private SimpleData data = new SimpleData();

        public void LoadSimpleData()
        {
            data = XMLHelper.DeserializeFromXMLFile<SimpleData>(@"simpledata.xml");
        }

        public void StoreSimpleData()
        {
            XMLHelper.SerializeToXMLFile<SimpleData>(data, @"simpledata.xml", Encoding.Unicode, true);
        }

    }


    public static class XMLHelper
    {
        public static string SerializeToXMLString<T>(T XMLObj, Encoding encoding, bool removeNamespace)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            MemoryStream memStrm = new MemoryStream();
            XmlTextWriter xmlSink = new XmlTextWriter(memStrm, encoding);
            xmlSink.Formatting = Formatting.Indented;

            if (removeNamespace)
            {
                XmlSerializerNamespaces xs = new XmlSerializerNamespaces();
                xs.Add("", "");
                xmlSerializer.Serialize(xmlSink, XMLObj, xs);
            }
            else
                xmlSerializer.Serialize(xmlSink, XMLObj);

            return encoding.GetString(memStrm.ToArray());
        }

        public static void SerializeToXMLFile<T>(T XMLObj, string Filename, Encoding encoding, bool removeNamespace)
        {
            File.WriteAllText(Filename, SerializeToXMLString<T>(XMLObj, encoding, removeNamespace));
        }

        public static T DeserializeFromXMLString<T>(string XML) where T : new()
        {
            T XMLObj = new T();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader sr = new StringReader(XML);
            XMLObj = (T)xmlSerializer.Deserialize(sr);
            return XMLObj;
        }

        public static T DeserializeFromXMLFile<T>(string Filename) where T : new()
        {
            if (!File.Exists(Filename))
                throw new FileNotFoundException();

            return DeserializeFromXMLString<T>(File.ReadAllText(Filename));
        }

    }

    public class Person
    {
        public string FirstName { get; set; }

        [XmlIgnoreAttribute]
        public string LastName { get; set; }
    }

    public class XMLHelper<T>
    {
        public string ToXML(T value, string xmlRootAttribute = null)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType(), new XmlRootAttribute(xmlRootAttribute));
            var settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamepsaces);
                return stream.ToString();
            }
        }

        public T FromXML(string XMLData, string xmlRootAttribute = null)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            T XMLObject = (T)serializer.Deserialize(new StringReader(XMLData));

            return XMLObject;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            XMLHelper<Person> XMLPersonHelper = new XMLHelper<Person>();
            Person person = new Person() { FirstName = "Karthik", LastName = "Vijay" };
            string xmlPerson = XMLPersonHelper.ToXML(person);
            Console.WriteLine(xmlPerson);

            person = XMLPersonHelper.FromXML(xmlPerson);
            Console.WriteLine(person.FirstName);

            XMLHelper<List<Person>> XMLPersonsHelper = new XMLHelper<List<Person>>();
            List<Person> persons = new List<Person>();
            persons.Add(person);
            string xmlPersons = XMLPersonsHelper.ToXML(persons, "Persons");
            Console.WriteLine(xmlPersons);

            persons = XMLPersonsHelper.FromXML(xmlPersons, "Persons");
            Console.WriteLine(persons.First().FirstName);

            Console.ReadKey();
        }
    }

    ///<summary>
    /// XMLHelper XML文档操作管理器
    ///</summary>
    public class XMLHelper1
    {
        public XMLHelper1()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region XML文档节点查询和读取
        ///<summary>
        /// 选择匹配XPath表达式的第一个节点XmlNode.
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        ///<returns>返回XmlNode</returns>
        public static XmlNode GetXmlNodeByXpath(string xmlFileName, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                return xmlNode;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        ///<summary>
        /// 选择匹配XPath表达式的节点列表XmlNodeList.
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        ///<returns>返回XmlNodeList</returns>
        public static XmlNodeList GetXmlNodeListByXpath(string xmlFileName, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes(xpath);
                return xmlNodeList;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        ///<summary>
        /// 选择匹配XPath表达式的第一个节点的匹配xmlAttributeName的属性XmlAttribute.
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        ///<returns>返回xmlAttributeName</returns>
        public static XmlAttribute GetXmlAttribute(string xmlFileName, string xpath, string xmlAttributeName)
        {
            string content = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            XmlAttribute xmlAttribute = null;
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    if (xmlNode.Attributes.Count > 0)
                    {
                        xmlAttribute = xmlNode.Attributes[xmlAttributeName];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return xmlAttribute;
        }
        #endregion

        #region XML文档创建和节点或属性的添加、修改
        ///<summary>
        /// 创建一个XML文档
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="rootNodeName">XML文档根节点名称(须指定一个根节点名称)</param>
        ///<param name="version">XML文档版本号(必须为:"1.0")</param>
        ///<param name="encoding">XML文档编码方式</param>
        ///<param name="standalone">该值必须是"yes"或"no",如果为null,Save方法不在XML声明上写出独立属性</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateXmlDocument(string xmlFileName, string rootNodeName, string version, string encoding, string standalone)
        {
            bool isSuccess = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration(version, encoding, standalone);
                XmlNode root = xmlDoc.CreateElement(rootNodeName);
                xmlDoc.AppendChild(xmlDeclaration);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFileName);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 依据匹配XPath表达式的第一个节点来创建它的子节点(如果此节点已存在则追加一个新的同名节点
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlNodeName">要匹配xmlNodeName的节点名称</param>
        ///<param name="innerText">节点文本值</param>
        ///<param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        ///<param name="value">属性值</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateXmlNodeByXPath(string xmlFileName, string xpath, string xmlNodeName, string innerText, string xmlAttributeName, string value)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //存不存在此节点都创建
                    XmlElement subElement = xmlDoc.CreateElement(xmlNodeName);
                    subElement.InnerXml = innerText;

                    //如果属性和值参数都不为空则在此新节点上新增属性
                    if (!string.IsNullOrEmpty(xmlAttributeName) && !string.IsNullOrEmpty(value))
                    {
                        XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(xmlAttributeName);
                        xmlAttribute.Value = value;
                        subElement.Attributes.Append(xmlAttribute);
                    }

                    xmlNode.AppendChild(subElement);
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 依据匹配XPath表达式的第一个节点来创建或更新它的子节点(如果节点存在则更新,不存在则创建)
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlNodeName">要匹配xmlNodeName的节点名称</param>
        ///<param name="innerText">节点文本值</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateOrUpdateXmlNodeByXPath(string xmlFileName, string xpath, string xmlNodeName, string innerText)
        {
            bool isSuccess = false;
            bool isExistsNode = false;//标识节点是否存在
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点下的所有子节点
                    foreach (XmlNode node in xmlNode.ChildNodes)
                    {
                        if (node.Name.ToLower() == xmlNodeName.ToLower())
                        {
                            //存在此节点则更新
                            node.InnerXml = innerText;
                            isExistsNode = true;
                            break;
                        }
                    }
                    if (!isExistsNode)
                    {
                        //不存在此节点则创建
                        XmlElement subElement = xmlDoc.CreateElement(xmlNodeName);
                        subElement.InnerXml = innerText;
                        xmlNode.AppendChild(subElement);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 依据匹配XPath表达式的第一个节点来创建或更新它的属性(如果属性存在则更新,不存在则创建)
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        ///<param name="value">属性值</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateOrUpdateXmlAttributeByXPath(string xmlFileName, string xpath, string xmlAttributeName, string value)
        {
            bool isSuccess = false;
            bool isExistsAttribute = false;//标识属性是否存在
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (attribute.Name.ToLower() == xmlAttributeName.ToLower())
                        {
                            //节点中存在此属性则更新
                            attribute.Value = value;
                            isExistsAttribute = true;
                            break;
                        }
                    }
                    if (!isExistsAttribute)
                    {
                        //节点中不存在此属性则创建
                        XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(xmlAttributeName);
                        xmlAttribute.Value = value;
                        xmlNode.Attributes.Append(xmlAttribute);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
        #endregion


        #region XML文档节点或属性的删除
        ///<summary>
        /// 删除匹配XPath表达式的第一个节点(节点中的子元素同时会被删除)
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool DeleteXmlNodeByXPath(string xmlFileName, string xpath)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //删除节点
                    xmlNode.ParentNode.RemoveChild(xmlNode);
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 删除匹配XPath表达式的第一个节点中的匹配参数xmlAttributeName的属性
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlAttributeName">要删除的xmlAttributeName的属性名称</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool DeleteXmlAttributeByXPath(string xmlFileName, string xpath, string xmlAttributeName)
        {
            bool isSuccess = false;
            bool isExistsAttribute = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                XmlAttribute xmlAttribute = null;
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (attribute.Name.ToLower() == xmlAttributeName.ToLower())
                        {
                            //节点中存在此属性
                            xmlAttribute = attribute;
                            isExistsAttribute = true;
                            break;
                        }
                    }
                    if (isExistsAttribute)
                    {
                        //删除节点中的属性
                        xmlNode.Attributes.Remove(xmlAttribute);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 删除匹配XPath表达式的第一个节点中的所有属性
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool DeleteAllXmlAttributeByXPath(string xmlFileName, string xpath)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    xmlNode.Attributes.RemoveAll();
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
        #endregion

    }
}
