using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KyrsovayaPVP
{
    public partial class FormProgram : Form
    {
        Random random = new Random();
        public static Stopwatch Timer = new Stopwatch();
        public static int[] arrayOfPoint;

        public FormProgram()
        {
            InitializeComponent();
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            comboBox.SelectedIndex = 2;
        }

        private void FormProgram_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreateArray_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDown.Value);
            arrayOfPoint = new int[count];
            for (int i = 0; i < count; i++)
            {
                arrayOfPoint[i] = random.Next(0, 99);
            }
            ChartClear();
            ChartDrawing();
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            try
            {
                Sort();
            }
            catch
            {
                MessageBox.Show("Вы не создали массив");
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Text Files | *.txt";
            if (save.ShowDialog() == DialogResult.OK && save.FileName.Length > 0)
            {
                using (StreamWriter stream = new StreamWriter(save.FileName, false))
                {
                    stream.WriteLine("Сохранённый массив");
                    for (int i = 0; i < arrayOfPoint.Length; i++)
                    {
                        if (i != arrayOfPoint.Length - 1)
                        {
                            stream.Write(arrayOfPoint[i] + ",");
                        }
                        else
                        {
                            stream.Write(arrayOfPoint[i] + ".");
                        }
                    }
                    stream.Close();
                }
            }
        }
        private void Sort()
        {
            double factor = 1.2473309;
            int step = arrayOfPoint.Length - 1;
            while (step >= 1)
            {
                for (int i = 0; i + step < arrayOfPoint.Length; i++)
                {
                    if (arrayOfPoint[i] > arrayOfPoint[i + step])
                    { 
                        Swap(i, step);
                    }
                }
                step = (int)(step / factor);
            }
        }
        private void Swap(int i, int step)
        {
            wait();
            int temp = arrayOfPoint[i];
            arrayOfPoint[i] = arrayOfPoint[i + step];
            arrayOfPoint[i + step] = temp;
            ChartClear();
            ChartDrawing();
        }

        private void ChartClear()
        {
            for (int i = 0; i < arrayOfPoint.Length; i++)
            {
                chart1.Series[0].Points.Clear();
            }
        }
        private void ChartDrawing()
        {
            for (int i = 0; i < arrayOfPoint.Length; i++)
            {
                chart1.Series[0].Points.AddY(arrayOfPoint[i]);
            }
        }

        private void wait()
        {
            var t = Task.Run(async delegate { await Task.Delay(Speed()); });
            t.Wait();
        }

        private int Speed()
        {
            if (comboBox.SelectedIndex == 0)
            {
                return 165;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                return 250;
            }
            else if (comboBox.SelectedIndex == 2)
            {
                return 500;
            }
            else if (comboBox.SelectedIndex == 3)
            {
                return 1000;
            }
            else
            {
                return 2000;
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            FormInfo forminfo = new FormInfo();
            forminfo.ShowDialog();
        }
    }
}
