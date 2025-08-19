// 代码生成时间: 2025-08-19 12:21:49
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace InteractiveChartGenerator
{
    public partial class MainForm : Form
    {
        private OxyPlot.WindowsForms.PlotView plotView;
        private LineSeries lineSeries;
        private Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
            InitPlot();
        }

        // 初始化图表
        private void InitPlot()
        {
            // 创建 PlotView 控件
            plotView = new OxyPlot.WindowsForms.PlotView
            {
                Dock = DockStyle.Fill,
                Model = new PlotModel { Title = "Interactive Chart Generator" }
            };

            // 添加 PlotView 控件到窗体
            this.Controls.Add(plotView);

            // 添加一个线性系列
            lineSeries = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColors.White
            };

            // 添加系列到模型
            plotView.Model.Series.Add(lineSeries);
        }

        // 生成随机数据并更新图表
        private void GenerateDataAndUpdateChart()
        {
            try
            {
                // 清空现有数据点
                lineSeries.Points.Clear();

                // 生成新的数据点
                for (int i = 0; i < 100; i++)
                {
                    double x = i;
                    double y = random.NextDouble() * 10;
                    lineSeries.Points.Add(new DataPoint(x, y));
                }

                // 更新图表
                plotView.Model.InvalidatePlot(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // 窗体加载时初始化
        private void MainForm_Load(object sender, EventArgs e)
        {
            GenerateDataAndUpdateChart();
        }

        // 添加按钮点击事件处理程序
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateDataAndUpdateChart();
        }
    }
}
