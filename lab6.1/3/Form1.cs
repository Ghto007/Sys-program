using System;
using System.IO;
using System.Windows.Forms;

namespace Lab6_Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Мій Файловий Менеджер";

            // Ручна прив'язка подій для списку
            listBoxDirectoryContent.DoubleClick += NavigateFolder;
            listBoxDirectoryContent.SelectedIndexChanged += ShowFileDetails;
        }

        // Кнопка відкриття вікна вибору папки
        private void buttonBrowse_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Оберіть директорію для навігації";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    RefreshDirectoryView(dialog.SelectedPath);
                }
            }
        }

        // Головний метод для малювання вмісту папки
        private void RefreshDirectoryView(string targetPath)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(targetPath);
                if (!directory.Exists) return;

                textBoxCurrentFolder.Text = directory.FullName;
                listBoxDirectoryContent.Items.Clear();

                // Кнопка повернення (виглядає інакше, ніж у тебе)
                if (directory.Parent != null)
                {
                    listBoxDirectoryContent.Items.Add("<<< Повернутись назад");
                }

                // Додаємо папки з текстовим тегом [Папка]
                foreach (DirectoryInfo d in directory.GetDirectories())
                {
                    listBoxDirectoryContent.Items.Add($"[Папка] {d.Name}");
                }

                // Додаємо файли з текстовим тегом [Файл]
                foreach (FileInfo f in directory.GetFiles())
                {
                    listBoxDirectoryContent.Items.Add($"[Файл] {f.Name}");
                }

                labelDetails.Text = "Готово. Оберіть файл для деталей.";
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("У вас немає прав для перегляду цієї папки.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Перехід по папках (Подвійний клік)
        private void NavigateFolder(object sender, EventArgs e)
        {
            if (listBoxDirectoryContent.SelectedItem == null) return;

            string clickedItem = listBoxDirectoryContent.SelectedItem.ToString();
            string currentDir = textBoxCurrentFolder.Text;

            // Логіка підняття на рівень вище
            if (clickedItem == "<<< Повернутись назад")
            {
                DirectoryInfo parentDir = Directory.GetParent(currentDir);
                if (parentDir != null)
                {
                    RefreshDirectoryView(parentDir.FullName);
                }
                return;
            }
            // Якщо це папка - заходимо (відрізаємо перші 8 символів "[Папка] ")
            if (clickedItem.StartsWith("[Папка] "))
            {
                string cleanFolderName = clickedItem.Substring(8);
                string nextPath = Path.Combine(currentDir, cleanFolderName);
                RefreshDirectoryView(nextPath);
            }
        }

        // Показ інформації про файл (Один клік)
        private void ShowFileDetails(object sender, EventArgs e)
        {
            if (listBoxDirectoryContent.SelectedItem == null) return;

            string clickedItem = listBoxDirectoryContent.SelectedItem.ToString();
            string currentDir = textBoxCurrentFolder.Text;

            if (clickedItem.StartsWith("[Файл] "))
            {
                try
                {
                    // Відрізаємо перші 7 символів "[Файл] "
                    string cleanFileName = clickedItem.Substring(7);
                    FileInfo fileInfo = new FileInfo(Path.Combine(currentDir, cleanFileName));

                    // Рахуємо розмір у мегабайтах
                    double sizeInMb = fileInfo.Length / 1048576.0;

                    labelDetails.Text = $"Назва: {fileInfo.Name}\n" +
                                        $"Розмір: {fileInfo.Length} байт ({sizeInMb:F2} MB)\n" +
                                        $"Створено: {fileInfo.CreationTime.ToShortDateString()}\n" +
                                        $"Відкрито: {fileInfo.LastAccessTime.ToShortDateString()}";
                }
                catch
                {
                    labelDetails.Text = "Помилка читання файлу.";
                }
            }
            else
            {
                labelDetails.Text = "Це папка. Подвійний клік для переходу.";
            }
        }
    }
}