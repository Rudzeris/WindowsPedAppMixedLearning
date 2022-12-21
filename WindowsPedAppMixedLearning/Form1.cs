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
        string Theory4 = "D";
        char TheoryPoint = '#';

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

            panel1.Location= locationDefault;
            panel1.Size = new Size(sizeDefault.X,sizeDefault.Y);
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
            panel1.Visible = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (TextPanel == "Theory" || TextPanel == "Literatures" || TextPanel == "Information") OpenMainMenu(sender, e);
            else if (TextPanel == "TheoryText") OpenTheory(sender, e);
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
        }

        private void OpenTask1(object sender, EventArgs e)
        {
            TextPanel = "Task1";
            CloseAll();
        }

        char Task2 = '#';
        private void OpenTask2(object sender, EventArgs e)
        {
            TextPanel = "Task2";
            CloseAll();
            Task2Panel.Visible = true;
            Task2_1();
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
        private void Task2_1()
        {
            Task2 = '1';
            Task2Text.Text = "Text";
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
            Task2B2.Text = "Проверить";
        }
        private void OpenTask3(object sender, EventArgs e)
        {
            TextPanel = "Task1";
            CloseAll();

        }

        private void Task2B2_Click(object sender, EventArgs e)
        {
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
    }
}