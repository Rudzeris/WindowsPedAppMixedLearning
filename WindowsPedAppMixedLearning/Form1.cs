using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Numerics;

namespace WindowsPedAppMixedLearning
{
    public partial class Form1 : Form
    {
        // ������������
        class User
        {
            string name;
            string login;
            string password;
            bool teacher;
            public User(string name, string login, string password, bool teacher = true)
            {
                this.name = name;
                this.login = login;
                this.password = password;
                this.teacher = teacher;
            }
            public string GetName()
            {
                return name;
            }
            public string GetLogin()
            {
                return login;
            }
            public bool IsLogin(string login)
            {
                return this.login == login;
            }
            public bool IsPassword(string password)
            {
                return this.password == password;
            }
            public bool IsTeacher()
            {
                return teacher;
            }
        }

        // ����� ������������ (��������)
        class Student : User
        {
            bool[][] access = {
                new bool[]{
                false, // ������ 1
                false, // ������ 2
                false, // ������ 3
                false, // ������ 4
                },
                new bool[]{
                false, // ������� 1 - ����� ����
                false, // ������� 2 - �����������
                false, // ������� 3 - ����
                }
            };
            public Student(string name, string login, string password) : base(name, login, password, false)
            {
            }
            public void SetAccess(bool[][] access)
            {
                for (int i = 0; i < access.Length && i < this.access.Length; i++)
                {
                    for (int j = 0; j < access[i].Length && j < this.access[i].Length; j++)
                    {
                        this.access[i][j] = access[i][j];
                    }
                }
            }
            public bool[][] GetAccess()
            {
                return access;
            }
        }

        List<User> users = new List<User>();
        User user;

        List<List<Button>> AccessButtons = new List<List<Button>>();
        List<List<List<RadioButton>>> RadioAccess = new List<List<List<RadioButton>>>();

        string codeX = "12345";

        bool typeUser = false;

