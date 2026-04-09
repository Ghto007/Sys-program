using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab
{
    public partial class Form1 : Form
    {
        // [ЗАВДАННЯ 4]: Об'єкт для скасування фонової операції
        private CancellationTokenSource cancelTokenSource;

        // Поточна затримка для імітації довгої роботи
        private int currentDelay = 50;

       

        public Form1()
        {
            InitializeComponent();

       
            this.Text = "Background Process Simulator";
            this.BackColor = Color.AliceBlue;

            // [ЗАВДАННЯ 1]: Налаштування радіокнопок для перевірки відгуку UI
            radioButton1.Text = "High Speed (10ms)";
            radioButton2.Text = "Medium Speed (50ms)";
            radioButton3.Text = "Low Speed (200ms)";
            radioButton2.Checked = true;

            buttonCancel.Enabled = false;
        }

        // [ЗАВДАННЯ 1]: Запуск за допомогою async/await
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonCancel.Enabled = true;



            labelResult.Text = "Status: Working...";
            labelResult.ForeColor = Color.DarkBlue;
            progressBar1.Value = 0;

            // [ЗАВДАННЯ 3]: Створення об'єкта для звітування про прогрес
            IProgress<int> progressReporter = new Progress<int>((percent) =>
            {
                labelProgress.Text = $"Completed: {percent}%";
                progressBar1.Value = percent;
            });

            // [ЗАВДАННЯ 4]: Підготовка токена для можливого скасування
            cancelTokenSource = new CancellationTokenSource();

            try
            {
                // [ЗАВДАННЯ 1] та [ЗАВДАННЯ 2]: 
                // Запускаємо важкий метод асинхронно та чекаємо на результат
                long totalSum = await RunHeavyCalculationAsync(100, progressReporter, cancelTokenSource.Token);

                // [ЗАВДАННЯ 2]: Виведення результату, якщо не було скасування
                if (!cancelTokenSource.IsCancellationRequested)
                {
                    labelResult.Text = $"Final Sum: {totalSum}";
                    labelResult.ForeColor = Color.Green;
                }
            }
            finally
            {
                // Відновлення кнопок після завершення
                buttonStart.Enabled = true;
                buttonCancel.Enabled = false;
            }
        }

        // [ЗАВДАННЯ 4]: Обробник скасування
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (cancelTokenSource != null && !cancelTokenSource.IsCancellationRequested)
            {
                cancelTokenSource.Cancel(); // Даємо команду "Стоп!"


                labelResult.Text = "Status: ABORTED!";
                labelResult.ForeColor = Color.DarkRed;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) currentDelay = 10;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) currentDelay = 50;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) currentDelay = 200;
        }

        // Асинхронний метод повертає Task<long>
        private Task<long> RunHeavyCalculationAsync(int maxIterations, IProgress<int> progress, CancellationToken token)
        {
            // Виконання коду в окремому потоці
            return Task.Run(() =>
            {
                long sum = 0;

                for (int k = 1; k <= maxIterations; k++)
                {
                    // [ЗАВДАННЯ 4]: Перевіряємо, чи не натиснув користувач Cancel
                    if (token.IsCancellationRequested)
                    {
                        return sum;
                    }


                    sum += k * 2;

                    // [ЗАВДАННЯ 3]: Звітуємо про прогрес
                    progress.Report(k);

                    // Імітація довгого навантаження з динамічною затримкою
                    Thread.Sleep(currentDelay);
                }

                return sum; // [ЗАВДАННЯ 2]: Повернення результату
            });
        }
    }
}