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
        // Пользователь
        class User
        {
            string name;
            string login;
            string password;
            bool teacher;

            int[] tasks =
            {
                0,
                0,
                0,
            };
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
            public void SetTasks(int i, int x)
            {
                tasks[i] = x;
            }
            public void SetTasks(int[] tasks)
            {
                for (int i = 0; i < tasks.Length; i++)
                {
                    this.tasks[i] = tasks[i];
                }
            }
            public int[] GetTasks()
            {
                return tasks;
            }
            public int GetTasks(int i)
            {
                return tasks[i];
            }
        }

        // Права пользователя (Студента)
        class Student : User
        {
            bool[][] access = {
                new bool[]{
                false, // Лекция 1
                false, // Лекция 2
                false, // Лекция 3
                false, // Лекция 4
                false, // Лекция 5
                },
                new bool[]{
                false, // Задание 1 - найди пару
                false, // Задание 2 - соответсвие
                false, // Задание 3 - тест
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
        string SetingText = "Main Menu";
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

            Student temp = new Student("Иванов Иван Иванович", "i", "i");
            users.Add(temp);
            temp = new Student("Гумеров Халиль Хамитович", "x", "x");
            users.Add(temp);
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
            // Добавляем кнопки теории
            List<Button> A = new List<Button>();
            A.Add(TheoryButton1);
            A.Add(TheoryButton2);
            A.Add(TheoryButton3);
            A.Add(TheoryButton4);
            A.Add(TheoryButton5);
            // Добавляем кнопки заданий
            List<Button> B = new List<Button>();
            B.Add(OpenTask1Button); // найди пару
            B.Add(OpenTask2Button); // соответствия
            B.Add(OpenTask3Button); // тест

            AccessButtons.Add(A);
            AccessButtons.Add(B);
        }
        private void AddAccessRadio()
        {
            // Добавляем кнопки теории
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

            TheoryPPanel.Location = locationDefault;
            TheoryPPanel.Size = new Size(sizeDefault.X, sizeDefault.Y);
        }

        private void CloseAll()
        {
            //Text = SetingText;
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
            TheoryPPanel.Visible = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (SetingText == "Setting" || SetingText == "Literatures" || SetingText == "Information" || SetingText == "Tasks") OpenMainMenu(sender, e);
            else if (SetingText == "TheoryText") OpenTheory(sender, e);
            else if (SetingText == "Task1") OpenTasks(sender, e);
            else if (SetingText == "Task2")
            {
                if (Task2Char == '1') OpenTasks(sender, e);
                else if (Task2Char == '2') Task2_1();
                else if (Task2Char == '3') Task2_2();
            }
            else if (SetingText == "Setting Student") OpenSetting(sender, e);
            else if (SetingText == "Task3")
            {
                if (task3 == 1) OpenTasks(sender, e);
                else if (task3 == 2) Task3_1();
                else OpenTasks(sender, e);
            }
            else if (SetingText == "TheoryML")
            {
                if (theoryML != 0) OpenTheoryP(sender, e);
                else OpenMainMenu(sender, e);
            }
            else if (SetingText == "Theory")
            {
                switch (theoryML)
                {
                    case 2: OpenTheoryP(sender, e); break;
                    case 3: OpenTheoryP(sender, e); break;
                    case 4: OpenTheoryP(sender, e); break;
                    default: OpenMainMenu(sender, e); break;
                }
            }
            else if (SetingText == "TheoryMLText")
            {
                OpenTheory(sender, e);
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (SetingText == "TheoryText" || SetingText == "TheoryMLText")
            {
                switch (TheoryPoint)
                {
                    case '1':
                        if (TheoryButton2.Enabled)
                        {
                            TheoryPoint = '2';
                            TheoryText();
                        }
                        else OpenTheory(sender, e);
                        break;
                    case '2':
                        if (TheoryButton3.Enabled)
                        {
                            TheoryPoint = '3';
                            TheoryText();
                        }
                        else OpenTheory(sender, e);
                        break;
                    case '3':
                        if (TheoryButton4.Enabled)
                        {
                            TheoryPoint = '4';
                            TheoryText();
                        }
                        else OpenTheory(sender, e);
                        break;
                    case '4':
                        if (TheoryButton4.Enabled)
                        {
                            TheoryPoint = '5';
                            TheoryText();
                        }
                        else OpenTheory(sender, e);
                        break;
                    case '5':
                        OpenTheory(sender, e);
                        break;
                }
            }
            else if (SetingText == "Task2")
            {
                if (Task2Char == '1') Task2_2();
                else if (Task2Char == '2') Task2_Result();
                //else if (Task2Char=='3') Task2_Result();
            }
            else if (SetingText == "Task3")
            {
                if (task3 == 1)
                {
                    Task3Result_click(sender, e);
                }
                else if (task3 == 2)
                {
                    Task3Result_click(sender, e);
                    OpenTasks(sender, e);
                }
            }
            else if (SetingText == "Theory")
            {
                switch (theoryML)
                {
                    case 2: theoryML++; OpenTheory(sender, e); break;
                    case 3: theoryML++; OpenTheory(sender, e); break;
                    case 4: OpenTheoryP(sender, e); break;
                }
            }
        }

        private void CheckAccess()
        {
            SettingPanel.Visible = false;
            OpenSettingButton.Visible = false;
            OpenTheoryPButton.Visible = false;
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
            SetingText = "Main Menu";
            CloseAll();
            theoryML = 1;
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
                OpenTheoryPButton.Visible = true;
            }
            BackButton.Enabled = true;
        }

        private void OpenTheory(object sender, EventArgs e)
        {
            TheoryLabel.Text = "";
            SetingText = "Theory";
            CloseAll();
            TheoryPanel.Visible = true;
            TheoryPoint = '#';
            // Текст кнопочек
            string t1 = "", t2 = "", t3 = "", t4 = "", t5 = "";
            NextButton.Enabled = true;
            if (theoryML == 1) // Теория студента
            {
                NextButton.Enabled = false;
                t1 = "Что такое Python?";
                t2 = "Python как калькулятор";
                t3 = "Переменные";
                t4 = "Операторы ветвления";
                t5 = "Циклы";
                TheoryLabel.Text = "Python";
            }
            else if (theoryML == 2) // Теория препода 1
            {
                t1 = "Что это?";
                t2 = "Формы";
                t3 = "Методы";
                t4 = "Виды деятельности";
                t5 = "Условия реализации";
                TheoryLabel.Text = "Гибкая модель";
            }
            else if (theoryML == 3) // Теория препода 2
            {
                t1 = "Что это?";
                t2 = "Формы";
                t3 = "Методы";
                t4 = "Виды деятельности";
                t5 = "Условия реализации";
                TheoryLabel.Text = "Перевернутый класс";
            }
            else if (theoryML == 4) // Теория препода 3
            {
                t1 = "Что это?";
                t2 = "Формы";
                t3 = "Методы";
                t4 = "Виды деятельности";
                t5 = "Условия реализации";
                TheoryLabel.Text = "Смешанный курс";
            }
            else
            {
                t1 = "";
                t2 = "";
                t3 = "";
                t4 = "";
                t5 = "";
            }
            TheoryButton1.Text = t1;
            TheoryButton2.Text = t2;
            TheoryButton3.Text = t3;
            TheoryButton4.Text = t4;
            TheoryButton5.Text = t5;
        }

        private void OpenTheoryText(string theoryText)
        {
            //TextPanel = "TheoryText";
            CloseAll();
            TheoryTextPanel.Visible = true;
            NextButton.Enabled = true;
            string filename = "Theory\\" + theoryText + "\\Theory" + TheoryPoint.ToString() + ".rtf";
            if (File.Exists(filename))
                TheoryTextBox1.LoadFile(filename);
            else
            {
                filename = "..\\" + filename;
                if (File.Exists(filename))
                    TheoryTextBox1.LoadFile(filename);
                else
                {
                    filename = "..\\" + filename;
                    if (File.Exists(filename))
                        TheoryTextBox1.LoadFile(filename);
                    else
                    {
                        filename = "..\\" + filename;
                        if (File.Exists(filename))
                            TheoryTextBox1.LoadFile(filename);
                        else
                            TheoryTextBox1.Text = "Ошибочка какая-то.\nНе удалось найти лекцию.\nФункция - OpenTheoryText";
                    }
                }
            }
        }

        byte theoryML = 1;

        private void TheoryText()
        {
            string x = "";
            SetingText = "TheoryMLText";
            switch (theoryML)
            {
                case 1:
                    SetingText = "TheoryText";
                    x += "Student";
                    break;
                case 2:
                    x += "GM";
                    break;
                case 3:
                    x += "PK";
                    break;
                case 4:
                    x += "SK";
                    break;
                default:
                    x = "0";
                    break;
            }
            if (x != "0")
            {
                //x += TheoryPoint;
                OpenTheoryText(x);
            }
            else
            {
                TheoryTextBox1.Text = "Ошибочка какая-то.\nНе удалось выбрать лекцию.\nФункция - TheoryText";
            }
        }

        private void TheoryButton1_Click(object sender, EventArgs e)
        {
            TheoryPoint = '1'; TheoryText();
        }

        private void TheoryButton2_Click(object sender, EventArgs e)
        {
            TheoryPoint = '2'; TheoryText();
        }

        private void TheoryButton3_Click(object sender, EventArgs e)
        {
            TheoryPoint = '3'; TheoryText();
        }

        private void TheoryButton4_Click(object sender, EventArgs e)
        {
            TheoryPoint = '4'; TheoryText();
        }

        private void TheoryButton5_Click(object sender, EventArgs e)
        {
            TheoryPoint = '5'; TheoryText();
        }

        private void OpenLiteratures(object sender, EventArgs e)
        {
            SetingText = "Literatures";
            CloseAll();
            LiteraturesPanel.Visible = true;
        }

        private void OpenInformation(object sender, EventArgs e)
        {
            SetingText = "Information";
            CloseAll();
            InformationPanel.Visible = true;
        }
        private void OpenTasks(object sender, EventArgs e)
        {
            SetingText = "Tasks";
            CloseAll();
            TasksPanel.Visible = true;
            NextButton.Enabled = false;

            TasksLabel.Visible = typeUser;
            TasksResultTextBox.Visible = typeUser;
            if (typeUser)
            {
                TasksResultTextBox.Text = "";
                List<User> userList = new List<User>();
                foreach (var i in users)
                {
                    if (i.IsTeacher()) userList.Add(i);
                    else
                    {
                        int[] tasks = i.GetTasks();
                        TasksResultTextBox.Text += "Студент: " + i.GetName() + "\nОценки:\n";
                        for (int j = 0; j < tasks.Length; j++)
                        {
                            TasksResultTextBox.Text += "Задание " + (j + 1).ToString() + " - " + (tasks[j]).ToString() + ((j != tasks.Length - 1) ? ("\n") : ("\n\n"));
                        }
                    }
                }
                foreach (var i in userList)
                {
                    int[] tasks = i.GetTasks();
                    TasksResultTextBox.Text += "Преподаватель: " + i.GetName() + "\nОценки:\n";
                    for (int j = 0; j < tasks.Length; j++)
                    {
                        TasksResultTextBox.Text += "Задание " + (j + 1).ToString() + " - " + (tasks[j]).ToString() + ((j != tasks.Length - 1) ? ("\n") : ("\n\n"));
                    }
                }
            }
        }

        private void OpenTask1(object sender, EventArgs e)
        {
            SetingText = "Task1";
            task1Num = 0;
            task1 = '1';
            Task11Text();
            //Task1Text.Text = "Task1";
            CloseAll();
            Task1Panel.Visible = true;
            Task1ButtonDefault();
            Task1ButtonVisible(true);
            Task1ResultButton.Visible = true;
            Task1ResultButton.Text = "Проверить";
            //Task1ButtonSwitch();
        }

        private void Task1ButtonDefault()
        {
            Task1Text.Text = "Найди пару";
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
            //Task1ResultButton.Visible = x;
        }

        private void Task11Text()
        {
            Task11.Text = "=";
            Task12.Text = "Оператор сравнения";
            Task13.Text = "==";
            Task14.Text = "Оператор присваивания";
            Task15.Text = "!=";
            Task16.Text = "Оператор равенства";
            Task17.Text = ">=";
            Task18.Text = "Оператор неравенства";
        }
        private void Task12Text()
        {
            Task11.Text = "Бесконечный цикл";
            Task12.Text = "Короткая форма для else if";
            Task13.Text = "Цикл for";
            Task14.Text = "Функция отвечающая за генерацию всех желаемых значений управляющей переменной";
            Task15.Text = "Оператор elif";
            Task16.Text = "Представляет собой последовательность инструкций в программе, которые зациклены";
            Task17.Text = "range()";
            Task18.Text = "Тип цикла, доступный в Python, исходящий из наблюдения, что иногда важнее считать «обороты» цикла, чем проверять условия";
        }

        char task1 = '#';
        byte task1Num = 0;
        private void Task1ResultButton_Click(object sender, EventArgs e)
        {
            byte k = 0;
            if (task1 == '1')
            {
                if (Task11.BackColor == Task14.BackColor)
                {
                    k++;
                }
                if (Task13.BackColor == Task16.BackColor)
                {
                    k++;
                }
                if (Task15.BackColor == Task18.BackColor)
                {
                    k++;
                }
                if (Task17.BackColor == Task12.BackColor)
                {
                    k++;
                }
                Task1ButtonVisible(false);
                task1Num += (byte)((k == 4) ? (1) : (0));
                Task1Text.Text = "Верно";
                if (k != 4)
                    Task1Text.Text = "Неверно";
                task1 = '#';
                Task1ResultButton.Text = "Продолжить";
            }
            else
                if (task1 == '2')
            {
                if (Task11.BackColor == Task16.BackColor)
                {
                    k++;
                }
                if (Task13.BackColor == Task18.BackColor)
                {
                    k++;
                }
                if (Task15.BackColor == Task12.BackColor)
                {
                    k++;
                }
                if (Task17.BackColor == Task14.BackColor)
                {
                    k++;
                }
                Task1ButtonVisible(false);
                task1Num += (byte)((k == 4) ? (1) : (0));

                Task1Text.Text = "Верно";
                if (k != 4)
                    Task1Text.Text = "Неверно";
                Task1ResultButton.Visible = false;
            }
            else
            {
                Task1ButtonVisible(true);
                Task1ButtonDefault();
                task1 = '2';
                Task12Text();
                Task1ResultButton.Text = "Проверить";
            }
            user.SetTasks(0, (task1Num > (byte)user.GetTasks(0)) ? (task1Num) : (user.GetTasks(0)));
        }

        private void OpenTask2(object sender, EventArgs e)
        {
            SetingText = "Task2";
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
            Task2Text.Text = "Из каких частей состоит программа, которая выводит \"Hello World!\"";
            DefaultTask2();
            // Сколько баллов будет давать каждый ответ:
            Task2Question[0] = 1;
            Task21.Text = "Открывающая круглая скобка";
            Task2Question[1] = -1;
            Task22.Text = "Точка с запятой";
            Task2Question[2] = 1;
            Task23.Text = "Строка текста: \"Hello, World!\"";
            Task2Question[3] = 1;
            Task24.Text = "Кавычки";
            Task2Question[4] = 1;
            Task25.Text = "Оператор \"print\"";
            Task2Question[5] = 1;
            Task26.Text = "Закрывающая круглая скобка";

            Task27.Visible = false;
            Task28.Visible = false;

            Task2Question[6] = 0;
            Task27.Text = "";
            Task2Question[7] = 0;
            Task28.Text = "";

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
            Task2Text.Text = "Выберите правильные имена переменных";
            DefaultTask2();
            // Сколько баллов будет давать каждый ответ:
            Task2Question[0] = 1;
            Task21.Text = "MyVariable";
            Task2Question[1] = 1;
            Task22.Text = "Adiós_Señora";
            Task2Question[2] = -1;
            Task23.Text = "Exchange Rate";
            Task2Question[3] = -1;
            Task24.Text = "10т";
            Task2Question[4] = -1;
            Task25.Text = "break";
            Task2Question[5] = 1;
            Task26.Text = "t34";

            Task27.Visible = false;
            Task28.Visible = false;

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
            Task2Text.Text = "Ваш результат: " + (Points.Sum()).ToString() + " из " + (Points2.Sum()).ToString();
            user.SetTasks(1, Points.Sum());
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
            Task2Text.Text = "Вы набрали: " + (a).ToString() + " из " + (b).ToString();
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
        private void OpenTask3(object sender, EventArgs e)
        {
            SetingText = "Task3";
            CloseAll();
            Task3Panel.Visible = true;
            Task3Result.Text = "Проверить";
            Task3_1();
            for (byte i = 0; i < task3RadioChecked.Length; i++)
            {
                task3RadioChecked[i] = 0;
            }
        }

        byte task3 = 0;
        byte[] task3RadioChecked = new byte[10];
        private void Task3_1()
        {
            NextButton.Enabled = true;
            Task3RadioDefaultChecked();
            Task3Result.Visible = false;
            if (task3 == 2)
            {
                Task3LoadCheched(1);
            }
            task3 = 1;
            Task3Text1.Text = "[name = \"John\"]\n[print('Hi, %s' % name)]";
            Task3_11.Text = "\"Hi, John\""; // o
            Task3_12.Text = "\"Hi, name\"";
            Task3_13.Text = "Ошибка";
            Task3_14.Text = "\"Hi,\"";
            Task3Text2.Text = "[x = 23] [num = 0 if x > 10 else 11]\n[print(num)]";
            Task3_21.Text = "0"; // o
            Task3_22.Text = "Ошибка";
            Task3_23.Text = "23";
            Task3_24.Text = "10";
            Task3Text3.Text = "Какая функция выводит что-либо в консоль?";
            Task3_31.Text = "print()"; // o
            Task3_32.Text = "write()";
            Task3_33.Text = "out()";
            Task3_34.Text = "log()";
            Task3Text4.Text = "Есть ошибка?[def factorial(n): [if n == 0: return 1] [else: return n * factorial(n - 1)]]\n[print(factorial(5))]";
            Task3_41.Text = "Функция всегда будет возвращать";
            Task3_42.Text = "Необходимо указать тип возвращаемого значения";
            Task3_43.Text = "Функция не может вызывать сама себя";
            Task3_44.Text = "В коде нет никаких ошибок"; // o
            Task3Text5.Text = "";
            Task3_51.Text = "";
            Task3_52.Text = "";
            Task3_53.Text = "";
            Task3_54.Text = "";

        }
        private void Task3_2()
        {
            Task3Result.Visible = true;
            Task3Result.Text = "Проверить";
            Task3RadioDefaultChecked();
            Task3LoadCheched(2);
            task3 = 2;
            Task3Text1.Text = "";
            Task3_11.Text = "";
            Task3_12.Text = "";
            Task3_13.Text = "";
            Task3_14.Text = "";
            Task3Text2.Text = "";
            Task3_21.Text = "";
            Task3_22.Text = "";
            Task3_23.Text = "";
            Task3_24.Text = "";
            Task3Text3.Text = "";
            Task3_31.Text = "";
            Task3_32.Text = "";
            Task3_33.Text = "";
            Task3_34.Text = "";
            Task3Text4.Text = "";
            Task3_41.Text = "";
            Task3_42.Text = "";
            Task3_43.Text = "";
            Task3_44.Text = "";
            Task3Text5.Text = "";
            Task3_51.Text = "";
            Task3_52.Text = "";
            Task3_53.Text = "";
            Task3_54.Text = "";

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

        private void Task3LoadCheched(byte x)
        {
            (Task3_11.Checked) = ((task3RadioChecked[x - 1 + 0] == 1) ? (true) : (false));
            (Task3_12.Checked) = ((task3RadioChecked[x - 1 + 0] == 2) ? (true) : (false));
            (Task3_13.Checked) = ((task3RadioChecked[x - 1 + 0] == 3) ? (true) : (false));
            (Task3_14.Checked) = ((task3RadioChecked[x - 1 + 0] == 4) ? (true) : (false));
            (Task3_21.Checked) = ((task3RadioChecked[x - 1 + 1] == 1) ? (true) : (false));
            (Task3_22.Checked) = ((task3RadioChecked[x - 1 + 1] == 2) ? (true) : (false));
            (Task3_23.Checked) = ((task3RadioChecked[x - 1 + 1] == 3) ? (true) : (false));
            (Task3_24.Checked) = ((task3RadioChecked[x - 1 + 1] == 4) ? (true) : (false));
            (Task3_31.Checked) = ((task3RadioChecked[x - 1 + 2] == 1) ? (true) : (false));
            (Task3_32.Checked) = ((task3RadioChecked[x - 1 + 2] == 2) ? (true) : (false));
            (Task3_33.Checked) = ((task3RadioChecked[x - 1 + 2] == 3) ? (true) : (false));
            (Task3_34.Checked) = ((task3RadioChecked[x - 1 + 2] == 4) ? (true) : (false));
            (Task3_41.Checked) = ((task3RadioChecked[x - 1 + 3] == 1) ? (true) : (false));
            (Task3_42.Checked) = ((task3RadioChecked[x - 1 + 3] == 2) ? (true) : (false));
            (Task3_43.Checked) = ((task3RadioChecked[x - 1 + 3] == 3) ? (true) : (false));
            (Task3_44.Checked) = ((task3RadioChecked[x - 1 + 3] == 4) ? (true) : (false));
            (Task3_51.Checked) = ((task3RadioChecked[x - 1 + 4] == 1) ? (true) : (false));
            (Task3_52.Checked) = ((task3RadioChecked[x - 1 + 4] == 2) ? (true) : (false));
            (Task3_53.Checked) = ((task3RadioChecked[x - 1 + 4] == 3) ? (true) : (false));
            (Task3_54.Checked) = ((task3RadioChecked[x - 1 + 4] == 4) ? (true) : (false));
        }

        private void Task3SaveChecked(byte x)
        {
            task3RadioChecked[x - 1 + 0] += (byte)((Task3_11.Checked) ? (1) : (0));
            task3RadioChecked[x - 1 + 0] += (byte)((Task3_12.Checked) ? (2) : (0));
            task3RadioChecked[x - 1 + 0] += (byte)((Task3_13.Checked) ? (3) : (0));
            task3RadioChecked[x - 1 + 0] += (byte)((Task3_14.Checked) ? (4) : (0));
            task3RadioChecked[x - 1 + 1] += (byte)((Task3_21.Checked) ? (1) : (0));
            task3RadioChecked[x - 1 + 1] += (byte)((Task3_22.Checked) ? (2) : (0));
            task3RadioChecked[x - 1 + 1] += (byte)((Task3_23.Checked) ? (3) : (0));
            task3RadioChecked[x - 1 + 1] += (byte)((Task3_24.Checked) ? (4) : (0));
            task3RadioChecked[x - 1 + 2] += (byte)((Task3_31.Checked) ? (1) : (0));
            task3RadioChecked[x - 1 + 2] += (byte)((Task3_32.Checked) ? (2) : (0));
            task3RadioChecked[x - 1 + 2] += (byte)((Task3_33.Checked) ? (3) : (0));
            task3RadioChecked[x - 1 + 2] += (byte)((Task3_34.Checked) ? (4) : (0));
            task3RadioChecked[x - 1 + 3] += (byte)((Task3_41.Checked) ? (1) : (0));
            task3RadioChecked[x - 1 + 3] += (byte)((Task3_42.Checked) ? (2) : (0));
            task3RadioChecked[x - 1 + 3] += (byte)((Task3_43.Checked) ? (3) : (0));
            task3RadioChecked[x - 1 + 3] += (byte)((Task3_44.Checked) ? (4) : (0));
            task3RadioChecked[x - 1 + 4] += (byte)((Task3_51.Checked) ? (1) : (0));
            task3RadioChecked[x - 1 + 4] += (byte)((Task3_52.Checked) ? (2) : (0));
            task3RadioChecked[x - 1 + 4] += (byte)((Task3_53.Checked) ? (3) : (0));
            task3RadioChecked[x - 1 + 4] += (byte)((Task3_54.Checked) ? (4) : (0));
        }
        private void Task3RadioChanged(object sender, EventArgs e)
        {
            Task3Result.Text = "Проверить";
        }

        byte task3Rating = 0;
        private void Task3Result_click(object sender, EventArgs e)
        {
            if (task3 == 1)
            {
                task3Rating = 0;
                if (Task3_11.Checked)
                {
                    task3Rating++;
                }
                if (Task3_21.Checked)
                {
                    task3Rating++;
                }
                if (Task3_31.Checked)
                {
                    task3Rating++;
                }
                if (Task3_44.Checked)
                {
                    task3Rating++;
                }
                if (Task3_52.Checked)
                {
                    task3Rating++;
                }
                Task3RadioDefaultChecked();
                Task3_2();
                Task3SaveChecked(1);
            }
            else
            {
                if (task3 == 2)
                {
                    if (Task3_12.Checked)
                    {
                        task3Rating++;
                    }
                    if (Task3_23.Checked)
                    {
                        task3Rating++;
                    }
                    if (Task3_31.Checked)
                    {
                        task3Rating++;
                    }
                    if (Task3_43.Checked)
                    {
                        task3Rating++;
                    }
                    if (Task3_52.Checked)
                    {
                        task3Rating++;
                    }
                    //Task3RadioDefaultChecked();
                    Task3Result.Text = "Верно: " + task3Rating.ToString() + " из 10";
                    user.SetTasks(2, ((task3Rating > (byte)user.GetTasks(2)) ? (task3Rating) : ((byte)user.GetTasks(2))));
                    Task3SaveChecked(2);
                    NextButton.Enabled = false;
                }
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // Собираем информацию по регистрации ФИО, логин, пароль
            string[] temp = { RegisterNameTextBox.Text, RegisterLoginTextBox.Text, RegisterPasswordTextBox.Text };
            // Нужно ли выйти с функции? (когда где-то ошибка)
            bool isExit = false;
            if (temp[0].Length < 1) // Проверяем ФИО на длину
            {
                RegisterErrorFIO.Text = "ФИО пустое";
                isExit = true;
            }
            else RegisterErrorFIO.Text = "";
            if (temp[1].Length < 4) // Проверяем логин на длину
            {
                RegisterErrorLogin.Text = "Короткий Login";
                isExit = true;
                if (temp[1].Length > 0) // Если логин заполнен
                    if (!char.IsLetter(temp[1][0])) // Если 1-й символ - не буквы - ошибка
                    {
                        RegisterErrorLogin.Text += ", начни с буквы";
                    }
            }
            else
            {
                RegisterErrorLogin.Text = "";
                if (temp[1].Length > 0) // Если логин заполнен
                    if (!char.IsLetter(temp[1][0])) // Если 1-й символ - не буквы - ошибка
                    {
                        RegisterErrorLogin.Text += "Начни с буквы";
                        isExit = true;
                    }
            }
            if (temp[2].Length < 4) // Если пароль короткий
            {
                RegisterErrorPassword.Text = "Короткий Password";
                isExit = true;
            }
            else RegisterErrorPassword.Text = "";
            if (isExit) return; // Если ошибка есть, то выходим

            // Нужно ли добавлять? Если нашли ошибку, то add = false
            bool add = true;
            foreach (var i in users)
            {
                if (i.IsLogin(temp[1])) // Если нашли схожий логин, то добавлять не будем
                    add = false;
            }
            if (!add) // Если не добавляем, то даем информацию пользователю и выходим с функции
            {
                RegisterErrorLogin.Text = "Такой login уже существует";
                return;
            }
            if (RegisterCode.Text != codeX&&RegisterLabelCode.Visible)
            {
                RegisterInformation.Text = "Код преподавателя не подходит.";
                return;
            }
            // Создаем пользователя, студент или препод - выбирает typeUser
            User tempUser;
            if (RegisterLabelCode.Visible) tempUser = new User(temp[0], temp[1], temp[2]);
            else tempUser = new Student(temp[0], temp[1], temp[2]);
            // Добавляем в список пользователей
            users.Add(tempUser);
            // Информацию даем пользователю
            if (RegisterLabelCode.Visible) RegisterInformation.Text = "Преподаватель";
            else RegisterInformation.Text = "Студент";
            RegisterInformation.Text += " успешно зарегистрирован.\nФИО: " + temp[0] + "\nLogin: " + temp[1];
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
            SetingText = "Authentication";
            CloseAll();
            AuthLoginTextBox.Text = "";
            AuthPasswordTextBox.Text = "";
            AuthPanel.Visible = true;
            AuthInformation.Text = "";
            BackButton.Enabled = false;
        }

        private void OpenRegisterPanel_Click(object sender, EventArgs e)
        {
            SetingText = "Registration";
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
            // Собираем информацию по авторизации: логин, пароль
            string[] temp = { AuthLoginTextBox.Text, AuthPasswordTextBox.Text };

            bool logining = false;
            foreach (var i in users)
            {
                if (i.IsLogin(temp[0])) // Если нашли схожий логин, то добавлять не будем
                    if (i.IsPassword(temp[1]))
                    {
                        logining = true;
                        user = i;
                        typeUser = user.IsTeacher();
                    }
            }
            if (!logining) // Если не добавляем, то даем информацию пользователю и выходим с функции
            {
                AuthInformation.Text = "Не получилось войти.\nLogin и Password введены неверно.";
                return;
            }
            // Создаем пользователя, студент или препод - выбирает typeUser

            // Информацию даем пользователю
            if (typeUser) AuthInformation.Text = "Препод";
            else AuthInformation.Text = "Студент";
            AuthInformation.Text += ".\nФИО: " + temp[0] + "\nLogin: " + temp[1];
        }

        private void OpenSetting(object sender, EventArgs e)
        {
            SetingText = "Setting";
            CloseAll();
            SettingPanel.Visible = true;
            SettingTextBox.Text = "";
            foreach (var i in users)
            {
                if (!i.IsTeacher())
                {
                    SettingTextBox.Text += "ФИО: ";
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
                SettingLabel.Text = "Вы выделили " + selectedText + ", это не логин";
                return;
            }
            SetingText = "Setting Student";
            CloseAll();
            SettingUserPanel.Visible = true;
            if (settingUser != null)
            {
                SettingUserLabel.Text = "Вы выбрали: " + settingUser.GetName();
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

        private void MainMenuOpenAuthPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                foreach (var i in users)
                {
                    if (i.IsLogin("Admin")) // Если нашли схожий логин, то добавлять не будем
                    {
                        user = i;
                        typeUser = true;
                        OpenMainMenu(sender, new EventArgs());
                        return;
                    }
                }
                user = new User("Admin", "Admin", "12345");
                users.Add(user);
                typeUser = true;
                OpenMainMenu(sender, new EventArgs());
            }
        }

        private void OpenTheoryP(object sender, EventArgs e) // Открыть теорию для препода
        {
            CloseAll();
            SetingText = "TheoryML";
            TheoryPPanel.Visible = true;
            theoryML = 0;
        }

        private void OpenTheoryP_1(object sender, EventArgs e) // Гибкая модель
        {
            CloseAll();
            SetingText = "TheoryMLText";
            theoryML = 2;
            OpenTheory(sender, e);
        }

        private void OpenTheoryP_2(object sender, EventArgs e) // Перевернутый класс
        {
            CloseAll();
            SetingText = "TheoryMLText";
            theoryML = 3;
            OpenTheory(sender, e);
        }

        private void OpenTheoryP_3(object sender, EventArgs e) // Смешанный курс
        {
            CloseAll();
            SetingText = "TheoryMLText";
            theoryML = 4;
            OpenTheory(sender, e);
        }
    }
}