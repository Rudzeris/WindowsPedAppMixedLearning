using System.Diagnostics.Eventing.Reader;

namespace WindowsPedAppMixedLearning
{
    public partial class Form1 : Form
    {
        Point sizeDefault = new Point(440, 580);
        Point locationDefault = new Point(12, 12);
        string TextPanel = "Main Menu";
        string Theory1 = "A";
        string Theory2 = "B";
        string Theory3 = "C";
        string Theory4 = "Преимущества смешанного обучения: мешанная школа — это дань стремительно цифровизующейся современности. Вот плюсы этого подхода:\r\n\r\nУчебные материалы доступны 24/7 с любого устройства и можно выполнять задания в удобное время, независимо от графика учебного заведения или библиотеки.\r\nНа смешанном обучении появляется возможность оптимизировать расходы, так как нет острой необходимости в распечатках, учебниках и аудиториях.\r\nНалажена постоянная удобная связь с преподавателями, можно задать вопрос в любой момент и получить ответ до очной встречи.\r\nПрограмма ориентирована на людей со всеми типами восприятия: для аудиалов есть лекции, для визуалов — презентации, для кинестетиков — тесты и тренажеры.\r\nСмешанное обучение упрощает переход на полностью дистанционный режим, потому что уже есть готовая база материалов и остается только научить преподавателей работать удаленно.\r\nМинус гибридных образовательных проектов в том, что их успешность напрямую зависит от технической оснащенности организации и мотивации учащихся. Но если решить вопрос с техникой не всегда получается, то вторая проблема вполне преодолима. Мотивацию можно пробудить при постепенном переходе к дистанционным инструментам и выборе наиболее подходящей образовательной модели именно для вашей аудитории.";
        char TheoryPoint = '#';
        char Task2Char = '#';

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            DefaultLocation();
            CloseAll();
            MainMenuPanel.Visible = true;
        }

        private void DefaultLocation()
        {
            Size = new Size(480, 700);
            MainButtonPanel.Location = new Point(12, 598);
            MainButtonPanel.Size = new Size(440, 56);

            MainMenuPanel.Location = locationDefault;
            MainMenuPanel.Size = new Size(sizeDefault.X,sizeDefault.Y);

            LiteraturesPanel.Location = locationDefault;
            LiteraturesPanel.Size = new Size(sizeDefault.X,sizeDefault.Y);

            TheoryPanel.Location = locationDefault;
            TheoryPanel.Size = new Size(sizeDefault.X,sizeDefault.Y);

            InformationPanel.Location = locationDefault;
            InformationPanel.Size = new Size(sizeDefault.X,sizeDefault.Y);

            TheoryTextPanel.Location= locationDefault;
            TheoryTextPanel.Size = new Size(sizeDefault.X,sizeDefault.Y);

            TasksPanel.Location= locationDefault;
            TasksPanel.Size = new Size(sizeDefault.X,sizeDefault.Y);

            Task2Panel.Location= locationDefault;
            Task2Panel.Size = new Size(sizeDefault.X,sizeDefault.Y);

            Task1Panel.Location= locationDefault;
            Task1Panel.Size = new Size(sizeDefault.X,sizeDefault.Y);
        }

