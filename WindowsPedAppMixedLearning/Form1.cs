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

        // Права пользователя (Студента)
        class Student : User
        {
            bool[][] access = {
                new bool[]{
                false, // Лекция 1
                false, // Лекция 2
                false, // Лекция 3
                false, // Лекция 4
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
        string TextPanel = "Main Menu";
        string Theory1 = "\tОдной из новых электронных форм организации образовательного процесса является технология (модель) смешанного обучения, которая сочетает в себе элементы традиционного и дистанционного обучения. \n \tПод смешанным обучением, в соответствии с ГОСТ Р 52653-2006 «Информационно-коммуникационные технологии в образовании. Термины и определения», понимается «педагогическая технология, предполагающая сочетание сетевого (онлайн) обучения с очным или автономным обучением». Автономное (онлайн) обучение предполагает, согласно тому же ГОСТу, «обучение с помощью компьютера без подключения к информационно-телекоммуникационной сети». \r\n\tТаким образом, термин «смешанное обучение» имеет два принципиально различных значения: 1) «онлайн + очное» обучение и 2) «онлайн + автономное» обучение;\r\n\tСмешанное обучение несомненно представляет собой прогрессивную образовательную технологию, имеющую широкие перспективы для использования и дальнейшего развития.\r\n\tРассмотрим основные составляющие смешанной модели обучения:\n\r\n1.\tЛекционные занятия: материалы лекций оформлены в виде презентаций или онлайн курса.\r\n2.\tСеминарские занятия (личные встречи): занятия могут быть объединены с лекционными. Обсуждение наиболее важных тем дисциплины, а также отработка практических навыков.\r\n3.\tУчебные материалы дисциплин (учебники и методические пособия): материалы представлены в печатном и в электронном виде, используются различные мультимедийные приложения.\r\n4.\tОнлайн - общение с преподавателями и студентами.\r\n5.\tИндивидуальные и групповые онлайн - проекты (сотрудничество): развитие навыков работы в Интернете, анализа информации из различных источников, работы вместе с группой, распределения обязанностей и ответственности за выполнение работы.\r\n6.\tВиртуальная классная комната: общение обучающихся с\r\n7.\tпреподавателем с помощью различных средств Интернет-коммуникаций.\r\n8.\tАудио и видеолекции, анимации и симуляции.\n\r\n\tВ российском образовании смешанное обучение находится на стадии становления и развития, но многие учителя, реализующие эту модель на своих занятиях, говорят об этой технологии как об образовании будущего, позволяющем преодолеть типичные трудности, с которыми сталкиваются учителя во время занятий.\r\n\tСмешанное обучение включается в себя плюсы очного и дистанционного обучения. От очного обучения берутся важные составляющие: индивидуальность подхода к ученику, мотивация к обучению, командная и групповая работа и наличие обратной связи. От дистанционного обучения берутся: гибкий график обучения, отслеживание прогресса, бюджетность для образовательной организации и мобильность учащихся.";
        string Theory2 = "\tИсследователи, занимающиеся вопросами смешанного обучения, предлагают разнообразные модели и подходы его внедрения в учебный процесс. Существует более 40 моделей смешанного обучения, но не все они одинаково эффективны.\r\n\tОдни из основных моделей:\r\n\n•\tПеревёрнутый класс – самая простая для реализации модель, поскольку для ее реализации не требуется специально оборудованного компьютерами учебного кабинета. Она позволяет минимизировать фронтальную работу (учитель объясняет, дети слушают) и позволяет реализовать интерактивные формы работы на уроке.\r\nУчащиеся работают дома в учебной онлайн-среде, пользуясь собственными электронными устройствами, подключенными к интернету: знакомятся с материалом или повторяют изученный. В классе происходит закрепление материала и работа с ним, которая может проходить в виде проектной деятельности, семинара или в других интерактивных формах. т.е. классная и домашняя работы «меняются местами». Эта модель смешанного обучения может применяться в школе для учеников начиная с 3-5 класса.\r\n•\tРотация станций – наиболее эффективная модель смешанного обучения в начальной и средней школе. Требует наличия компьютеров или планшетов в классе и использования систем управления обучением (например, Moodle).\n\r\n\tВсе учащие делятся на группы по видам учебной деятельности: работа с учителем, онлайн-обучение и проектная работа. Каждая группа работает в отдельной части класса - станции. Станции имеют разные цели: работа с учителем - получение обратной связи от учителя; онлайн-обучение - развитие навыков самостоятельной работы, личной ответственности, саморегуляции, умения учиться; проектная работа - применение знаний в решении практических задач, развитие коммуникативных навыков и получение обратной связи от одноклассников.\r\n\tВ течение урока ученики переходят от станции к станции так, чтобы побывать на каждой из них. Состав групп меняется из урока в урок в зависимости от педагогической задачи. Вместо трёх станций можно организовать две: работа с учителем и онлайн-работа; или четыре: работа с учителем, онлайн-работа, работа над коллективным проектом и индивидуальная самостоятельная работа.\n\r\n•\tРотация лабораторий – эта модель смешанного обучения предполагает, что часть занятий у учащихся проходит в обычном классе, а на один урок они перемещаются в компьютерный класс (лабораторию), где индивидуально работают в онлайн-среде. В онлайн-среде учащиеся могут изучать новый материал, закреплять пройденный, тренировать различные навыки, а также работать над собственным проектом. Если данная модель реализуется в школе, то наиболее эффективным обучение становится, когда учителя создают для детей общую по нескольким предметам онлайн-пространство. Эта модель смешанного обучения подходит для школьников любого возраста при условии, что онлайн-среда адекватна их возрасту.\r\n•\tГибкая модель – основа гибкой модели смешанного обучения в том, что ученики не ограничены по времени тем или иным видом учебной деятельности. Учащиеся самостоятельно составляют график работы, выбирают тему и темп, в котором они будут изучать материал. В этой модели по большей части используется онлайн-среда. Учитель работает с небольшими группами или индивидуально с учениками, которым нужна помощь. Эту модель наиболее эффективна для обучения школьников старших классов, студентов и взрослых, так как требует развитого навыка самоорганизации.\n\r\n\tТак же можно упомянуть 4 модели, которые С. Твигг выделила в смешанном обучении ещё в 2003 году:\n\r\n•\tReplacement Model (замещающая) – большая часть учебного материала осваивается в электронном формате. Преподаватель координирует учебный процесс, оказывает помощь в случае возникающих затруднений, проводит консультации;\r\n•\tSupplemental Model (поддерживающая) – основная часть времени отводится традиционному аудиторному обучению, которое дополняется работой с электронными ресурсами;\r\n•\tEmporium Model – модель предполагает осваивание учебной программы в условиях электронного обучения на специальном сайте учебного подразделения и в специально оборудованных компьютерных классах;\r\n•\tBuffet Model – студентам предоставляется возможность самостоятельно комбинировать аудиторные и электронные занятия в зависимости от их образовательных потребностей.\n\r\n\tВ свою очередь Х. Стакер и М. Хорн предлагают следующие способы внедрения смешанного обучения в образовательный процесс:\n\r\n•\tRotation Model (the Station Rotation, Individual Rotation, Flipped Classroom), где имеет место регулярное чередование традиционных аудиторных и электронных занятий/заданий;\r\n•\tFlex Model – основная часть учебного материала усваивается удаленно, студенты имеют возможность получить личную консультацию у преподавателя;\r\n•\tA La Carte Model – модель дает возможность выбирать дополнительные электронные курсы к основному образованию. Такая модель может быть полезна для студентов, чьи учебные интересы выходят за рамки традиционной образовательной программы;\r\n•\tEnriched Virtual Model – занятия в начале курса проводятся в традиционном формате, в дальнейшем студенты осваивают учебный материал и взаимодействуют с преподавателем удаленно.\r\n";
        string Theory3 = "\tОсновные достоинства смешанного обучения:\n\r\n•\tсмешанное обучение предполагает сокращение аудиторной нагрузки при сохранении интенсивности учебного взаимодействия за счет переноса части аудиторной деятельности на ИТ;\r\n•\tочная стадия смешанное обучение обеспечивает возможность взаимодействия обучающихся между собой и с педагогом; есть возможность обсудить материал, провести дискуссию;\r\n•\tсмешанное обучение позволяет преодолеть такие недостатки обучения с ИТ, как дефицит очного общения и социального взаимодействия, неразвитые умения выступать публично;\r\n•\tсовместное обучение и активные формы взаимодействия способствуют развитию обучающихся, повышают их когнитивные способности и эмоциональный интеллект;\r\n•\tсмешанное обучение способствует развитию «мягких навыков» (soft skills), необходимых сегодня и в перспективе, в информационном мире, для обучения на протяжении всей жизни;\r\n•\tсмешанное обучение обеспечивает возможность повысить и унифицировать уровень базовых знаний обучающихся, подготавливая их к совместному решению задач, реализации способностей;\r\n•\tсмешанное обучение обеспечивает свободу для обучающихся выбирать время и место обучения, изменять темп освоения материала, задавать число повторений, отрабатывать навыки, учитывая собственные индивидуальные способности и свой темп освоения;\r\n•\tобучающиеся могут позволить себе чередовать периоды активной деятельности и кратковременного отдыха (даже сна); именно во время сна образуются новые соединения нейронов, которые отвечают за запоминание информации, полученной перед сном;\r\n•\tимеет место индивидуальная поддержка познавательной деятельности каждого обучающегося педагогом – как на основе ИТ, так и организацией различных видов обратной связи;\r\n•\tповышается разнообразие форм организации групповой деятельности: совместная работа над проектами, семинары, дискуссии, форумы, электронные телеконференции, чаты;\r\n•\tединая платформа управления обучением обеспечивает возможность в любое время просмотреть учебный материал, произвести мониторинг рейтинга обучающегося, пройти как очное, так и дистанционное тестирование, получить аудио- и видеолекции;\r\n•\tпедагог освобождается для организации активных методов взаимодействия обучающихся, командной и проектной работы, консультирования, отработки навыков.\n\r\n\tСмешанное обучение имеет не только достоинства, но и ограничения при внедрении и недостатки:\n\r\n•\tнизкий уровень информационной культуры многих обучающихся и преподавателей; это может затруднить как индивидуальную, так и групповую работу с ИТ;\r\n•\tпредставление обучающимся сразу значительного объема дисциплины – может вызвать испуг, неуверенность в способности освоить весь материал;\r\n•\tотсутствие любознательности у части обучающихся, интереса к элементам, которые не оцениваются, выполнение только оцениваемых модулей и заданий;\r\n•\tнеготовность многих обучающихся самостоятельно рационально организовать свою образовательную деятельность;\r\n•\tбоязнь преподавателей остаться без нагрузки, без работы;\r\n•\tнедостаточное техническое, программное и коммуникационное обеспечение;\r\n•\tнеспособность многих учебных заведений к поддержке целостного процесса смешанного обучения;\r\n•\tнеобходимость постоянной организационной, технической и интеллектуальной поддержки образовательного процесса, материальных, ресурсных и временных затрат;\r\n•\tотсутствие методики расчета нагрузки преподавателя при смешанном обучении;\r\n•\tневозможность составить единое расписание занятий на базе программного обеспечения для организации смешанного обучения, поскольку схема занятий может меняться динамически.\r\n";
        string Theory4 = "\tЭффективность технологии смешанного обучения объясняется следующими факторами:\n\r\n1.\tкаждый студент получает возможность овладеть необходимыми знаниями и навыками в удобном формате;\r\n2.\tпланирование и понимание того, какие потребности в обучении должны удовлетворяться и какие результаты должны быть достигнуты;\r\n3.\tпредоставление эффективных инструментов управления обучением;\r\n4.\tсокращение временных и финансовых затрат на обучение, без потери преимуществ традиционного подхода;\r\n5.\tактивное социальное взаимодействие учащихся как между собой, так и с преподавателями;\r\n6.\tобучение возможно независимо от времени и места;\r\n7.\tразнообразие дидактических подходов;\r\n8.\tулучшение качества обучения (в том числе за счет использования более эффективных средств обучения);\r\n9.\tиндивидуальный контроль за обучением;\r\n10.\tестественное освещение учащимися современных средств организации работы, коммуникаций;\r\n11.\tприоритет самостоятельной деятельности обучаемого;\r\n12.\tорганизация индивидуальной поддержки учебной деятельности каждого обучаемого;\r\n13.\tиспользование организации групповой учебной деятельности;\r\n14.\tгибкость образовательной траектории;\r\n15.\tинтеграция онлайнового и оффлайнового учебно-методического контента многократного использования \n\r\n\tСмешанное обучение – сложный процесс, подразумевающий активное участие всех субъектов образовательной системы – как преподавателя, так и студентов, что позволяет говорить о его двойственной сущности. Так, смешанное обучение реализуется в двух аспектах:\n\r\n•\tличностно значимая учебная деятельность студента (самостоятельная и аудиторная);\r\n•\tорганизация этой деятельности преподавателем в электронном и традиционном форматах.\n\r\nОсновная цель смешанного обучения заключается в попытке объединить преимущества традиционного аудиторного и электронного обучения. В модели смешанного обучения электронный компонент является логическим продолжением традиционного аудиторного компонента и наоборот.\r\n";
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
            // Добавляем кнопки теории
            List<Button> A = new List<Button>();
            A.Add(TheoryButton1);
            A.Add(TheoryButton2);
            A.Add(TheoryButton3);
            A.Add(TheoryButton4);
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
            Task2Text.Text = "Какие принципы организации и проведения «перевернутых» уроков?";
            DefaultTask2();
            // Сколько баллов будет давать каждый ответ:
            Task2Question[0] = 1;
            Task21.Text = "Интерактивный урок";
            Task2Question[1] = 1;
            Task22.Text = "Доступная информация";
            Task2Question[2] = 1;
            Task23.Text = "Самостоятельная работа";
            Task2Question[3] = -1;
            Task24.Text = "Быстрый интернет";
            Task2Question[4] = -1;
            Task25.Text = "Большой объем информации";
            Task2Question[5] = 1;
            Task26.Text = "Безопасность при работе";

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
            Task2Text.Text = "Проблемы которые могут возникнуть при внедрении смешанногго обучения";
            DefaultTask2();
            // Сколько баллов будет давать каждый ответ:
            Task2Question[0] = -1;
            Task21.Text = "Развитие 'Мягких навыков'";
            Task2Question[1] = 1;
            Task22.Text = "Низкий уровень информационной культуры";
            Task2Question[2] = 1;
            Task23.Text = "Неодостаточное обеспечение";
            Task2Question[3] = -1;
            Task24.Text = "Сокращение аудиторной нагрузки";
            Task2Question[4] = -1;
            Task25.Text = "Единная платформа";
            Task2Question[5] = 1;
            Task26.Text = "Боязнь преподавателей";
            Task2Question[6] = -1;
            Task27.Text = "Активные методы взаимодействия";
            Task2Question[7] = 1;
            Task28.Text = "Отсутствие любознательности";

            Task27.Visible = true;
            Task28.Visible = true;

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
            Task3Result.Text = "Проверить";
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
            Task1Text.Text = "Верно";
            if (k != 4)
                Task1Text.Text = "Неверно";
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
            Task3Result.Text = "Верно: " + k.ToString() + " из 7";
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
            if (RegisterCode.Text != codeX)
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
            if (RegisterLabelCode.Visible) RegisterInformation.Text = "Препод";
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
            TextPanel = "Setting";
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
            TextPanel = "Setting Student";
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
    }
}