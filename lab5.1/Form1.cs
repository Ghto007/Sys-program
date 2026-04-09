using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Movie Reflection Analyzer"; 
        }

        // Кнопка для запуску аналізу
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Створюємо об'єкт фільму з конкретними даними
            Movie myMovie = new Movie("Inception", 2010, 8.8,
                new List<string> { "Leonardo DiCaprio", "Joseph Gordon-Levitt", "Elliot Page" });

            RunReflectionAnalysis(myMovie);
        }

        private void RunReflectionAnalysis(object targetObject)
        {
            treeView1.Nodes.Clear();

            // Отримуємо тип переданого об'єкта
            Type objType = targetObject.GetType();

            // Створюємо кореневий вузол
            TreeNode rootNode = new TreeNode($"Тип об'єкта: {objType.Name}");
            treeView1.Nodes.Add(rootNode);

            // АНАЛІЗ ВЛАСТИВОСТЕЙ
            TreeNode propertiesNode = new TreeNode("Властивості (Properties)");
            foreach (PropertyInfo propInfo in objType.GetProperties())
            {
                object propValue = propInfo.GetValue(targetObject);

                // Перевірка, чи є властивість списком (колекцією)
                string displayValue = propValue is List<string> stringList
                    ? string.Join(", ", stringList)
                    : propValue?.ToString();

                propertiesNode.Nodes.Add($"{propInfo.PropertyType.Name} {propInfo.Name} = {displayValue}");
            }
            rootNode.Nodes.Add(propertiesNode);

            // АНАЛІЗ МЕТОДІВ
            TreeNode methodsNode = new TreeNode("Методи (Methods)");
            // Використовуємо BindingFlags, щоб приховати системні методи Object
            foreach (MethodInfo methInfo in objType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                ParameterInfo[] methodParams = methInfo.GetParameters();
                string paramsFormatted = string.Join(", ", Array.ConvertAll(methodParams, p => $"{p.ParameterType.Name} {p.Name}"));

                methodsNode.Nodes.Add($"{methInfo.ReturnType.Name} {methInfo.Name}({paramsFormatted})");
            }
            rootNode.Nodes.Add(methodsNode);

            // АНАЛІЗ КОНСТРУКТОРІВ
            TreeNode constructorsNode = new TreeNode("Конструктори (Constructors)");
            foreach (ConstructorInfo ctorInfo in objType.GetConstructors())
            {
                ParameterInfo[] ctorParams = ctorInfo.GetParameters();
                string paramsFormatted = string.Join(", ", Array.ConvertAll(ctorParams, p => $"{p.ParameterType.Name} {p.Name}"));

                constructorsNode.Nodes.Add($"{objType.Name}({paramsFormatted})");
            }
            rootNode.Nodes.Add(constructorsNode);

            // Розгортаємо дерево для зручного перегляду
            treeView1.ExpandAll();
        }
    }
}