        private void CloseAll()
        {
            Text = TextPanel;
            NextButton.Enabled = false;
            MainMenuPanel.Visible = false;
            LiteraturesPanel.Visible = false;
            TheoryPanel.Visible = false;
            InformationPanel.Visible = false;
            TheoryTextPanel.Visible = false;
            NextButton.Enabled = false;
            Task2Panel.Visible = false;
            TasksPanel.Visible= false;
            Task1Panel.Visible = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (TextPanel == "Theory" || TextPanel == "Literatures" || TextPanel == "Information" || TextPanel == "Tasks") OpenMainMenu(sender, e);
            else if (TextPanel == "TheoryText") OpenTheory(sender, e);
            else if (TextPanel == "Task1" || TextPanel == "Task3") OpenTask(sender, e);
            else if (TextPanel == "Task2")
            {
                if (Task2Char == '1') OpenTask(sender, e);
                else if (Task2Char == '2') Task2_1();
                else if (Task2Char == '3') Task2_2();
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (TextPanel == "TheoryText")
            {
                switch (TheoryPoint)
                {
                    case '1':
                        TheoryPoint = '2';
                        OpenTheoryText(sender, e);
                        break;
                    case '2':
                        TheoryPoint = '3';
                        OpenTheoryText(sender, e);
                        break;
                    case '3':
                        TheoryPoint = '4';
                        OpenTheoryText(sender, e);
                        break;
                    case '4':
                        OpenTheory(sender, e);
                        break;
                }
            }
            if (TextPanel == "Task2")
            {
                if (Task2Char == '1') Task2_2();
                else if (Task2Char=='2') Task2_3();
                else if (Task2Char=='3') Task2_Result();
            }
        }

        private void OpenMainMenu(object sender, EventArgs e)
        {
            TextPanel = "Main Menu";
            CloseAll();
            MainMenuPanel.Visible = true;
        }

        private void OpenTheory(object sender, EventArgs e)
        {
            TextPanel = "Theory";
            CloseAll();
            TheoryPanel.Visible = true;
            TheoryPoint = '#';
        }

        private void OpenTheoryText(object sender, EventArgs e)
        {
            TextPanel = "TheoryText";
            CloseAll();
            TheoryTextPanel.Visible = true;

            NextButton.Enabled = true;

            switch (TheoryPoint)
            {
                case '1':
                    TheoryTextBox1.Text = Theory1;
                    break;
                case '2':
                    TheoryTextBox1.Text = Theory2;
                    break;
                case '3':
                    TheoryTextBox1.Text = Theory3;
                    break;
                case '4':
                    TheoryTextBox1.Text = Theory4;
                    break;
            }
        }

        private void OpenLiteratures(object sender, EventArgs e)
        {
            TextPanel = "Literatures";
            CloseAll();
            LiteraturesPanel.Visible = true;
        }

        private void OpenInformation(object sender, EventArgs e)
        {
            TextPanel = "Information";
            CloseAll();
            InformationPanel.Visible = true;
        }

        private void TheoryButton1_Click(object sender, EventArgs e)
        {
            TheoryPoint = '1';
            OpenTheoryText(sender, e);
        }

        private void TheoryButton2_Click(object sender, EventArgs e)
        {
            TheoryPoint = '2';
            OpenTheoryText(sender, e);
        }

        private void TheoryButton3_Click(object sender, EventArgs e)
        {
            TheoryPoint = '3';
            OpenTheoryText(sender, e);
        }

        private void TheoryButton4_Click(object sender, EventArgs e)
        {
            TheoryPoint = '4';
            OpenTheoryText(sender, e);
        }

        private void OpenTask(object sender, EventArgs e)
        {
            TextPanel = "Tasks";
            CloseAll();
            TasksPanel.Visible = true;
            NextButton.Enabled = false;
        }

        private void OpenTask1(object sender, EventArgs e)
        {
            TextPanel = "Task1";
            CloseAll();
            Task1Panel.Visible = true;
            Task1ButtonDefault();
            //Task1ButtonSwitch();
        }
        private void OpenTask2(object sender, EventArgs e)
        {
            TextPanel = "Task2";
            CloseAll();
            Task2Panel.Visible = true;
            Task2ButtonVisible(true);
            Task2_1();
            Task2B2.Text = "Ответить";
        }

        private void DefaultTask2()
        {
            Task21.BackColor = Color.White;
            Task22.BackColor = Color.White;
            Task23.BackColor = Color.White;
            Task24.BackColor = Color.White;
            Task25.BackColor = Color.White;
            Task26.BackColor = Color.White;
            Task27.BackColor = Color.White;
            Task28.BackColor = Color.White;
        }

        int[] Task2Answer = {0,0,0,0,0,0,0,0};
        int[] Task2Question = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] Points = { 0, 0, 0 };
        int[] Points2 = { 0, 0, 0 };

        private void Task2_PointDelete(int x)
        {
            for (int i = 2; i >= x-1; i--)
            {
                Points[i] = 0;
            }
        }