        Point sizeDefault = new Point(440, 580);
        Point locationDefault = new Point(12, 12);
        string TextPanel = "Main Menu";
        string Theory1 = "\t����� �� ����� ����������� ���� ����������� ���������������� �������� �������� ���������� (������) ���������� ��������, ������� �������� � ���� �������� ������������� � �������������� ��������. \n \t��� ��������� ���������, � ������������ � ���� � 52653-2006 ��������������-���������������� ���������� � �����������. ������� � ������������, ���������� ��������������� ����������, �������������� ��������� �������� (������) �������� � ����� ��� ���������� ���������. ���������� (������) �������� ������������, �������� ���� �� �����, ��������� � ������� ���������� ��� ����������� � �������������-�������������������� ����. \r\n\t����� �������, ������ ���������� �������� ����� ��� ������������� ��������� ��������: 1) ������� + ����� �������� � 2) ������� + ���������� ��������;\r\n\t��������� �������� ���������� ������������ ����� ������������� ��������������� ����������, ������� ������� ����������� ��� ������������� � ����������� ��������.\r\n\t���������� �������� ������������ ��������� ������ ��������:\n\r\n1.\t���������� �������: ��������� ������ ��������� � ���� ����������� ��� ������ �����.\r\n2.\t����������� ������� (������ �������): ������� ����� ���� ���������� � �����������. ���������� �������� ������ ��� ����������, � ����� ��������� ������������ �������.\r\n3.\t������� ��������� ��������� (�������� � ������������ �������): ��������� ������������ � �������� � � ����������� ����, ������������ ��������� �������������� ����������.\r\n4.\t������ - ������� � ��������������� � ����������.\r\n5.\t�������������� � ��������� ������ - ������� (��������������): �������� ������� ������ � ���������, ������� ���������� �� ��������� ����������, ������ ������ � �������, ������������� ������������ � ��������������� �� ���������� ������.\r\n6.\t����������� �������� �������: ������� ����������� �\r\n7.\t�������������� � ������� ��������� ������� ��������-������������.\r\n8.\t����� � �����������, �������� � ���������.\n\r\n\t� ���������� ����������� ��������� �������� ��������� �� ������ ����������� � ��������, �� ������ �������, ����������� ��� ������ �� ����� ��������, ������� �� ���� ���������� ��� �� ����������� ��������, ����������� ���������� �������� ���������, � �������� ������������ ������� �� ����� �������.\r\n\t��������� �������� ���������� � ���� ����� ������ � �������������� ��������. �� ������ �������� ������� ������ ������������: ���������������� ������� � �������, ��������� � ��������, ��������� � ��������� ������ � ������� �������� �����. �� �������������� �������� �������: ������ ������ ��������, ������������ ���������, ����������� ��� ��������������� ����������� � ����������� ��������.";
        string Theory2 = "\t�������������, ������������ ��������� ���������� ��������, ���������� ������������� ������ � ������� ��� ��������� � ������� �������. ���������� ����� 40 ������� ���������� ��������, �� �� ��� ��� ��������� ����������.\r\n\t���� �� �������� �������:\r\n\n�\t����������� ����� � ����� ������� ��� ���������� ������, ��������� ��� �� ���������� �� ��������� ���������� �������������� ������������ �������� ��������. ��� ��������� �������������� ����������� ������ (������� ���������, ���� �������) � ��������� ����������� ������������� ����� ������ �� �����.\r\n�������� �������� ���� � ������� ������-�����, ��������� ������������ ������������ ������������, ������������� � ���������: ���������� � ���������� ��� ��������� ���������. � ������ ���������� ����������� ��������� � ������ � ���, ������� ����� ��������� � ���� ��������� ������������, �������� ��� � ������ ������������� ������. �.�. �������� � �������� ������ ��������� �������. ��� ������ ���������� �������� ����� ����������� � ����� ��� �������� ������� � 3-5 ������.\r\n�\t������� ������� � �������� ����������� ������ ���������� �������� � ��������� � ������� �����. ������� ������� ����������� ��� ��������� � ������ � ������������� ������ ���������� ��������� (��������, Moodle).\n\r\n\t��� ������ ������� �� ������ �� ����� ������� ������������: ������ � ��������, ������-�������� � ��������� ������. ������ ������ �������� � ��������� ����� ������ - �������. ������� ����� ������ ����: ������ � �������� - ��������� �������� ����� �� �������; ������-�������� - �������� ������� ��������������� ������, ������ ���������������, �������������, ������ �������; ��������� ������ - ���������� ������ � ������� ������������ �����, �������� ��������������� ������� � ��������� �������� ����� �� ��������������.\r\n\t� ������� ����� ������� ��������� �� ������� � ������� ���, ����� �������� �� ������ �� ���. ������ ����� �������� �� ����� � ���� � ����������� �� �������������� ������. ������ ��� ������� ����� ������������ ���: ������ � �������� � ������-������; ��� ������: ������ � ��������, ������-������, ������ ��� ������������ �������� � �������������� ��������������� ������.\n\r\n�\t������� ����������� � ��� ������ ���������� �������� ������������, ��� ����� ������� � �������� �������� � ������� ������, � �� ���� ���� ��� ������������ � ������������ ����� (�����������), ��� ������������� �������� � ������-�����. � ������-����� �������� ����� ������� ����� ��������, ���������� ����������, ����������� ��������� ������, � ����� �������� ��� ����������� ��������. ���� ������ ������ ����������� � �����, �� �������� ����������� �������� ����������, ����� ������� ������� ��� ����� ����� �� ���������� ��������� ������-������������. ��� ������ ���������� �������� �������� ��� ���������� ������ �������� ��� �������, ��� ������-����� ��������� �� ��������.\r\n�\t������ ������ � ������ ������ ������ ���������� �������� � ���, ��� ������� �� ���������� �� ������� ��� ��� ���� ����� ������� ������������. �������� �������������� ���������� ������ ������, �������� ���� � ����, � ������� ��� ����� ������� ��������. � ���� ������ �� ������� ����� ������������ ������-�����. ������� �������� � ���������� �������� ��� ������������� � ���������, ������� ����� ������. ��� ������ �������� ���������� ��� �������� ���������� ������� �������, ��������� � ��������, ��� ��� ������� ��������� ������ ���������������.\n\r\n\t��� �� ����� ��������� 4 ������, ������� �. ����� �������� � ��������� �������� ��� � 2003 ����:\n\r\n�\tReplacement Model (����������) � ������� ����� �������� ��������� ����������� � ����������� �������. ������������� ������������ ������� �������, ��������� ������ � ������ ����������� �����������, �������� ������������;\r\n�\tSupplemental Model (��������������) � �������� ����� ������� ��������� ������������� ����������� ��������, ������� ����������� ������� � ������������ ���������;\r\n�\tEmporium Model � ������ ������������ ���������� ������� ��������� � �������� ������������ �������� �� ����������� ����� �������� ������������� � � ���������� ������������� ������������ �������;\r\n�\tBuffet Model � ��������� ��������������� ����������� �������������� ������������� ���������� � ����������� ������� � ����������� �� �� ��������������� ������������.\n\r\n\t� ���� ������� �. ������ � �. ���� ���������� ��������� ������� ��������� ���������� �������� � ��������������� �������:\n\r\n�\tRotation Model (the Station Rotation, Individual Rotation, Flipped Classroom), ��� ����� ����� ���������� ����������� ������������ ���������� � ����������� �������/�������;\r\n�\tFlex Model � �������� ����� �������� ��������� ����������� ��������, �������� ����� ����������� �������� ������ ������������ � �������������;\r\n�\tA La Carte Model � ������ ���� ����������� �������� �������������� ����������� ����� � ��������� �����������. ����� ������ ����� ���� ������� ��� ���������, ��� ������� �������� ������� �� ����� ������������ ��������������� ���������;\r\n�\tEnriched Virtual Model � ������� � ������ ����� ���������� � ������������ �������, � ���������� �������� ��������� ������� �������� � ��������������� � �������������� ��������.\r\n";
        string Theory3 = "\t�������� ����������� ���������� ��������:\n\r\n�\t��������� �������� ������������ ���������� ���������� �������� ��� ���������� ������������� �������� �������������� �� ���� �������� ����� ���������� ������������ �� ��;\r\n�\t����� ������ ��������� �������� ������������ ����������� �������������� ����������� ����� ����� � � ���������; ���� ����������� �������� ��������, �������� ���������;\r\n�\t��������� �������� ��������� ���������� ����� ���������� �������� � ��, ��� ������� ������ ������� � ����������� ��������������, ���������� ������ ��������� ��������;\r\n�\t���������� �������� � �������� ����� �������������� ������������ �������� �����������, �������� �� ����������� ����������� � ������������� ���������;\r\n�\t��������� �������� ������������ �������� ������� ������� (soft skills), ����������� ������� � � �����������, � �������������� ����, ��� �������� �� ���������� ���� �����;\r\n�\t��������� �������� ������������ ����������� �������� � ������������� ������� ������� ������ �����������, ������������� �� � ����������� ������� �����, ���������� ������������;\r\n�\t��������� �������� ������������ ������� ��� ����������� �������� ����� � ����� ��������, �������� ���� �������� ���������, �������� ����� ����������, ������������ ������, �������� ����������� �������������� ����������� � ���� ���� ��������;\r\n�\t����������� ����� ��������� ���� ���������� ������� �������� ������������ � ���������������� ������ (���� ���); ������ �� ����� ��� ���������� ����� ���������� ��������, ������� �������� �� ����������� ����������, ���������� ����� ����;\r\n�\t����� ����� �������������� ��������� �������������� ������������ ������� ������������ ��������� � ��� �� ������ ��, ��� � ������������ ��������� ����� �������� �����;\r\n�\t���������� ������������ ���� ����������� ��������� ������������: ���������� ������ ��� ���������, ��������, ���������, ������, ����������� ���������������, ����;\r\n�\t������ ��������� ���������� ��������� ������������ ����������� � ����� ����� ����������� ������� ��������, ���������� ���������� �������� ������������, ������ ��� �����, ��� � ������������� ������������, �������� �����- � �����������;\r\n�\t������� ������������� ��� ����������� �������� ������� �������������� �����������, ��������� � ��������� ������, ����������������, ��������� �������.\n\r\n\t��������� �������� ����� �� ������ �����������, �� � ����������� ��� ��������� � ����������:\n\r\n�\t������ ������� �������������� �������� ������ ����������� � ��������������; ��� ����� ���������� ��� ��������������, ��� � ��������� ������ � ��;\r\n�\t������������� ����������� ����� ������������� ������ ���������� � ����� ������� �����, ������������� � ����������� ������� ���� ��������;\r\n�\t���������� ���������������� � ����� �����������, �������� � ���������, ������� �� �����������, ���������� ������ ����������� ������� � �������;\r\n�\t������������ ������ ����������� �������������� ����������� ������������ ���� ��������������� ������������;\r\n�\t������ �������������� �������� ��� ��������, ��� ������;\r\n�\t������������� �����������, ����������� � ���������������� �����������;\r\n�\t������������� ������ ������� ��������� � ��������� ���������� �������� ���������� ��������;\r\n�\t������������� ���������� ���������������, ����������� � ���������������� ��������� ���������������� ��������, ������������, ��������� � ��������� ������;\r\n�\t���������� �������� ������� �������� ������������� ��� ��������� ��������;\r\n�\t������������� ��������� ������ ���������� ������� �� ���� ������������ ����������� ��� ����������� ���������� ��������, ��������� ����� ������� ����� �������� �����������.\r\n";
        string Theory4 = "\t������������� ���������� ���������� �������� ����������� ���������� ���������:\n\r\n1.\t������ ������� �������� ����������� �������� ������������ �������� � �������� � ������� �������;\r\n2.\t������������ � ��������� ����, ����� ����������� � �������� ������ ��������������� � ����� ���������� ������ ���� ����������;\r\n3.\t�������������� ����������� ������������ ���������� ���������;\r\n4.\t���������� ��������� � ���������� ������ �� ��������, ��� ������ ����������� ������������� �������;\r\n5.\t�������� ���������� �������������� �������� ��� ����� �����, ��� � � ���������������;\r\n6.\t�������� �������� ���������� �� ������� � �����;\r\n7.\t������������ ������������� ��������;\r\n8.\t��������� �������� �������� (� ��� ����� �� ���� ������������� ����� ����������� ������� ��������);\r\n9.\t�������������� �������� �� ���������;\r\n10.\t������������ ��������� ��������� ����������� ������� ����������� ������, ������������;\r\n11.\t��������� ��������������� ������������ ����������;\r\n12.\t����������� �������������� ��������� ������� ������������ ������� ����������;\r\n13.\t������������� ����������� ��������� ������� ������������;\r\n14.\t�������� ��������������� ����������;\r\n15.\t���������� ����������� � ������������ ������-������������� �������� ������������� ������������� \n\r\n\t��������� �������� � ������� �������, ��������������� �������� ������� ���� ��������� ��������������� ������� � ��� �������������, ��� � ���������, ��� ��������� �������� � ��� ������������ ��������. ���, ��������� �������� ����������� � ���� ��������:\n\r\n�\t��������� �������� ������� ������������ �������� (��������������� � ����������);\r\n�\t����������� ���� ������������ �������������� � ����������� � ������������ ��������.\n\r\n�������� ���� ���������� �������� ����������� � ������� ���������� ������������ ������������� ����������� � ������������ ��������. � ������ ���������� �������� ����������� ��������� �������� ���������� ������������ ������������� ����������� ���������� � ��������.\r\n";
        char TheoryPoint = '#';
        char Task2Char = '#';



