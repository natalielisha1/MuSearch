using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2.GUI
{

    using MuSearch.BusinessLayer;

    /// <summary>
    /// Interaction logic for UserInput.xaml
    /// </summary>
    public partial class UserInputWindow : Window
    {
        public string categoryInput { get; set; }
        private int userId;
        private UserInput userInputBL;
        public UserInputWindow(int userId)
        {
            InitializeComponent();
            this.userInputBL = new UserInput();
            this.userId = userId;
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            string valid = this.userInputBL.generateCategories(this.txtUserInput.Text);
            if (valid != null)
            {
                //go to next page
                CategoryWindow categoryWindow = new CategoryWindow(this.userId,valid);
                categoryWindow.Show();
                this.Close();
            }
            else
            {
                // pop up error
                MessageBox.Show("Sorry, username or password is incorrect!");
            }
        }
    }
}