        private void Task2_1()
        {
            NextButton.Enabled = false;
            Task2_PointDelete(1);
            Task2Char = '1';
            Task2Text.Text = "Text1";
            DefaultTask2();
            // Сколько баллов будет давать каждый ответ:
            Task2Question[0] = 1;
            Task21.Text = "1";
            Task2Question[1] = 1;
            Task22.Text = "2";
            Task2Question[2] = 1;
            Task23.Text = "3";
            Task2Question[3] = -1;
            Task24.Text = "4";
            Task2Question[4] = -1;
            Task25.Text = "5";
            Task2Question[5] = -1;
            Task26.Text = "6";
            Task2Question[6] = -1;
            Task27.Text = "7";
            Task2Question[7] = 1;
            Task28.Text = "8";

            // Дальше не менять - там будем записывать ответы
            Task2Answer[0] = 0;
            Task2Answer[1] = 0;
            Task2Answer[2] = 0;
            Task2Answer[3] = 0;
            Task2Answer[4] = 0;
            Task2Answer[5] = 0;
            Task2Answer[6] = 0;
            Task2Answer[7] = 0;
            //Task2B2.Text = "Проверить";
        }
        private void Task2_2()
        {
            NextButton.Enabled = false;
            Task2_PointDelete(2);
            Task2Char = '2';
            Task2Text.Text = "Text2";
            DefaultTask2();
            // Сколько баллов будет давать каждый ответ:
            Task2Question[0] = 1;
            Task21.Text = "1";
            Task2Question[1] = 1;
            Task22.Text = "2";
            Task2Question[2] = 1;
            Task23.Text = "3";
            Task2Question[3] = -1;
            Task24.Text = "4";
            Task2Question[4] = -1;
            Task25.Text = "5";
            Task2Question[5] = -1;
            Task26.Text = "6";
            Task2Question[6] = -1;
            Task27.Text = "7";
            Task2Question[7] = 1;
            Task28.Text = "8";

            // Дальше не менять - там будем записывать ответы
            Task2Answer[0] = 0;
            Task2Answer[1] = 0;
            Task2Answer[2] = 0;
            Task2Answer[3] = 0;
            Task2Answer[4] = 0;
            Task2Answer[5] = 0;
            Task2Answer[6] = 0;
            Task2Answer[7] = 0;
            //Task2B2.Text = "Проверить";
        }

        private void Task2_3()
        {
            NextButton.Enabled = false;
            Task2_PointDelete(3);
            Task2Char = '3';
            Task2Text.Text = "Text3";
            DefaultTask2();
            // Сколько баллов будет давать каждый ответ:
            Task2Question[0] = 1;
            Task21.Text = "1";
            Task2Question[1] = 1;
            Task22.Text = "2";
            Task2Question[2] = 1;
            Task23.Text = "3";
            Task2Question[3] = -1;
            Task24.Text = "4";
            Task2Question[4] = -1;
            Task25.Text = "5";
            Task2Question[5] = -1;
            Task26.Text = "6";
            Task2Question[6] = -1;
            Task27.Text = "7";
            Task2Question[7] = 1;
            Task28.Text = "8";

            // Дальше не менять - там будем записывать ответы
            Task2Answer[0] = 0;
            Task2Answer[1] = 0;
            Task2Answer[2] = 0;
            Task2Answer[3] = 0;
            Task2Answer[4] = 0;
            Task2Answer[5] = 0;
            Task2Answer[6] = 0;
            Task2Answer[7] = 0;
            //Task2B2.Text = "Проверить";
        }

        private void Task2_Result()
        {
            Task2ButtonVisible(false);
            Task2Text.Text = "Ваш результат: "+(Points.Sum()).ToString() + " из "+(Points2.Sum()).ToString();
            NextButton.Enabled = false;
            Task2Char = '1';
        }

        private void Task2ButtonVisible(bool x)
        {
            Task21.Visible = x;
            Task22.Visible = x;
            Task23.Visible = x;
            Task24.Visible = x;
            Task25.Visible = x;
            Task26.Visible = x;
            Task27.Visible = x;
            Task28.Visible = x;
            Task2B2.Visible = x;
        }
        private void OpenTask3(object sender, EventArgs e)
        {
            TextPanel = "Task1";
            CloseAll();

        }

        private void Task2B2_Click(object sender, EventArgs e)
        {
            NextButton.Enabled = true;
            int a = Task2Answer.Sum();
            if (a < 0)
            {
                a = 0;
            }

            int b = 0;
            foreach (int i in Task2Question)
            {
                if (i > 0)
                    b += i;
            }
            Task2Text.Text="Вы набрали: "+(a).ToString()+" из "+(b).ToString();
            if (Task2Char == '1')
            {
                Points[0] = a;
                Points2[0] = b;
            }
            if (Task2Char == '2')
            {
                Points[1] = a;
                Points2[1] = b;
            }
            if (Task2Char == '3')
            {
                Points[2] = a;
                Points2[2] = b;
            }
        }

        private void Task21_Click(object sender, EventArgs e)
        {
            if (Task21.BackColor != Color.Blue)
            {
                Task21.BackColor= Color.Blue;
                Task2Answer[0] = Task2Question[0];
            }
            else
            {
                Task2Answer[0] = 0;
                Task21.BackColor = Color.White;
            }
        }

        private void Task22_Click(object sender, EventArgs e)
        {
            if (Task22.BackColor != Color.Blue)
            {
                Task22.BackColor = Color.Blue;
                Task2Answer[1] = Task2Question[1];
            }
            else
            {
                Task2Answer[1] = 0;
                Task22.BackColor = Color.White;
            }
        }

