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
        }

        private void CloseAll()
        {
            Text = TextPanel;
            PrevButton.Enabled = false;
            MainMenuPanel.Visible = false;
            LiteraturesPanel.Visible = false;
            TheoryPanel.Visible = false;
            InformationPanel.Visible = false;
            TheoryTextPanel.Visible = false;
            PrevButton.Enabled = false;
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

            PrevButton.Enabled = true;

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
    }
}