        public Form1()
        {
            user = new Student("", "", "");
            InitializeComponent();
            MaximizeBox = false;
            DefaultLocation();
            CloseAll();
            MainMenuPanel.Visible = true;
            CodeTeacher(false);
            RegisterRadioButtonStudent.Checked = true;

            if (AccessButtons.Count == 0)
                AddAccessButton();
            if (RadioAccess.Count == 0)
                AddAccessRadio();

            if (!typeUser) CheckAccess();
            else
            {
                foreach (var i in AccessButtons)
                {
                    foreach (var y in i)
                        y.Enabled = true;
                }
            }
        }

        public int CountAccessButtons()
        {
            int count = 0;
            foreach (var a in AccessButtons)
                count += a.Count;
            return count;
        }
        private void AddAccessButton()
        {
            // ��������� ������ ������
            List<Button> A = new List<Button>();
            A.Add(TheoryButton1);
            A.Add(TheoryButton2);
            A.Add(TheoryButton3);
            A.Add(TheoryButton4);
            // ��������� ������ �������
            List<Button> B = new List<Button>();
            B.Add(OpenTask1Button); // ����� ����
            B.Add(OpenTask2Button); // ������������
            B.Add(OpenTask3Button); // ����

            AccessButtons.Add(A);
            AccessButtons.Add(B);
        }
        private void AddAccessRadio()
        {
            // ��������� ������ ������
            RadioAccess.Add(new List<List<RadioButton>>() {
            new List<RadioButton>(){ SettingUserTheory1Radio0, SettingUserTheory1Radio1},
            new List<RadioButton>(){ SettingUserTheory2Radio0, SettingUserTheory2Radio1},
            new List<RadioButton>(){ SettingUserTheory3Radio0, SettingUserTheory3Radio1},
            new List<RadioButton>(){ SettingUserTheory4Radio0, SettingUserTheory4Radio1}
            });
            RadioAccess.Add(new List<List<RadioButton>>(){
                new List<RadioButton>() { SettingUserTask1Radio0, SettingUserTask1Radio1 },
                new List<RadioButton>() { SettingUserTask2Radio0, SettingUserTask2Radio1 },
                new List<RadioButton>() { SettingUserTask3Radio0, SettingUserTask3Radio1 }
            });
        }