        private void Task23_Click(object sender, EventArgs e)
        {
            if (Task23.BackColor != Color.Blue)
            {
                Task23.BackColor = Color.Blue;
                Task2Answer[2] = Task2Question[2];
            }
            else
            {
                Task2Answer[2] = 0;
                Task23.BackColor = Color.White;
            }
        }

        private void Task24_Click(object sender, EventArgs e)
        {
            if (Task24.BackColor != Color.Blue)
            {
                Task24.BackColor = Color.Blue;
                Task2Answer[3] = Task2Question[3];
            }
            else
            {
                Task2Answer[3] = 0;
                Task24.BackColor = Color.White;
            }
        }

        private void Task25_Click(object sender, EventArgs e)
        {
            if (Task25.BackColor != Color.Blue)
            {
                Task25.BackColor = Color.Blue;
                Task2Answer[4] = Task2Question[4];
            }
            else
            {
                Task2Answer[4] = 0;
                Task25.BackColor = Color.White;
            }
        }

        private void Task26_Click(object sender, EventArgs e)
        {
            if (Task26.BackColor != Color.Blue)
            {
                Task26.BackColor = Color.Blue;
                Task2Answer[5] = Task2Question[5];
            }
            else
            {
                Task2Answer[5] = 0;
                Task26.BackColor = Color.White;
            }
        }

        private void Task27_Click(object sender, EventArgs e)
        {
            if (Task27.BackColor != Color.Blue)
            {
                Task27.BackColor = Color.Blue;
                Task2Answer[6] = Task2Question[6];
            }
            else
            {
                Task2Answer[6] = 0;
                Task27.BackColor = Color.White;
            }
        }

        private void Task28_Click(object sender, EventArgs e)
        {
            if (Task28.BackColor != Color.Blue)
            {
                Task28.BackColor = Color.Blue;
                Task2Answer[7] = Task2Question[7];
            }
            else
            {
                Task2Answer[7] = 0;
                Task28.BackColor = Color.White;
            }
        }

        private void Task1ButtonDefault()
        {
            k = 0;
            Task11.Enabled = true;
            Task12.Enabled = true;
            Task13.Enabled = true;
            Task14.Enabled = true;
            Task15.Enabled = true;
            Task16.Enabled = true;
            Task17.Enabled = true;
            Task18.Enabled = true;

            //Task11.BackColor = Color.White;
            Task12.BackColor = Color.White;
            //Task13.BackColor = Color.White;
            Task14.BackColor = Color.White;
            //Task15.BackColor = Color.White;
            Task16.BackColor = Color.White;
            //Task17.BackColor = Color.White;
            Task18.BackColor = Color.White;
        }

        int k = 0;
        private void Task1ButtonSwitch()
        {
            if (k % 2 == 0)
            {
                Task12.Enabled = false;
                Task14.Enabled = false;
                Task16.Enabled = false;
                Task18.Enabled = false;

                if (Task11.BackColor!=Color.Blue)
                    Task11.Enabled = true;
                if (Task13.BackColor != Color.Blue)
                    Task13.Enabled = true;
                if (Task15.BackColor != Color.Blue)
                    Task15.Enabled = true;
                if (Task17.BackColor != Color.Blue)
                    Task17.Enabled = true;
            }
            else
            {
                Task11.Enabled = false;
                Task13.Enabled = false;
                Task15.Enabled = false;
                Task17.Enabled = false;

                if (Task12.BackColor != Color.Blue)
                    Task12.Enabled = true;
                if (Task14.BackColor != Color.Blue)
                    Task14.Enabled = true;
                if (Task16.BackColor != Color.Blue)
                    Task16.Enabled = true;
                if (Task18.BackColor != Color.Blue)
                    Task18.Enabled = true;
            }
        }

        private bool Task1ColorSearch(Color C)
        {
            bool cs1 = false;
            if (Task12.BackColor == C)
            {
                Task12.BackColor = Color.White;
                cs1 = true;
            }
            if(Task14.BackColor==C)
            {
                Task14.BackColor = Color.White;
                cs1 = true;
            }
            if (Task16.BackColor==C)
            {
                Task16.BackColor = Color.White;
                cs1 = true;
            }
            if (Task18.BackColor == C)
            {
                Task18.BackColor = Color.White;
                cs1 = true;
            }
            return cs1;
        }

        Color A=Color.White;
        private void Task11_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.White)
            {
                ((Button)sender).BackColor = A;
                A = Color.White;
            }
            else
                if (Task1ColorSearch(((Button)sender).BackColor))
                return;
            else
                A = ((Button)sender).BackColor;
            
            
        }
    }
}