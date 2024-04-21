using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTaskAnket_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Person Person { get; set; } = new Person();
        public ObservableCollection<Person> People { get; set; } = new();
        public string FilePath { get; set; } = string.Empty;
        public MainWindow()
        {
            InitializeComponent();

            DataContext =this;
        }



        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            People.Add(Person);

            MessageBox.Show("Add Data");
        }



        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            JsonHandler<Person> saveData = new(FilePath);
            foreach (var person in People)
            {
                bool isDublicate = false;
                foreach (var person1 in saveData.Items)
                {
                    if (person.Equals(person1))
                        isDublicate=true;
                }
                if(!isDublicate)
                {
                    saveData.Items.Add(person);
                }
                    
            }
            saveData.SaveData();
            MessageBox.Show("All Data Saved!");

        }

     
        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            if (File.Exists(FilePath))
            {
                JsonHandler<Person> AllData = new(FilePath);

                foreach (var person in AllData.Items)
                {
                   
                    People.Add(person);
                }
                MessageBox.Show("All Data Loaded!");
            }
            else
            {
                MessageBox.Show("Don't Found File");
            }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;

           //nametxt.text=listbox.selectedvalue.tostring();
           //surnametxt.text=listbox.selectedvalue.tostring();
           //emailtxt.text=listbox.selectedvalue.tostring();
           //phonetxt.text=listbox.selectedvalue.tostring();
           ////birthday.selecteddate=listbox.selectedvalue;
        }
    }
}