        private void DefaultLocation()
        {
            Size = new Size(480, 700);
            MainButtonPanel.Location = new Point(12, 598);
            MainButtonPanel.Size = new Size(440, 56);

            MainMenuPanel.Location = locationDefault;
            MainMenuPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            LiteraturesPanel.Location = locationDefault;
            LiteraturesPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            TheoryPanel.Location = locationDefault;
            TheoryPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            InformationPanel.Location = locationDefault;
            InformationPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            TheoryTextPanel.Location = locationDefault;
            TheoryTextPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            TasksPanel.Location = locationDefault;
            TasksPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            Task2Panel.Location = locationDefault;
            Task2Panel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            Task1Panel.Location = locationDefault;
            Task1Panel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            Task3Panel.Location = locationDefault;
            Task3Panel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            RegisterPanel.Location = locationDefault;
            RegisterPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            AuthPanel.Location = locationDefault;
            AuthPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            SettingPanel.Location = locationDefault;
            SettingPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);

            SettingUserPanel.Location = locationDefault;
            SettingUserPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);
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
            TasksPanel.Visible = false;
            Task1Panel.Visible = false;
            Task3Panel.Visible = false;
            RegisterPanel.Visible = false;
            AuthPanel.Visible = false;
            SettingPanel.Visible = false;
            SettingUserPanel.Visible = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (TextPanel == "Setting" || TextPanel == "Theory" || TextPanel == "Literatures" || TextPanel == "Information" || TextPanel == "Tasks") OpenMainMenu(sender, e);
            else if (TextPanel == "TheoryText") OpenTheory(sender, e);
            else if (TextPanel == "Task1" || TextPanel == "Task3") OpenTasks(sender, e);
            else if (TextPanel == "Task2")
            {
                if (Task2Char == '1') OpenTasks(sender, e);
                else if (Task2Char == '2') Task2_1();
                else if (Task2Char == '3') Task2_2();
            }
            else if (TextPanel == "Setting Student") OpenSetting(sender, e);
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
                else if (Task2Char == '2') Task2_Result();
                //else if (Task2Char=='3') Task2_Result();
            }
        }

        private void CheckAccess()
        {
            SettingPanel.Visible = false;
            OpenSettingButton.Visible = false;
            bool[][] temp = ((Student)user).GetAccess();
            bool Theory = false, Task = false;
            for (short i = 0; i < AccessButtons.Count && i < temp.Length; i++)
            {
                for (short j = 0; j < AccessButtons[i].Count && j < temp[i].Length; j++)
                {
                    AccessButtons[i][j].Enabled = temp[i][j];
                }
            }
            foreach (var i in AccessButtons[0])
            {
                if (i.Enabled == true) Theory = true;
            }
            if (!Theory) OpenTheoryButton.Enabled = false;
            else OpenTheoryButton.Enabled = true;

            foreach (var i in AccessButtons[1])
            {
                if (i.Enabled == true) Task = true;
            }
            if (!Task) OpenTasksButton.Enabled = false;
            else OpenTasksButton.Enabled = true;

        }

        private void OpenMainMenu(object sender, EventArgs e)
        {
            TextPanel = "Main Menu";
            CloseAll();
            MainMenuPanel.Visible = true;
            if (!typeUser) CheckAccess();
            else
            {
                foreach (var a in AccessButtons)
                {
                    foreach (var i in a)
                        i.Enabled = true;
                }
                OpenSettingButton.Visible = true;
                OpenTheoryButton.Enabled = true;
                OpenTasksButton.Enabled = true;
                OpenSettingButton.Visible = true;
            }
            BackButton.Enabled = true;
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

        private void OpenTasks(object sender, EventArgs e)
        {
            TextPanel = "Tasks";
            CloseAll();
            TasksPanel.Visible = true;
            NextButton.Enabled = false;
        }

        private void OpenTask1(object sender, EventArgs e)
        {
            TextPanel = "Task1";
            //Task1Text.Text = "Task1";
            CloseAll();
            Task1Panel.Visible = true;
            Task1ButtonDefault();
            Task1ButtonVisible(true);
            //Task1ButtonSwitch();
        }
        private void OpenTask2(object sender, EventArgs e)
        {
            TextPanel = "Task2";
            CloseAll();
            Task2Panel.Visible = true;
            Task2ButtonVisible(true);
            Task2_1();
            Task2B2.Text = "��������";
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

        int[] Task2Answer = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] Task2Question = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] Points = { 0, 0, 0 };
        int[] Points2 = { 0, 0, 0 };

        private void Task2_PointDelete(int x)
        {
            for (int i = 2; i >= x - 1; i--)
            {
                Points[i] = 0;
            }
        }

        private void Task2_1()
        {
            NextButton.Enabled = false;
            Task2_PointDelete(1);
            Task2Char = '1';
            Task2Text.Text = "����� �������� ����������� � ���������� �������������� ������?";
            DefaultTask2();
            // ������� ������ ����� ������ ������ �����:
            Task2Question[0] = 1;
            Task21.Text = "������������� ����";
            Task2Question[1] = 1;
            Task22.Text = "��������� ����������";
            Task2Question[2] = 1;
            Task23.Text = "��������������� ������";
            Task2Question[3] = -1;
            Task24.Text = "������� ��������";
            Task2Question[4] = -1;
            Task25.Text = "������� ����� ����������";
            Task2Question[5] = 1;
            Task26.Text = "������������ ��� ������";

            Task27.Visible = false;
            Task28.Visible = false;

            Task2Question[6] = 0;
            Task27.Text = "";
            Task2Question[7] = 0;
            Task28.Text = "";

            // ������ �� ������ - ��� ����� ���������� ������
            Task2Answer[0] = 0;
            Task2Answer[1] = 0;
            Task2Answer[2] = 0;
            Task2Answer[3] = 0;
            Task2Answer[4] = 0;
            Task2Answer[5] = 0;
            Task2Answer[6] = 0;
            Task2Answer[7] = 0;
            //Task2B2.Text = "���������";
        }
        private void Task2_2()
        {
            NextButton.Enabled = false;
            Task2_PointDelete(2);
            Task2Char = '2';
            Task2Text.Text = "�������� ������� ����� ���������� ��� ��������� ����������� ��������";
            DefaultTask2();
            // ������� ������ ����� ������ ������ �����:
            Task2Question[0] = -1;
            Task21.Text = "�������� '������ �������'";
            Task2Question[1] = 1;
            Task22.Text = "������ ������� �������������� ��������";
            Task2Question[2] = 1;
            Task23.Text = "�������������� �����������";
            Task2Question[3] = -1;
            Task24.Text = "���������� ���������� ��������";
            Task2Question[4] = -1;
            Task25.Text = "������� ���������";
            Task2Question[5] = 1;
            Task26.Text = "������ ��������������";
            Task2Question[6] = -1;
            Task27.Text = "�������� ������ ��������������";
            Task2Question[7] = 1;
            Task28.Text = "���������� ����������������";

            Task27.Visible = true;
            Task28.Visible = true;

            // ������ �� ������ - ��� ����� ���������� ������
            Task2Answer[0] = 0;
            Task2Answer[1] = 0;
            Task2Answer[2] = 0;
            Task2Answer[3] = 0;
            Task2Answer[4] = 0;
            Task2Answer[5] = 0;
            Task2Answer[6] = 0;
            Task2Answer[7] = 0;
            //Task2B2.Text = "���������";
        }

        private void Task2_3()
        {
            NextButton.Enabled = false;
            Task2_PointDelete(3);
            Task2Char = '3';
            Task2Text.Text = "Text3";
            DefaultTask2();
            // ������� ������ ����� ������ ������ �����:
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

            // ������ �� ������ - ��� ����� ���������� ������
            Task2Answer[0] = 0;
            Task2Answer[1] = 0;
            Task2Answer[2] = 0;
            Task2Answer[3] = 0;
            Task2Answer[4] = 0;
            Task2Answer[5] = 0;
            Task2Answer[6] = 0;
            Task2Answer[7] = 0;
            //Task2B2.Text = "���������";
        }

        private void Task2_Result()
        {
            Task2ButtonVisible(false);
            Task2Text.Text = "��� ���������: " + (Points.Sum()).ToString() + " �� " + (Points2.Sum()).ToString();
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
            TextPanel = "Task3";
            CloseAll();
            Task3Panel.Visible = true;
            Task3Result.Text = "���������";
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
            Task2Text.Text = "�� �������: " + (a).ToString() + " �� " + (b).ToString();
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
                Task21.BackColor = Color.Blue;
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
        private bool Task1ColorSearch(Color C)
        {
            bool cs1 = false;
            if (Task12.BackColor == C)
            {
                Task12.BackColor = Color.White;
                cs1 = true;
            }
            if (Task14.BackColor == C)
            {
                Task14.BackColor = Color.White;
                cs1 = true;
            }
            if (Task16.BackColor == C)
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

        Color A = Color.White;
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

        private void Task1ButtonVisible(bool x)
        {
            Task11.Visible = x;
            Task12.Visible = x;
            Task13.Visible = x;
            Task14.Visible = x;
            Task15.Visible = x;
            Task16.Visible = x;
            Task17.Visible = x;
            Task18.Visible = x;
            Task1ResultButton.Visible = x;
        }

        private void Task1ResultButton_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (Task11.BackColor == Task12.BackColor)
            {
                k++;
            }
            if (Task13.BackColor == Task14.BackColor)
            {
                k++;
            }
            if (Task15.BackColor == Task16.BackColor)
            {
                k++;
            }
            if (Task17.BackColor == Task18.BackColor)
            {
                k++;
            }
            Task1ButtonVisible(false);
            Task1Text.Text = "�����";
            if (k != 4)
                Task1Text.Text = "�������";
        }

        private void Task3RadioDefaultChecked()
        {
            Task3_11.Checked = false;
            Task3_12.Checked = false;
            Task3_13.Checked = false;
            Task3_14.Checked = false;

            Task3_21.Checked = false;
            Task3_22.Checked = false;
            Task3_23.Checked = false;
            Task3_24.Checked = false;

            Task3_31.Checked = false;
            Task3_32.Checked = false;
            Task3_33.Checked = false;
            Task3_34.Checked = false;

            Task3_41.Checked = false;
            Task3_42.Checked = false;
            Task3_43.Checked = false;
            Task3_44.Checked = false;

            Task3_51.Checked = false;
            Task3_52.Checked = false;
            Task3_53.Checked = false;
            Task3_54.Checked = false;
        }

        private void Task3Result_click(object sender, EventArgs e)
        {
            int k = 0;
            if (Task3_11.Checked)
            {
                k++;
            }
            if (Task3_21.Checked)
            {
                k++;
            }
            if (Task3_31.Checked)
            {
                k++;
            }
            if (Task3_41.Checked)
            {
                k++;
            }
            if (Task3_51.Checked)
            {
                k++;
            }
            Task3RadioDefaultChecked();
            Task3Result.Text = "�����: " + k.ToString() + " �� 7";
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // �������� ���������� �� ����������� ���, �����, ������
            string[] temp = { RegisterNameTextBox.Text, RegisterLoginTextBox.Text, RegisterPasswordTextBox.Text };
            // ����� �� ����� � �������? (����� ���-�� ������)
            bool isExit = false;
            if (temp[0].Length < 1) // ��������� ��� �� �����
            {
                RegisterErrorFIO.Text = "��� ������";
                isExit = true;
            }
            else RegisterErrorFIO.Text = "";
            if (temp[1].Length < 4) // ��������� ����� �� �����
            {
                RegisterErrorLogin.Text = "�������� Login";
                isExit = true;
                if (temp[1].Length > 0) // ���� ����� ��������
                    if (!char.IsLetter(temp[1][0])) // ���� 1-� ������ - �� ����� - ������
                    {
                        RegisterErrorLogin.Text += ", ����� � �����";
                    }
            }
            else
            {
                RegisterErrorLogin.Text = "";
                if (temp[1].Length > 0) // ���� ����� ��������
                    if (!char.IsLetter(temp[1][0])) // ���� 1-� ������ - �� ����� - ������
                    {
                        RegisterErrorLogin.Text += "����� � �����";
                        isExit = true;
                    }
            }
            if (temp[2].Length < 4) // ���� ������ ��������
            {
                RegisterErrorPassword.Text = "�������� Password";
                isExit = true;
            }
            else RegisterErrorPassword.Text = "";
            if (isExit) return; // ���� ������ ����, �� �������

            // ����� �� ���������? ���� ����� ������, �� add = false
            bool add = true;
            foreach (var i in users)
            {
                if (i.IsLogin(temp[1])) // ���� ����� ������ �����, �� ��������� �� �����
                    add = false;
            }
            if (!add) // ���� �� ���������, �� ���� ���������� ������������ � ������� � �������
            {
                RegisterErrorLogin.Text = "����� login ��� ����������";
                return;
            }
            if (RegisterCode.Text != codeX)
            {
                RegisterInformation.Text = "��� ������������� �� ��������.";
                return;
            }
            // ������� ������������, ������� ��� ������ - �������� typeUser
            User tempUser;
            if (RegisterLabelCode.Visible) tempUser = new User(temp[0], temp[1], temp[2]);
            else tempUser = new Student(temp[0], temp[1], temp[2]);
            // ��������� � ������ �������������
            users.Add(tempUser);
            // ���������� ���� ������������
            if (RegisterLabelCode.Visible) RegisterInformation.Text = "������";
            else RegisterInformation.Text = "�������";
            RegisterInformation.Text += " ������� ���������������.\n���: " + temp[0] + "\nLogin: " + temp[1];
        }

        private void CodeTeacher(bool x)
        {
            //typeUser = x;
            RegisterLabelCode.Visible = x;
            RegisterCode.Visible = x;
        }
        private void RegisterRadioButtonTeacher_CheckedChanged(object sender, EventArgs e)
        {
            CodeTeacher(true);
        }

        private void RegisterRadioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            CodeTeacher(false);
        }

        private void OpenAuthPanel_Click(object sender, EventArgs e)
        {
            TextPanel = "Authentication";
            CloseAll();
            AuthLoginTextBox.Text = "";
            AuthPasswordTextBox.Text = "";
            AuthPanel.Visible = true;
            AuthInformation.Text = "";
            BackButton.Enabled = false;
        }

        private void OpenRegisterPanel_Click(object sender, EventArgs e)
        {
            TextPanel = "Registration";
            CloseAll();
            RegisterNameTextBox.Text = "";
            RegisterLoginTextBox.Text = "";
            RegisterPasswordTextBox.Text = "";
            RegisterPanel.Visible = true;
            RegisterInformation.Text = "";
            RegisterLabelCode.Text = "";
            RegisterErrorFIO.Text = "";
            RegisterErrorLogin.Text = "";
            RegisterErrorPassword.Text = "";
            BackButton.Enabled = false;
        }

        private void AuthLoginButton_Click(object sender, EventArgs e)
        {
            // �������� ���������� �� �����������: �����, ������
            string[] temp = { AuthLoginTextBox.Text, AuthPasswordTextBox.Text };

            bool logining = false;
            foreach (var i in users)
            {
                if (i.IsLogin(temp[0])) // ���� ����� ������ �����, �� ��������� �� �����
                    if (i.IsPassword(temp[1]))
                    {
                        logining = true;
                        user = i;
                        typeUser = user.IsTeacher();
                    }
            }
            if (!logining) // ���� �� ���������, �� ���� ���������� ������������ � ������� � �������
            {
                AuthInformation.Text = "�� ���������� �����.\nLogin � Password ������� �������.";
                return;
            }
            // ������� ������������, ������� ��� ������ - �������� typeUser

            // ���������� ���� ������������
            if (typeUser) AuthInformation.Text = "������";
            else AuthInformation.Text = "�������";
            AuthInformation.Text += ".\n���: " + temp[0] + "\nLogin: " + temp[1];
        }

        private void OpenSetting(object sender, EventArgs e)
        {
            TextPanel = "Setting";
            CloseAll();
            SettingPanel.Visible = true;
            SettingTextBox.Text = "";
            foreach (var i in users)
            {
                if (!i.IsTeacher())
                {
                    SettingTextBox.Text += "���: ";
                    SettingTextBox.Text += i.GetName() + ",\n";
                    SettingTextBox.Text += "Login: ";
                    SettingTextBox.Text += i.GetLogin() + "\n\n";
                }
            }
        }

        Student settingUser = null;
        private void OpenSettingStudent(object sender, EventArgs e)
        {
            settingUser = null;
            string selectedText = SettingTextBox.SelectedText;
            bool search = false;
            foreach (var i in users)
            {
                if (!i.IsTeacher() && i.IsLogin(selectedText))
                {
                    search = true;
                    settingUser = (Student)i;
                    break;
                }
            }
            if (!search)
            {
                SettingLabel.Text = "�� �������� " + selectedText + ", ��� �� �����";
                return;
            }
            TextPanel = "Setting Student";
            CloseAll();
            SettingUserPanel.Visible = true;
            if (settingUser != null)
            {
                SettingUserLabel.Text = "�� �������: " + settingUser.GetName();
                bool[][] tempAccess = settingUser.GetAccess();
                for (int j = 0; j < RadioAccess.Count() && j < tempAccess.Count(); j++)
                {
                    for (int i = 0; i < RadioAccess[j].Count() && i < tempAccess[j].Count(); i++)
                    {
                        if (tempAccess[j][i]) RadioAccess[j][i][0].Checked = true;
                        else RadioAccess[j][i][1].Checked = true;
                    }
                }
            }
        }

        private void SettingUserSaveButton_Click(object sender, EventArgs e)
        {
            bool[][] tempAccess = settingUser.GetAccess();
            for (int j = 0; j < RadioAccess.Count() && j < tempAccess.Count(); j++)
                for (int i = 0; i < RadioAccess[j].Count() && i < tempAccess[j].Count(); i++)
                {
                    if (RadioAccess[j][i][0].Checked) tempAccess[j][i] = true;
                    else tempAccess[j][i] = false;
                }
            settingUser.SetAccess(tempAccess);
        }
    }
}