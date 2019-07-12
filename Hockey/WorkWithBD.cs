using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Hockey
{
    static class WorkWithBD
    {
        static private string stringSqlConnect = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security = True; AttachDbFilename =" + Path.GetFullPath(@"HockeyDataBase.mdf");

        /// <summary>
        /// Метод для проверки пользоватеей на их наличие в базе данных
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        static public bool CheckUser(string login, string password)
        {
            string passwordMD5 = WorkWithMD5.GetMD5Hash(password);
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM TableWithUsers WHERE Login = @Log AND Password = @Pas";
                cmd.Parameters.AddWithValue("Log", login);
                cmd.Parameters.AddWithValue("Pas", passwordMD5);
                cmd.Connection = Connect;
                int countUser = (int)cmd.ExecuteScalar();

                if (countUser > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Метод для проверки турниров на их наличие в базе данных
        /// </summary>
        /// <param name="name">Наименование турнира</param>
        static public bool CheckTournament(string name)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM TableWithTournament WHERE Name = @Name";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Connection = Connect;
                int countUser = (int)cmd.ExecuteScalar();

                if (countUser > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Метод для получения Id привилегии по названию привилегии из базы данных
        /// </summary>
        /// <param name="name">Наименование привилегии</param>
        static private string GetIdPrivilegeForNamePrivelege(string name)
        {
            string idPrivilege = "";
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithPrivilege WHERE NamePrivilege = @Nam";
                cmd.Parameters.AddWithValue("Nam", name);
                cmd.Connection = Connect;
                idPrivilege = cmd.ExecuteScalar().ToString();
            }
            return idPrivilege;
        }

        /// <summary>
        /// Метод для получения Id привилегии по логину пользователя из базы данных
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        static private string GetIdPrivilegeForLoginPrivelege(string login)
        {
            string idPrivilege = "";
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT IdPrivilege FROM TableWithUsers WHERE Login = @Log";
                cmd.Parameters.AddWithValue("Log", login);
                cmd.Connection = Connect;
                idPrivilege = cmd.ExecuteScalar().ToString();
            }
            return idPrivilege;
        }

        /// <summary>
        /// Метод для изменения привилегии пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        static public void EditPrivilege(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();

                string idPrivilege = string.Empty;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT IdPrivilege FROM TableWithUsers WHERE Id = @IdUser";
                cmd.Parameters.AddWithValue("IdUser", id);
                cmd.Connection = Connect;
                idPrivilege = cmd.ExecuteScalar().ToString();

                cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithPrivilege WHERE Id != @IdPrivilege";
                cmd.Parameters.AddWithValue("IdPrivilege", idPrivilege);
                cmd.Connection = Connect;
                idPrivilege = cmd.ExecuteScalar().ToString();

                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithUsers SET IDPrivilege = @IdPrivilege WHERE Id = @IdUser";
                cmd.Parameters.AddWithValue("IdUser", id);
                cmd.Parameters.AddWithValue("IdPrivilege", idPrivilege);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }
        
        /// <summary>
        /// Метод для удаления пользователя из базы данных
        /// </summary>
        /// <param name="id">Id пользователя</param>
        static public void DeleteUser(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithUsers WHERE Id = @IdUser";
                cmd.Parameters.AddWithValue("IdUser", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }
        
        /// <summary>
        /// Метод для добавления пользователя в базу данных
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        static public void AddUser(string login, string password)
        {
            string passwordMD5 = WorkWithMD5.GetMD5Hash(password);

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithUsers([Login], [Password], [IdPrivilege]) VALUES (@Log, @Pass, @Id)";

                cmd.Parameters.AddWithValue("Log", login);
                cmd.Parameters.AddWithValue("Pass", passwordMD5);
                cmd.Parameters.AddWithValue("Id", GetIdPrivilegeForNamePrivelege("User"));
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для получения названия привилегии по логину пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        static public string GetNamePrivilegeForLoginPrivelege(string login)
        {
            string namePrivilege = "";
            string idPrivilege = GetIdPrivilegeForLoginPrivelege(login);
            if(idPrivilege != "")
            {
                using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
                {
                    Connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT NamePrivilege FROM TableWithPrivilege WHERE Id = @IdPrivilege";
                    cmd.Parameters.AddWithValue("IdPrivilege", idPrivilege);
                    cmd.Connection = Connect;
                    namePrivilege = cmd.ExecuteScalar().ToString();
                }
            }
            return namePrivilege;
        }

        /// <summary>
        /// Метод для добавления стадиона в базу данных
        /// </summary>
        /// <param name="name">Название стадиона</param>
        /// <param name="city">Город стадиона</param>
        /// <param name="capacity">Вместимость стадиона</param>
        static public void AddStadium(string name, string city, string capacity)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithStadium([NameStadium], [CityStadium], [СapacityStadium]) VALUES (@Name, @City, @Capacity)";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("City", city);
                cmd.Parameters.AddWithValue("Capacity", capacity);
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для редактирования данных о стадионе
        /// </summary>
        /// <param name="id">Id стадиона</param>
        /// <param name="name">Название стадиона</param>
        /// <param name="city">Город стадиона</param>
        /// <param name="capacity">Вместимость стадиона</param>
        static public void EditStadium(string id, string name, string city, string capacity)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithStadium SET NameStadium = @Name, CityStadium = @City, СapacityStadium = @Capacity WHERE Id = @IdStad";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("City", city);
                cmd.Parameters.AddWithValue("Capacity", capacity);
                cmd.Parameters.AddWithValue("IdStad", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для удаления стадиона из базы данных
        /// </summary>
        /// <param name="id">Id стадиона</param>
        static public void DeleteStadium(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithStadium WHERE Id = @IdStad";
                cmd.Parameters.AddWithValue("IdStad", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для добавления судьи в базу данных
        /// </summary>
        /// <param name="name">Имя судьи</param>
        /// <param name="surname">Фамилия судьи</param>
        /// <param name="patronymic">Отчество судьи</param>
        /// <param name="birthday">День рождение судьи</param>
        /// <param name="matches">Количество проведёных матчей</param>
        static public void AddJudge(string name, string surname, string patronymic, string birthday, string matches)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithJudge([Name], [Surname], [Patronymic], [Birthday], [Matches]) VALUES (@Name, @Surname, @Patronymic, @Birthday, @Matches)";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Surname", surname);
                cmd.Parameters.AddWithValue("Patronymic", patronymic);
                cmd.Parameters.AddWithValue("Birthday", birthday);
                cmd.Parameters.AddWithValue("Matches", matches);
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для удаления судьи из базы данных
        /// </summary>
        /// <param name="id">Id судьи</param>
        static public void DeleteJudge(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithJudge WHERE Id = @IdJudge";
                cmd.Parameters.AddWithValue("IdJudge", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для редактирования данных о судье
        /// </summary>
        /// <param name="id">Id судьи</param>
        /// <param name="name">Имя судьи</param>
        /// <param name="surname">Фамилия судьи</param>
        /// <param name="patronymic">Отчество судьи</param>
        /// <param name="birthday">День рождение судьи</param>
        /// <param name="matches">Количество проведёных матчей</param>
        static public void EditJudge(string id, string name, string surname, string patronymic, string birthday, string matches)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithJudge SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic, Birthday = @Birthday, Matches = @Matches WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Surname", surname);
                cmd.Parameters.AddWithValue("Patronymic", patronymic);
                cmd.Parameters.AddWithValue("Birthday", birthday);
                cmd.Parameters.AddWithValue("Matches", matches);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для добавления тренера в базу данных
        /// </summary>
        /// <param name="name">Имя тренера</param>
        /// <param name="surname">Фамилия тренера</param>
        /// <param name="patronymic">Отчество тренера</param>
        /// <param name="nameTeam">Название команды которой управляет</param>
        /// <param name="matches">Количество сыгранных матчей</param>
        static public void AddCoach(string name, string surname, string patronymic, string matches, string nameTeam)
        {
            string id = "";
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithTeam WHERE Name = @Name";
                cmd.Parameters.AddWithValue("Name", nameTeam);
                cmd.Connection = Connect;
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    id = read[0].ToString();
                }
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithСoaches([Name], [Surname], [Patronymic], [Team], [Matches]) VALUES (@Name, @Surname, @Patronymic, @Team, @Matches)";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Surname", surname);
                cmd.Parameters.AddWithValue("Patronymic", patronymic);
                cmd.Parameters.AddWithValue("Team", id);
                cmd.Parameters.AddWithValue("Matches", matches);
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для добавления тренера в базу данных
        /// </summary>
        /// <param name="name">Имя тренера</param>
        /// <param name="surname">Фамилия тренера</param>
        /// <param name="patronymic">Отчество тренера</param>
        /// <param name="nameTeam">Название команды которой управляет</param>
        /// <param name="matches">Количество сыгранных матчей</param>
        static public void AddTeam(string name, string numberOfWin)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithTeam([Name], [NumberOfWins]) VALUES (@Name, @NumberOfWin)";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("NumberOfWin", numberOfWin);
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для получения информации о команде из базы данных для DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadTeamOfDataBaseInDataGridView(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TableWithTeam.Id, TableWithTeam.Name, TableWithTeam.NumberOfWins FROM TableWithTeam";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[5].Value = read[2];
                    }
                }  
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT TableWithСoaches.Name, TableWithСoaches.Surname, TableWithСoaches.Patronymic FROM TableWithСoaches INNER JOIN TableWithTeam ON TableWithСoaches.Team = @Id";
                    cmd.Parameters.AddWithValue("Id", dgv.Rows[i].Cells[0].Value);
                    cmd.Connection = Connect;
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            dgv.Rows[i].Cells[2].Value = read[0];
                            dgv.Rows[i].Cells[3].Value = read[1];
                            dgv.Rows[i].Cells[4].Value = read[2];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения названия команд из базы данных в Combobox
        /// </summary>
        /// <param name="combo">Combobox в который будут записаны названия</param>
        static public void ReadTeamOfDatabaseInComboBox(ComboBox combo)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Name FROM TableWithTeam";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        combo.Items.Add(read[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения информации о тренере для DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadCoachOfDatabaseInDatagridview(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TableWithСoaches.Id, TableWithСoaches.Name, TableWithСoaches.Surname, TableWithСoaches.Patronymic, TableWithСoaches.Matches FROM TableWithСoaches";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[2].Value = read[2];
                        dgv.Rows[i].Cells[3].Value = read[3];
                        dgv.Rows[i].Cells[5].Value = read[4];
                    }
                }
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT TableWithTeam.Name FROM TableWithСoaches INNER JOIN TableWithTeam ON TableWithСoaches.Team = TableWithTeam.Id AND TableWithСoaches.Id = @Id";
                    cmd.Parameters.AddWithValue("Id", dgv.Rows[i].Cells[0].Value.ToString());
                    cmd.Connection = Connect;
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            dgv.Rows[i].Cells[4].Value = read[0];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для редактирования тренера
        /// </summary>
        /// <param name="id">Id тренера</param>
        /// <param name="name">Имя тренера</param>
        /// <param name="surname">Фамилия тренера</param>
        /// <param name="patronymic">Отчество тренера</param>
        /// <param name="nameTeam">Название команды которой управляет</param>
        /// <param name="matches">Количество сыгранных матчей</param>
        static public void EditCoach(string id, string name, string surname, string patronymic, string matches, string team)
        {
            string idTeam = string.Empty;

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TableWithTeam.Id FROM TableWithTeam WHERE Name = @Name";
                cmd.Parameters.AddWithValue("Name", team);
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        idTeam = read[0].ToString();
                    }
                }
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithСoaches SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic, Team = @Team, Matches = @Matches WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Surname", surname);
                cmd.Parameters.AddWithValue("Patronymic", patronymic);
                cmd.Parameters.AddWithValue("Team", idTeam);
                cmd.Parameters.AddWithValue("Matches", matches);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для удаления тренера из базы данных
        /// </summary>
        /// <param name="id">Id тренера</param>
        static public void DeleteCoach(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithСoaches WHERE Id = @IdCoach";
                cmd.Parameters.AddWithValue("IdCoach", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для редактирования команды в базе данных
        /// </summary>
        /// <param name="id">Id команды</param>
        /// <param name="name">Название команды</param>
        /// <param name="numbOfWins">Количество побед</param>
        static public void EditTeam(string id, string name, string numbOfWins)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithTeam SET Name = @Name, NumberOfWins = @NumberOfWins WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("NumberOfWins", numbOfWins);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для удаления команды из базы данных
        /// </summary>
        /// <param name="id">Id команды</param>
        static public void DeleteTeam(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithTeam WHERE Id = @IdTeam";
                cmd.Parameters.AddWithValue("IdTeam", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для получения информации о пользователях для DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadUserForAdminFormForDataGirdView(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TableWithUsers.Id, TableWithUsers.Login, TableWithUsers.Password, TableWithPrivilege.NamePrivilege FROM TableWithPrivilege INNER JOIN TableWithUsers ON TableWithPrivilege.Id = TableWithUsers.IDPrivilege";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[2].Value = read[2];
                        dgv.Rows[i].Cells[3].Value = read[3];
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения информации о стадионах для DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadStadiumForDataGridView(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM TableWithStadium";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[2].Value = read[2];
                        dgv.Rows[i].Cells[3].Value = read[3];
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения информации о судьях для DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadJudgeForDataGridView(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM TableWithJudge";
                cmd.Connection = Connect;

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[2].Value = read[2];
                        dgv.Rows[i].Cells[3].Value = read[3];
                        dgv.Rows[i].Cells[4].Value = read[4];
                        dgv.Rows[i].Cells[5].Value = read[5];
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения информации об игроках для DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadPlayerForDataGridView(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TableWithPlayer.Id, TableWithPlayer.Name, TableWithPlayer.Surname, TableWithPlayer.Patronymic, TableWithTeam.Name AS Expr1, TableWithPosition.NamePosition, TableWithPlayer.Goals FROM TableWithTeam INNER JOIN TableWithPlayer ON TableWithTeam.Id = TableWithPlayer.IdTeam INNER JOIN TableWithPosition ON TableWithPlayer.IdPosition = TableWithPosition.Id";
                cmd.Connection = Connect;

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[2].Value = read[2];
                        dgv.Rows[i].Cells[3].Value = read[3];
                        dgv.Rows[i].Cells[4].Value = read[4];
                        dgv.Rows[i].Cells[5].Value = read[5];
                        dgv.Rows[i].Cells[6].Value = read[6];
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения названий позиций для Combobox
        /// </summary>
        /// <param name="combo">Combobox в который будут записаны позиции</param>
        static public void ReadPositionOfDatabaseInComboBox(ComboBox combo)
        {

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT NamePosition FROM TableWithPosition";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        combo.Items.Add(read[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Метод для добавления игрока в базу данных
        /// </summary>
        /// <param name="name">Имя игрока</param>
        /// <param name="surname">Фамилия игрока</param>
        /// <param name="patronymic">Отчество игрока</param>
        /// <param name="nameTeam">Название команды в которой играет</param>
        /// <param name="position">Название позиции игрока</param>
        /// <param name="goals">Количество забитых шайб</param>
        static public void AddPlayer(string name, string surname, string patronymic, string nameTeam, string position, string goals)
        {
            string idTeam = string.Empty;
            string idPosition = string.Empty;

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithTeam WHERE Name = @Name";
                cmd.Parameters.AddWithValue("Name", nameTeam);
                cmd.Connection = Connect;
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    idTeam = read[0].ToString();
                }
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithPosition WHERE NamePosition = @Name";
                cmd.Parameters.AddWithValue("Name", position);
                cmd.Connection = Connect;
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    idPosition = read[0].ToString();
                }
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithPlayer([Name], [Surname], [Patronymic], [IdTeam], [IdPosition], [Goals]) VALUES (@Name, @Surname, @Patronymic, @idTeam, @IdPosition, @Goals)";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Surname", surname);
                cmd.Parameters.AddWithValue("Patronymic", patronymic);
                cmd.Parameters.AddWithValue("idTeam", idTeam);
                cmd.Parameters.AddWithValue("IdPosition", idPosition);
                cmd.Parameters.AddWithValue("Goals", goals);
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для редактирования информации об игроке в базе данных
        /// </summary>
        /// <param name="id">Id игрока</param>
        /// <param name="name">Имя игрока</param>
        /// <param name="surname">Фамилия игрока</param>
        /// <param name="patronymic">Отчество игрока</param>
        /// <param name="nameTeam">Название команды в которой играет</param>
        /// <param name="position">Название позиции игрока</param>
        /// <param name="goals">Количество забитых шайб</param>
        static public void EditPlayer(string id, string name, string surname, string patronymic, string nameTeam, string position, string goals)
        {
            string idTeam = string.Empty;
            string idPosition = string.Empty;

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithTeam WHERE Name = @Name";
                cmd.Parameters.AddWithValue("Name", nameTeam);
                cmd.Connection = Connect;
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    idTeam = read[0].ToString();
                }
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithPosition WHERE NamePosition = @Name";
                cmd.Parameters.AddWithValue("Name", position);
                cmd.Connection = Connect;
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    idPosition = read[0].ToString();
                }
            }
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithPlayer SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic, IdTeam = @IdTeam, IdPosition = @IdPosition, Goals = @Goals WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Surname", surname);
                cmd.Parameters.AddWithValue("Patronymic", patronymic);
                cmd.Parameters.AddWithValue("idTeam", idTeam);
                cmd.Parameters.AddWithValue("IdPosition", idPosition);
                cmd.Parameters.AddWithValue("Goals", goals);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для удаления игрока из базы данных
        /// </summary>
        /// <param name="id">Id игрока</param>
        static public void DeletePlayer(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithPlayer WHERE Id = @IdPlayer";
                cmd.Parameters.AddWithValue("IdPlayer", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для получения Id команды в базе данных по названию
        /// </summary>
        /// <param name="nameTeam">Название команды</param>
        static public string GetIdForNameTeam(string nameTeam)
        {
            string idCommand = string.Empty;
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithTeam WHERE Name = @Name";
                cmd.Parameters.AddWithValue("Name", nameTeam);
                cmd.Connection = Connect;
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    idCommand = read[0].ToString();
                }
            }
            return idCommand;
        }

        /// <summary>
        /// Метод для получения название команды в базе данных по id
        /// </summary>
        /// <param name="idTeam">Id команды</param>
        static public string GetNameForIdTeam(string idTeam)
        {
            string nameTeam = "";
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TableWithTeam.Name FROM TableWithTeam WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", idTeam);
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        nameTeam = Convert.ToString(read[0]);
                    }
                }
            }
            return nameTeam;
        }

        /// <summary>
        /// Метод для получения Id турнира в базе данных по названию
        /// </summary>
        /// <param name="nameTournament">Название турнира</param>
        static public string GetIdForNameTournament(string nameTournament)
        {
            string idTournament = string.Empty;
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Id FROM TableWithTournament WHERE Name = @Name";
                cmd.Parameters.AddWithValue("Name", nameTournament);
                cmd.Connection = Connect;
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    idTournament = read[0].ToString();
                }
            }
            return idTournament;
        }

        /// <summary>
        /// Метод для добавления информации об игре
        /// </summary>
        /// <param name="nameCommand1">Название команды №1</param>
        /// <param name="nameCommand2">Название команды №2</param>
        /// <param name="datePlay">Дата игры</param>
        /// <param name="goalCommand1">Забито голов командой №1</param>
        /// <param name="goalCommand2">Забито голов командой №2</param>
        /// <param name="nameTournament">Название турнира</param>
        /// <param name="WinInB">Победа по буллитам</param>
        /// <param name="WinInOT">Победа в овертайм</param>
        static public void AddPlay(string nameCommand1, string goalCommand1, string nameCommand2, string goalCommand2, string nameTournament, bool WinInOT, bool WinInB, string datePlay)
        {
            string IdCommand1 = string.Empty;
            string IdCommand2 = string.Empty;
            string IdTournament = string.Empty;

            IdCommand1 = GetIdForNameTeam(nameCommand1);
            IdCommand2 = GetIdForNameTeam(nameCommand2);
            IdTournament = GetIdForNameTournament(nameTournament);
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithSchedule([IdTeamOne], [GoalsOneTeam], [IdTeamTwo], [GoalsTwoTeam], [IdTournament], [WinInOT], [WinInB], [DatePlay]) VALUES (@IdTeamOne, @GoalsOneTeam, @IdTeamTwo, @GoalsTwoTeam, @IdTournament, @WinInOT, @WinInB, @DatePlay)";
                cmd.Parameters.AddWithValue("IdTeamOne", IdCommand1);
                cmd.Parameters.AddWithValue("GoalsOneTeam", goalCommand1);
                cmd.Parameters.AddWithValue("IdTeamTwo", IdCommand2);
                cmd.Parameters.AddWithValue("GoalsTwoTeam", goalCommand2);
                cmd.Parameters.AddWithValue("IdTournament", IdTournament);
                cmd.Parameters.AddWithValue("WinInOT", WinInOT);
                cmd.Parameters.AddWithValue("WinInB", WinInB);
                cmd.Parameters.AddWithValue("DatePlay", datePlay);
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для получения названий турниров для Combobox
        /// </summary>
        /// <param name="combo">Combobox в который будут записаны турниры</param>
        static public void ReadTournamentOfDatabaseInComboBox(ComboBox combo)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT Name FROM TableWithTournament";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        combo.Items.Add(read[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения информации об играх из базы данных в DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadScheduleForDataGridView(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TableWithSchedule.Id, TableWithSchedule.IdTeamOne, TableWithSchedule.GoalsOneTeam, TableWithSchedule.GoalsTwoTeam, TableWithSchedule.IdTeamTwo, TableWithTournament.Name, TableWithSchedule.WinInOT, TableWithSchedule.WinInB, TableWithSchedule.DatePlay FROM TableWithTournament INNER JOIN TableWithSchedule ON TableWithTournament.Id = TableWithSchedule.IdTournament";
                cmd.Connection = Connect;

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[2].Value = read[2];
                        dgv.Rows[i].Cells[3].Value = read[3];
                        dgv.Rows[i].Cells[4].Value = read[4];
                        dgv.Rows[i].Cells[5].Value = read[5];
                        dgv.Rows[i].Cells[6].Value = read[6];
                        dgv.Rows[i].Cells[7].Value = read[7];
                        dgv.Rows[i].Cells[8].Value = read[8];
                    }
                }
            }
            for(int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[1].Value = GetNameForIdTeam(Convert.ToString(dgv.Rows[i].Cells[1].Value));
                dgv.Rows[i].Cells[4].Value = GetNameForIdTeam(Convert.ToString(dgv.Rows[i].Cells[4].Value));
            }
        }

        /// <summary>
        /// Метод для редактирования информации об игре
        /// </summary>
        /// <param name="id">Id игры</param>
        /// <param name="nameCommand1">Название команды №1</param>
        /// <param name="nameCommand2">Название команды №2</param>
        /// <param name="datePlay">Дата игры</param>
        /// <param name="goalCommand1">Забито голов командой №1</param>
        /// <param name="goalCommand2">Забито голов командой №2</param>
        /// <param name="nameTournament">Название турнира</param>
        /// <param name="WinInB">Победа по буллитам</param>
        /// <param name="WinInOT">Победа в овертайм</param>
        static public void EditPlay(string id, string nameCommand1, string goalCommand1, string nameCommand2, string goalCommand2, string nameTournament, bool WinInOT, bool WinInB, string datePlay)
        {
            string IdCommand1 = string.Empty;
            string IdCommand2 = string.Empty;
            string IdTournament = string.Empty;
            IdCommand1 = GetIdForNameTeam(nameCommand1);
            IdCommand2 = GetIdForNameTeam(nameCommand2);
            IdTournament = GetIdForNameTournament(nameTournament);

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithSchedule SET IdTeamOne = @IdTeamOne, GoalsOneTeam = @GoalsOneTeam, IdTeamTwo = @IdTeamTwo, GoalsTwoTeam = @GoalsTwoTeam, IdTournament = @IdTournament, WinInOT = @WinInOT, WinInB = @WinInB, DatePlay = @DatePlay WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("IdTeamOne", IdCommand1);
                cmd.Parameters.AddWithValue("GoalsOneTeam", goalCommand1);
                cmd.Parameters.AddWithValue("IdTeamTwo", IdCommand2);
                cmd.Parameters.AddWithValue("GoalsTwoTeam", goalCommand2);
                cmd.Parameters.AddWithValue("IdTournament", IdTournament);
                cmd.Parameters.AddWithValue("WinInOT", WinInOT);
                cmd.Parameters.AddWithValue("WinInB", WinInB);
                cmd.Parameters.AddWithValue("DatePlay", datePlay);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }

        }

        /// <summary>
        /// Метод для удаления игры из базы данных
        /// </summary>
        /// <param name="id">Id игры</param>
        static public void DeletePlay(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithSchedule WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для получения информации о турнирах из базы данных в DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView в который будет записана информация</param>
        static public void ReadTournamentForDataGridView(DataGridView dgv)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM TableWithTournament";
                cmd.Connection = Connect;
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    for (int i = 0; read.Read(); i++)
                    {
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = read[0];
                        dgv.Rows[i].Cells[1].Value = read[1];
                        dgv.Rows[i].Cells[2].Value = read[2];
                    }
                }
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                for(int i = 0; i < dgv.RowCount; i++)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT Name FROM TableWithTeam WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", dgv.Rows[i].Cells[2].Value);
                    cmd.Connection = Connect;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dgv.Rows[i].Cells[2].Value = reader[0];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для добавления турнира в базу данных
        /// </summary>
        /// <param name="nameTournament">Название турнира</param>
        /// <param name="nameTeam">Название победителя</param>
        static public void AddTournament(string nameTournament, string nameTeam)
        {
            string idTeam = string.Empty;
            if (nameTeam != string.Empty)
            {
                idTeam = GetIdForNameTeam(nameTeam);
            }

            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TableWithTournament([Name], [IdWinTeam]) VALUES (@Name, @IdWinTeam)";
                cmd.Parameters.AddWithValue("Name", nameTournament);
                if (idTeam != string.Empty)
                {
                    cmd.Parameters.AddWithValue("IdWinTeam", idTeam);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IdWinTeam", DBNull.Value);
                }
                cmd.Connection = Connect;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Метод для редактирования турнира
        /// </summary>
        /// <param name="id">Id турнира</param>
        /// <param name="nameTournament">Название турнира</param>
        /// <param name="nameTeam">Название победителя</param>
        static public void EditTournament(string id, string nameTournament, string nameTeam)
        {
            string idTeam = GetIdForNameTeam(nameTeam);
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE TableWithTournament SET Name = @Name, IdWinTeam = @IdWinTeam WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("Name", nameTournament);
                cmd.Parameters.AddWithValue("IdWinTeam", idTeam);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// Метод для удаления турнира из базы данных
        /// </summary>
        /// <param name="id">Id турнира</param>
        static public void DeleteTournament(string id)
        {
            using (SqlConnection Connect = new SqlConnection(stringSqlConnect))
            {
                Connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM TableWithTournament WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Connection = Connect;
                cmd.ExecuteReader();
            }
        }
    }
}