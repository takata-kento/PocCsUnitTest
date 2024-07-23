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


        /*
        public static ObservableCollection<User>? userList { get; set; }
        public ObservableCollection<User> UserList
        {
#pragma warning disable CS8603 // Null 参照戻り値である可能性があります。
            get => userList;
#pragma warning restore CS8603 // Null 参照戻り値である可能性があります。
            set
            {
                userList = value;
            }
        }
        */


        // Insert用データ
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
                    // Id は LocalDB で自動的に付与される
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
