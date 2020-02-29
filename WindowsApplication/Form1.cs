using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace WindowsApplication
{
    public partial class Form1 : Form
    {
        int a, b, c;
        int x = 0;
        int z = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl);
        }

        private void button_Click(object sender, EventArgs e)
        {
            
            try
            {
                a = int.Parse(koefa.Text);
                b = int.Parse(koefb.Text);
                c = int.Parse(koefc.Text);
                x = int.Parse(koefx.Text);
                z = int.Parse(koefxend.Text);
                CreateGraph(zedGraphControl);
            }
            catch
            {
                MessageBox.Show("Неверные значения коэффициентов!");
                koefa.Clear();
                koefb.Clear();
                koefc.Clear();
                koefx.Clear();
                koefxend.Clear();
                koefa.Focus();
            }
        }

        private Color color;
        private void CreateGraph(ZedGraphControl zgc)
        {            
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.Text = "График параболы";
            myPane.XAxis.Title.Text = "Ось X";
            myPane.YAxis.Title.Text = "Ось Y";
            myPane.CurveList.Clear();

            double x1, y;
            
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            for (int i = x; i <= z; i++)
            {
                    x1 = i;
                    y = a * Math.Pow(x1, 2) + b * x1 + c;
                    list1.Add(x1, y);
                    list2.Add(-x1, y);
            }
            LineItem myCurve = myPane.AddCurve("sun", list1, color, SymbolType.Circle); // отрисовываем график
            LineItem my1Curve = myPane.AddCurve("", list2, color, SymbolType.None); // отрисовываем график
            myCurve.Line.IsVisible = false;

            // Задаем вид пунктирной линии для крупных рисок по оси X:
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 10;
            myPane.XAxis.MajorGrid.DashOff = 1;
            // Задаем вид пунктирной линии для крупных рисок по оси Y:
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 10;
            myPane.YAxis.MajorGrid.DashOff = 1;
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max=100;
            zgc.AxisChange();
            zgc.Refresh();

                     {
        SaveFileDialog savefile = new SaveFileDialog();
        savefile.DefaultExt = ".json";
            savefile.Filter = "Test Files|*.json";
                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK);
             
        }
            
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboBox1.SelectedItem == "Синий") 
            {
                color = Color.Blue;
            }
            if ((string)comboBox1.SelectedItem == "Красный") 
            {
                color = Color.Red;
            }
            if ((string)comboBox1.SelectedItem == "Зеленый")
            {
                color = Color.Green;
            }
            if ((string)comboBox1.SelectedItem == "Черный")
            {
                color = Color.Black;
            }
        }
    }
}

