using SampleWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace SampleWPF.ViewModels
{
    public class MainWindowVM
    {
        private ObservableCollection<User> users { get; set; }

        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
            }
        }

        // Insert用データ
        private int insertId=0;
        public int InsertId()
        {
            int id = insertId;
            insertId++;
            return id;
        }

        private string insertFirstName;
        public string InsertFirstName
        {
            get => insertFirstName;
            set
            {
                insertFirstName = value;
            }
        }

        private string insertLastName;
        public string InsertLastName
        {
            get => insertLastName;
            set
            {
                insertLastName = value;
            }
        }

        private void UpdateUserList(User _user)
        {
            Users.Add(_user);
        }

        private void DropUserList(int _id)
        {
            Users.Remove(users.Where(user => user.Id == _id).First());
        }

        // ForwardedCommand
        public ICommand InsertCommand { get; private set; }
        public void ExecuteInsert()
        {
            // LocalDB 更新
            User insertUser = new()
                {
                    Id = InsertId(),
                    FirstName = InsertFirstName,
                    LastName = InsertLastName
                };

            UpdateUserList(insertUser);
        }

        public ICommand ListTrashCommand { get; private set; }
        public void ExecuteTrash(int _id)
        {
            // LocalDB 更新
            DropUserList(_id);
        }

        public MainWindowVM()
        {
            Users = new ObservableCollection<User>();

            InsertCommand = new ForwardedCommand(ExecuteInsert);
            ListTrashCommand = new ForwardedCommand<int>(ExecuteTrash);

            // CS8618 対応
            insertFirstName = "";
            insertLastName = "";

        }
    }
}
